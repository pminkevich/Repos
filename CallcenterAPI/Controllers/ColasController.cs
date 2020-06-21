using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CallcenterAPI.Service;
using Microsoft.Extensions.Logging;
using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;

namespace CallcenterAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ColasController : ControllerBase
    {
        //private readonly ILogger
        private readonly IColas _service;
        private ReplyViewModel reply;
        public ColasController(IColas pService)
        {
            _service = pService;
            reply = new ReplyViewModel();

        }

        [HttpGet]
        [Route("GetCola")]
        //no implementado
        public async Task<ReplyViewModel> GetCola([FromHeader]string auth)
        {
           
            
                int IdUser = _service.CheckToken(auth);

                if (IdUser > 0)
                {
                    reply = await _service.VerCola(IdUser);
                }
                else
                {
                    reply.result = 3;
                    reply.message = "Acceso no Permitido";
                }

            return reply;
        }

        [HttpGet]
        [Route("Call")]
        public async Task<ReplyViewModel> Call([FromHeader]string auth)
        {
            //Reply reply = new Reply();

            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                reply =await  _service.Llamar(IdUser);
            }
            else
            {
                reply.result = 3;
                reply.message = "Acceso no Permitido";
            }

            return reply;
        }

        [HttpPut]
        [Route("UpdateCall")]
        public async Task<ReplyViewModel> ChangeState([FromHeader]string auth, [FromBody]ColaViewModel llamado)
        {
            //Reply reply = new Reply();

            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.UpdateCall(llamado))
                {
                    reply.result = 1; reply.message = "Estado Actualizado";
                }
                else
                {
                    reply.result = 0; reply.message = "No se Pudo Actualizar el Estado";
                }
                    
            }
            else
            {
                reply.result = 3;
                reply.message = "Acceso no Permitido";
            }

            return reply;
        }

    }




}