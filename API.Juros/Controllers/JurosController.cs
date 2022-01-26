using API.Juros.Controllers.RequestExamples;
using AutoMapper;
using Domain.Commands;
using Domain.Dtos;
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

        public JurosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(TaxaJurosDtoResponse), 200)]
        [SwaggerRequestExample(typeof(TaxaJurosDtoRequest), typeof(InterestRateRequestExample))]
        [HttpPost("taxaJuros")]
        public IActionResult TaxaJurosIncluir([FromBody] TaxaJurosDtoRequest request)
        {
            var command = _mapper.Map<InterestRateCommand>(request);

            return View();
        }
    }
}
