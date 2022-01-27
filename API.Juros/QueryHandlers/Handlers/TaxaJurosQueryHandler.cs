using AutoMapper;
using Domain.Commands;
using Domain.Dtos;
using Domain.Entities;
using Infra.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Juros.QueryHandler.Handlers
{
    public class TaxaJurosQueryHandler : ITaxaJurosQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly ITaxaJurosRepository _taxaJurosRepository;

        public TaxaJurosQueryHandler(IMapper mapper,
                                       ITaxaJurosRepository taxaJurosRepository)
        {
            _mapper = mapper;
            _taxaJurosRepository = taxaJurosRepository;
        }

        public async Task<TaxaJurosDtoResponse> HandlerAsync()
        {
            var response = new TaxaJurosDtoResponse();
            try
            {
                var entidadeBd = await _taxaJurosRepository.GetAll(_ => true);

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
