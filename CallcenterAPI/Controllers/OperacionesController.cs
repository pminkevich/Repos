using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CallcenterAPI.Service;
using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;

namespace CallcenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly IOperaciones _service;
        private ReplyViewModel reply;

        public OperacionesController(IOperaciones pservice)
        {
            _service = pservice;
            reply = new ReplyViewModel();
        }
        [HttpPost]
        [Route("GoToCall")]
        public async Task<ReplyViewModel> GoToCall([FromHeader] string auth, OpViewModel operacion)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.GoToCall(IdUser, operacion))
                {
                    reply.result = 1; reply.message = "Listo para llamar";
                }
                else
                {
                    reply.result = 0; reply.message = "No se pudo Agregar a la Cola";
                }

            }
            else
            {
                reply.result = 3;
                reply.message = "Acceso no Permitido";
            }

            return reply;

        }
        [HttpGet]
        [Route("GetData")]
        public async Task<ReplyViewModel> GetData([FromHeader]string auth)
        {
            try
            {
                var idUser = _service.CheckToken(auth);
                if (idUser > 0)
                {
                    reply = await _service.GetData(idUser);
                }
                else
                {
                    reply.result = 0; reply.message = "Acceso No Permitido";
                }

            }
            catch (Exception ex)
            {
                reply.result = 0; reply.message = "Ocurrio un Error";
            }
            return reply;

        }
        

        [HttpPost]
        [Route("AddOp")]
        public async Task<ReplyViewModel> AddOp([FromHeader]string auth, OpViewModel operacion)
        {
            try
            {
                int User = _service.CheckToken(auth);
                if (User > 0)
                {
                    if ( await _service.AddOP(User, operacion))
                    {
                        reply.result = 1;reply.message = "Se Inicio la Operación";
                    }
                    else
                    {
                        reply.result = 0;reply.message = "No se Pudo Iniciar la Operación";
                    }
                       
                }
                else
                {
                    reply.result = 0;reply.message = "Acceso no Permitido";
                }
                
            }
            catch(Exception ex)
            {
                reply.result = 0;reply.message = "Ocurrio un Error";
            }

            return reply;

        }

    }
}