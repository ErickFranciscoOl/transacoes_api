using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Transacoes.Models;

public class ApiKey
{

    [Key]
    [Column("id")]
    public int ApiId { get; set; }

    [Required]
    [StringLength(64)]
    [Column("apikey")]
    public string ApiKeys { get; set; }

    [MaxLength(100)]
    [Column("nome")]
    public string? Nome { get; set; }

    [StringLength(14, ErrorMessage = "CNPJ deve conter 14 dígitos.")]
    [Column("cnpj")]
    public string? Cnpj { get; set; }

    [MaxLength(10)]
    [Column("conta")]
    public string? Conta { get; set; }
}
