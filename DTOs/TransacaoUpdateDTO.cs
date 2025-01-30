using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transacoes.DTOs;

public class TransacaoUpdateDTO
{

    public string PagadorNome { get; set; }

    public string PagadorCpf { get; set; }

    public string PagadorBanco { get; set; }

    public string? PagadorAgencia { get; set; }

    public string? PagadorConta { get; set; }

    public string? RecebedorNome { get; set; }

    public string? RecebedorCpf { get; set; }

    public string? RecebedorBanco { get; set; }

    public string? RecebedorAgencia { get; set; }

    public string? RecebedorConta { get; set; }

    public decimal Valor { get; set; }

}
