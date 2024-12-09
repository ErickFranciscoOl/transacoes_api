using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoFastCash.DTOs;
using ProjetoFastCash.Interface;

namespace ProjetoFastCash.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoListDTO>>> GetTransacoes()
        {
            var transacoes = await _transacaoService.GetTransacoes();
            return Ok(transacoes);
        }

        [HttpGet("{txid}")]
        public async Task<ActionResult<TransacaoListDTO>> GetTransacaoByTxId(string txid)
        {
            var transacao = await _transacaoService.TransacaoByTxId(txid);
            if (transacao == null)
            {
                return NotFound("Transação não encontrada.");
            }
            return Ok(transacao);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacaoCreateRequestDTO transacaoCreateRequestDTO)
        {
            if (transacaoCreateRequestDTO.Valor <= 0)
            {
                return BadRequest("O valor deve ser maior que zero.");
            }

            var response = await _transacaoService.CreateTransacao(transacaoCreateRequestDTO);
            return Ok(response);
        }

        [HttpPut("{txid}")]
        public async Task<ActionResult<TransacaoUpdateDTO>> UpdateTransacao(string txid, [FromBody] TransacaoUpdateDTO updateDto)
       
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var transacaoAtualizada = await _transacaoService.TransacaoUpdate(txid, updateDto);
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
            var response = await _transacaoService.TransacaoDelete(txid);

            if (response == null)
            {
                return NotFound(new { Message = "Transação não encontrada" });
            }

            return Ok(new { Message = "Transação excluída com sucesso", Transacao = response });
        }
    }
}
