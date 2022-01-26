﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
