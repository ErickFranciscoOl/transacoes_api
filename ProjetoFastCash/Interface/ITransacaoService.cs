using ProjetoFastCash.DTOs;

namespace ProjetoFastCash.Interface;
public interface ITransacaoService
{
    Task<IEnumerable<TransacaoListDTO>> GetTransacoes();
    Task<TransacaoListDTO> TransacaoByTxId(string txid);
    Task<TransacaoDeleteResponseDTO> TransacaoDelete(string txid);
    Task<TransacaoUpdateDTO> TransacaoUpdate(string txid, TransacaoUpdateDTO updateDto);
    Task<TransacaoCreateResponseDTO> CreateTransacao(TransacaoCreateRequestDTO createDto);
}
