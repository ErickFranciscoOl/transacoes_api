using System.ComponentModel.DataAnnotations;

namespace ProjetoFastCash.DTOs;

public class TransacaoDeleteDTO
{
    [Required(ErrorMessage = "O TxId é obrigatório.")]
    public string TxId { get; set; }

    public DateTime DataTransacao { get; set; }
}
