using AutoMapper;
using Transacoes.Modelo;

namespace Transacoes.DTOs.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Transacao, TransacaoCreateRequestDTO>().ReverseMap();
        CreateMap<Transacao, TransacaoUpdateDTO>().ReverseMap();
        CreateMap<Transacao, TransacaoListDTO>().ReverseMap();
        CreateMap<Transacao, TransacaoCreateResponseDTO>().ReverseMap();
    }
}
