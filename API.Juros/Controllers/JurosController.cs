using API.Juros.Controllers.RequestExamples;
using AutoMapper;
using Domain.Commands;
using Domain.Dtos;
using Domain.Entities;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Juros.Controllers
{
    [ApiController]
    [Route("v1/Juros")]
    public class JurosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaxaJurosRepository _taxaJurosRepository;

        public JurosController(IMapper mapper, ITaxaJurosRepository taxaJurosRepository)
        {
            _mapper = mapper;
            _taxaJurosRepository = taxaJurosRepository;
        }

        [ProducesResponseType(typeof(TaxaJurosDtoResponse), 200)]
        [SwaggerRequestExample(typeof(TaxaJurosDtoRequest), typeof(InterestRateRequestExample))]
        [HttpPost("taxaJuros")]
        public IActionResult TaxaJurosIncluir([FromBody] TaxaJurosDtoRequest request)
        {
            var entidade = new TaxaJuros(1);
            _taxaJurosRepository.Salvar(entidade);
            var command = _mapper.Map<InterestRateCommand>(request);

            return Ok(entidade);
        }
    }
}
