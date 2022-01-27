using API.Juros.CommandHandlers;
using API.Juros.Controllers.RequestExamples;
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

        public JurosController(IMapper mapper, ITaxaJurosCommandHandler taxaJurosCommandHandler)
        {
            _mapper = mapper;
            _taxaJurosCommandHandler = taxaJurosCommandHandler;
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
    }
}
