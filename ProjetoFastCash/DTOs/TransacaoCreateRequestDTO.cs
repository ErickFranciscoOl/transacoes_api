using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFastCash.DTOs;

public class TransacaoCreateRequestDTO
{
    public decimal Valor { get; set; }
}

