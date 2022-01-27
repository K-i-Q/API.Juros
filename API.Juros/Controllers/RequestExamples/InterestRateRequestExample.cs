using Domain.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace API.Juros.Controllers.RequestExamples
{
    public class InterestRateRequestExample : IExamplesProvider<TaxaJurosDtoRequest>
    {
        public TaxaJurosDtoRequest GetExamples()
        {
            return new TaxaJurosDtoRequest 
            {
                TaxaJuros = 1
            };
        }
    }
}
