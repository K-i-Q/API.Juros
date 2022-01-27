using API.Juros.CommandHandlers;
using API.Juros.Controllers.RequestExamples;
using API.Juros.QueryHandler;
using AutoMapper;
using Domain.Commands;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Threading.Tasks;

namespace API.Juros.Controllers
{
    [ApiController]
    [Route("v1/Juros")]
    public class JurosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITaxaJurosCommandHandler _taxaJurosCommandHandler;
        private readonly ITaxaJurosQueryHandler _taxaJurosQueryHandler;

        public JurosController(IMapper mapper, 
                               ITaxaJurosCommandHandler taxaJurosCommandHandler,
                               ITaxaJurosQueryHandler taxaJurosQueryHandler)
        {
            _mapper = mapper;
            _taxaJurosCommandHandler = taxaJurosCommandHandler;
            _taxaJurosQueryHandler = taxaJurosQueryHandler;
        }

        [ProducesResponseType(typeof(TaxaJurosDtoResponse), 200)]
        [SwaggerRequestExample(typeof(TaxaJurosDtoRequest), typeof(InterestRateRequestExample))]
        [HttpPost("taxaJuros")]
        public async Task<IActionResult> TaxaJurosIncluir([FromBody] TaxaJurosDtoRequest request)
        {
            try
            {
                var command = _mapper.Map<InterestRateCommand>(request);

                var result = await _taxaJurosCommandHandler.HandlerAsync(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new TaxaJurosDtoResponse { Mensagem = ex.Message });
            }
        }

        [ProducesResponseType(typeof(TaxaJurosDtoResponse), 200)]
        [HttpGet("consultar")]
        public async Task<IActionResult> TaxaJurosConsultar()
        {
            try
            {
                var result = await _taxaJurosQueryHandler.HandlerAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new TaxaJurosDtoResponse { Mensagem = ex.Message });
            }
        }
    }
}
