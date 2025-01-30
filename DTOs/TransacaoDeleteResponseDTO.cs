namespace Transacoes.DTOs;

public class TransacaoDeleteResponseDTO
{
    public string TxId { get; set; }
    public decimal Valor { get; set; }
    public string E2eId { get; set; }
    public DateTime DataTransacao { get; set; }
}
