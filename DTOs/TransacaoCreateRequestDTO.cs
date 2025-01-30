using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Transacoes.DTOs;

public class TransacaoCreateRequestDTO
{
    public decimal Valor { get; set; }
}

