using API.Juros.MockSetup;
using AutoMapper;
using Domain.Dtos;
using Infra.Repositories;
using Infra.Repositories.CosmosDbMock;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Juros.QueryHandler.Handlers
{
    public class TaxaJurosQueryHandler : ITaxaJurosQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        private readonly ICosmosDbClientFactory _factory;

        public TaxaJurosQueryHandler(IMapper mapper,
                                       ITaxaJurosRepository taxaJurosRepository,
                                       TaxaJurosMockSetup taxaJurosMockSetup)
        {
            _mapper = mapper;
            _taxaJurosRepository = taxaJurosMockSetup.Mocked ? new TaxaJurosRepositoryMock(_factory) : taxaJurosRepository;

        }

        public async Task<TaxaJurosDtoResponse> HandlerAsync()
        {
            var response = new TaxaJurosDtoResponse();
            try
            {
                var entidadeBd = await _taxaJurosRepository.Buscar();

                if(entidadeBd == default || entidadeBd.Count == 0)
                    response.Mensagem = "Nenhuma Taxa de Juros foi encontrada";
                else
                {
                    response = _mapper.Map<TaxaJurosDtoResponse>(entidadeBd.First());

                    response.Mensagem = "Sucesso";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                return response;
            }
        }
    }
}
