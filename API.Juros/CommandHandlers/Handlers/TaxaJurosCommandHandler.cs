using AutoMapper;
using Domain.Commands;
using Domain.Dtos;
using Domain.Entities;
using Infra.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Juros.CommandHandlers.Handlers
{
    public class TaxaJurosCommandHandler : ITaxaJurosCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly ITaxaJurosRepository _taxaJurosRepository;

        public TaxaJurosCommandHandler(IMapper mapper,
                                       ITaxaJurosRepository taxaJurosRepository)
        {
            _mapper = mapper;
            _taxaJurosRepository = taxaJurosRepository;
        }

        public async Task<TaxaJurosDtoResponse> HandlerAsync(InterestRateCommand command)
        {
            var response = new TaxaJurosDtoResponse();
            try
            {

                if (command == default)
                {
                    response.Mensagem = "Insucesso na inclusão de Taxa de Juros";
                    return response;
                }

                command.InterestRate = command.InterestRate / 100;

                var entidadeBd = await _taxaJurosRepository.GetAll(_ => true);
                
                
                if (entidadeBd != default && entidadeBd.Count > 0)
                {
                    var entidadeAtualizada = entidadeBd.First();

                    entidadeAtualizada.AlterarTaxa(command.InterestRate);

                    await _taxaJurosRepository.Atualizar(entidadeAtualizada);

                    response = _mapper.Map<TaxaJurosDtoResponse>(entidadeAtualizada);

                    response.Mensagem = "Taxa de Juros atualizada";
                }
                else
                {
                    var entidadeNova = _mapper.Map<TaxaJuros>(command);

                    await _taxaJurosRepository.Salvar(entidadeNova);

                    response = _mapper.Map<TaxaJurosDtoResponse>(entidadeNova);

                    response.Mensagem = "Taxa de Juros adicionada";
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
