using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Transacoes.DTOs;
using Transacoes.Infrastructure.Caching;
using Transacoes.Interface;

namespace Transacoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;
        private readonly ICachingService _cachingService;

        public TransacaoController(ITransacaoService transacaoService, ICachingService cachingService)
        {
            _transacaoService = transacaoService;
            _cachingService = cachingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoListDTO>>> GetTransacoes()
        {
            const string cacheKey = "transacoes";
            var cached = await _cachingService.GetStringAsync(cacheKey);

            if (cached != null)
            {
                var result = JsonSerializer.Deserialize<IEnumerable<TransacaoListDTO>>(cached);
                return Ok(result);
            }

            var transacoesData = await _transacaoService.GetTransacoes();
            var serializedTransacoes = JsonSerializer.Serialize(transacoesData);

            await _cachingService.SetStringAsync(cacheKey, serializedTransacoes, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
            });

            return Ok(transacoesData);
        }

        [HttpGet("{txid}")]
        public async Task<ActionResult<TransacaoListDTO>> GetTransacaoByTxId(string txid,
            CancellationToken cancellationToken = default)
        {
            var cached = await _cachingService.GetStringAsync(txid);

            if (cached == null)
            {
                var transacao = await _transacaoService.TransacaoByTxId(txid, cancellationToken);

                if (transacao == null)
                {
                    return NotFound("Transação não encontrada.");
                }

                var transacaoJson = JsonSerializer.Serialize(transacao);

                await _cachingService.SetStringAsync(txid, transacaoJson, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
                });

                return Ok(transacao);
            }

            var transacaoFromCache = JsonSerializer.Deserialize<TransacaoListDTO>(cached);
            return Ok(transacaoFromCache);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacaoCreateRequestDTO transacaoCreateRequestDTO)
        {
            if (transacaoCreateRequestDTO.Valor <= 0)
            {
                return BadRequest("O valor deve ser maior que zero.");
            }

            const string cacheKey = "transacoes";
            var transacao = await _transacaoService.CreateTransacao(transacaoCreateRequestDTO);
            var serializedTransacao = JsonSerializer.Serialize(transacao);

            await _cachingService.SetStringAsync(cacheKey, serializedTransacao, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
            });

            return Ok(transacao);
        }

        [HttpPut("{txid}")]
        public async Task<ActionResult<TransacaoUpdateDTO>> UpdateTransacao(string txid,
            [FromBody] TransacaoUpdateDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var transacaoAtualizada = await _transacaoService.TransacaoUpdate(txid, updateDto);
                var transacaoJson = JsonSerializer.Serialize(transacaoAtualizada);

                await _cachingService.SetStringAsync(txid, transacaoJson, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
                });

                return Ok(transacaoAtualizada);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Transação não encontrada.");
            }
        }

        [HttpDelete("{txid}")]
        public async Task<IActionResult> Delete(string txid)
        {
            var cached = await _cachingService.GetStringAsync(txid);

            if (cached == null)
            {
                var response = await _transacaoService.TransacaoDelete(txid);

                if (response == null)
                {
                    return NotFound(new { Message = "Transação não encontrada" });
                }

                var transacaoJson = JsonSerializer.Serialize(response);

                await _cachingService.SetStringAsync(txid, transacaoJson, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600)
                });

                return Ok(new { Message = "Transação excluída com sucesso", Transacao = response });
            }

            var transacaoFromCache = JsonSerializer.Deserialize<TransacaoListDTO>(cached);
            return Ok(new { Message = "Transação excluída com sucesso", Transacao = transacaoFromCache });
        }
    }
}