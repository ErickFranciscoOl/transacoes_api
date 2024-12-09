using ProjetoFastCash.DTOs;
using ProjetoFastCash.Modelo;

namespace ProjetoFastCash.Interface;

public interface ITransacaoRepository
{
    Task<IEnumerable<Transacao>> GetAll();
    Task<Transacao> GetByTxId(string txid);
    Task<TransacaoCreateResponseDTO> Create(TransacaoCreateRequestDTO transacao);
    Task<Transacao> Update(Transacao transacao);
    Task<Transacao> DeleteByTxId(string txid);
}

