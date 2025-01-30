using Transacoes.DTOs;
using Transacoes.Modelo;

namespace Transacoes.Interface;

public interface ITransacaoRepository
{
    Task<IEnumerable<Transacao>> GetAll();
    Task<Transacao> GetByTxId(string txid);
    Task<TransacaoCreateResponseDTO> Create(TransacaoCreateRequestDTO transacao);
    Task<Transacao> Update(Transacao transacao);
    Task<Transacao> DeleteByTxId(string txid);
}