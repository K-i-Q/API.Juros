using Domain.Dtos;
using System.Threading.Tasks;

namespace API.Juros.QueryHandler
{
    public interface ITaxaJurosQueryHandler
    {
        Task<TaxaJurosDtoResponse> HandlerAsync();
    }
}
