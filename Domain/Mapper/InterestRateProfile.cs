using AutoMapper;
using Domain.Commands;
using Domain.Commands.Response;
using Domain.Dtos;

namespace Domain.Mapper
{
    public class InterestRateProfile : Profile
    {
        public InterestRateProfile()
        {
            CreateMap<TaxaJurosDtoRequest, InterestRateCommand>(MemberList.None)
                .ForMember(dest => dest.InterestRate, opt => opt.MapFrom(src => src.TaxaJuros));
        }
    }
}
