using Domain.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace API.Juros.Controllers.ResponseExamples
{
    public class InterestRateSuccess : IExamplesProvider<TaxaJurosDtoResponse>
    {
        public TaxaJurosDtoResponse GetExamples()
        {
            return new TaxaJurosDtoResponse
            {
                TaxaJuros = 0.01m
            };
        }
    }
}
