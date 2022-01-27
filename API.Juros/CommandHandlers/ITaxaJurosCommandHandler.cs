using Domain.Commands;
using Domain.Dtos;
using System.Threading.Tasks;

namespace API.Juros.CommandHandlers
{
    public interface ITaxaJurosCommandHandler
    {
        Task<TaxaJurosDtoResponse> HandlerAsync(InterestRateCommand command);
    }
}
