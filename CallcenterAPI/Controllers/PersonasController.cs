using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CallcenterAPI.Service;

namespace CallcenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersona _service;

        //Para Futuras Actualizaciones (no Implementado)
        public PersonasController(IPersona pservice)
        {
            _service = pservice;
        }
    }
}