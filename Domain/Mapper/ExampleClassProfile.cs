using AutoMapper;
using Domain.Commands.Response;
using Domain.Dtos;

namespace Domain.Mapper
{
    public class ExampleClassProfile : Profile
    {
        public ExampleClassProfile()
        {
            //Exemplo sem configuração de membro
            //CreateMap<ExemploDtoResponse, ExemploCommandResponse>();

            CreateMap<ExemploDtoResponse, ExampleCommandResponse>(MemberList.None)
                .ForMember(dest => dest.Message, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentBalance, opt => opt.MapFrom(src => src.Saldo));


        }
    }
}
