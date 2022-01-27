using AutoMapper;
using Domain.Commands;
using Domain.Commands.Response;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Mapper
{
    public class InterestRateProfile : Profile
    {
        public InterestRateProfile()
        {
            CreateMap<TaxaJurosDtoRequest, InterestRateCommand>(MemberList.None)
                .ForMember(dest => dest.InterestRate, opt => opt.MapFrom(src => src.TaxaJuros));

            CreateMap<InterestRateCommand, TaxaJuros>(MemberList.None)
                .ForMember(dest => dest.Taxa, opt => opt.MapFrom(src => src.InterestRate));

            CreateMap<TaxaJuros, TaxaJurosDtoResponse>(MemberList.None)
               .ForMember(dest => dest.TaxaJuros, opt => opt.MapFrom(src => src.Taxa));


        }
    }
}
