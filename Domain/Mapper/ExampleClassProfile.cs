using AutoMapper;
using Domain.Commands;
using Domain.Dtos;

namespace Domain.Mapper
{
    public class ExampleClassProfile : Profile
    {
        public ExampleClassProfile()
        {
            //Exemplo sem configuração de membro
            //CreateMap<ExemploDtoResponse, ExemploCommandResponse>();

            CreateMap<ExemploDtoResponse, ExemploCommandResponse>(MemberList.None)
                .ForMember(dest => dest.Message, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => src.saldo));


        }
    }
}
