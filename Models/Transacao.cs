using Transacoes.Validation;

namespace Transacoes.Modelo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transacao
{
    [Key]
    [Column("id")]
    public int TransacaoId { get; set; }

    [Required]
    [MaxLength(35)]
    [Column("txid")]
    public string TxId { get; set; } = Guid.NewGuid().ToString("N").PadRight(35, '0');

    [StringLength(64)]
    [Column("e2e_id")]
    public string? E2eId { get; set; } = PixHelpers.GerarEndToEndId(DateTime.UtcNow);

    [MaxLength(100)]
    [Column("pagador_nome")]
    public string? PagadorNome { get; set; }

    [StringLength(11, ErrorMessage = "O CPF deve conter 11 dígitos.")]
    [CpfIsValid]
    [Column("pagador_documento")]
    public string? PagadorCpf { get; set; }

    [MaxLength(8)]
    [Column("pagador_banco")]
    public string? PagadorBanco { get; set; }

    [MaxLength(6)]
    [Column("pagador_agencia")]
    public string? PagadorAgencia { get; set; }

    [MaxLength(10)]
    [Column("pagador_conta")]
    public string? PagadorConta { get; set; }

    [MaxLength(100)]
    [Column("recebedor_nome")]
    public string? RecebedorNome { get; set; }

    [StringLength(11, ErrorMessage = "O CPF deve conter 11 dígitos.")]
    [Column("recebedor_documento")]
    [CpfIsValid]
    public string? RecebedorCpf { get; set; }

    [MaxLength(8)]
    [Column("recebedor_banco")]
    public string? RecebedorBanco { get; set; }

    [MaxLength(6)]
    [Column("recebedor_agencia")]
    public string? RecebedorAgencia { get; set; }

    [MaxLength(10)]
    [Column("recebedor_conta")]
    public string? RecebedorConta { get; set; }

    [Required]
    [Column("valor",TypeName = "decimal(10,2)")]
    public decimal Valor { get; set; }

    [Column("data_transacao")]
    public DateTime DataTransacao { get; set; } = DateTime.UtcNow;
}