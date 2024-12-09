using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFastCash.DTOs
{
    public class TransacaoCreateResponseDTO
    {

        public int TransacaoId { get; set; }
        public string TxId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; } = DateTime.UtcNow;
    }
}
