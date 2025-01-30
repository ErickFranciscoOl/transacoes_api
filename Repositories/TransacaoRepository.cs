using Microsoft.EntityFrameworkCore;
using Transacoes.Context;
using Transacoes.DTOs;
using Transacoes.Interface;
using Transacoes.Modelo;

namespace Transacoes.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _context;

        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transacao>> GetAll()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<Transacao> GetByTxId(string txid)
        {
            return await _context.Transacoes.FirstOrDefaultAsync(t => t.TxId == txid);
        }

        public async Task<TransacaoCreateResponseDTO> Create(TransacaoCreateRequestDTO transacao)
        {
            var novaTransacao = new Transacao
            {
                Valor = transacao.Valor
            };

            await _context.Transacoes.AddAsync(novaTransacao);
            await _context.SaveChangesAsync();

            return new TransacaoCreateResponseDTO
            {
                TxId = novaTransacao.TxId,
                TransacaoId = novaTransacao.TransacaoId,
                Valor = novaTransacao.Valor,
                DataTransacao = novaTransacao.DataTransacao
            };
        }

        public async Task<Transacao> Update(Transacao transacao)
        {
            var existingTransacao = await _context.Transacoes
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TransacaoId == transacao.TransacaoId);

            if (existingTransacao == null)
            {
                throw new KeyNotFoundException("Transação não encontrada.");
            }

            transacao.TransacaoId = existingTransacao.TransacaoId;
            transacao.TxId = existingTransacao.TxId;

            _context.Transacoes.Update(transacao);
            await _context.SaveChangesAsync();
            return transacao;
        }

        public async Task<Transacao> DeleteByTxId(string txid)
        {
            var transacao = await _context.Transacoes.FirstOrDefaultAsync(t => t.TxId == txid);

            if (transacao != null)
            {
                _context.Transacoes.Remove(transacao);
                await _context.SaveChangesAsync();
            }

            return transacao;
        }
    }
}