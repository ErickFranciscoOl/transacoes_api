using Transacoes.DTOs;

namespace Transacoes.Interface;
public interface ITransacaoService
{
    Task<IEnumerable<TransacaoListDTO>> GetTransacoes();
    Task<TransacaoListDTO> TransacaoByTxId(string txid, CancellationToken cancellationToken);
    Task<TransacaoDeleteResponseDTO> TransacaoDelete(string txid);
    Task<TransacaoUpdateDTO> TransacaoUpdate(string txid, TransacaoUpdateDTO updateDto);
    Task<TransacaoCreateResponseDTO> CreateTransacao(TransacaoCreateRequestDTO createDto);
}
