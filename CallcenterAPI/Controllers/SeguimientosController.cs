using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CallcenterAPI.Service;
using CallcenterAPI.Model.ViewModel;
using CallcenterAPI.Model;

namespace CallcenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientosController : ControllerBase
    {
        private readonly ISeguimiento _service;
        private ReplyViewModel reply;

        public SeguimientosController(ISeguimiento pservice)
        {
            _service = pservice;
            reply = new ReplyViewModel();
        }

        [HttpPost]
        [Route("GoToCall")]
        public async Task<ReplyViewModel> GoToCall([FromHeader] string auth, SeguimientoViewModel seguimiento)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.GoToCall(IdUser,seguimiento))
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
                    reply= await _service.GetData(idUser);
                }
                else
                {
                    reply.result = 0;reply.message = "Acceso No Permitido";
                }

            }
            catch(Exception ex)
            {
                reply.result = 0; reply.message = "Ocurrio un Error";
            }
            return reply;

        }

        [HttpPost]
        [Route("AgregarSeg")]
        public async Task<ReplyViewModel> AgregarSeg([FromHeader]string auth, SeguimientoViewModel seguimiento)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
              reply= await _service.AgregarSeg(IdUser, seguimiento);
            }
            else
            {
                reply.result = 3;
                reply.message = "Acceso no Permitido";
            }

            return reply;

        }
        [HttpPut]
        [Route("UpdateSeg")]
        public async Task<ReplyViewModel> UpdateSeg([FromHeader]string auth, SeguimientoViewModel seguimiento)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.UpdateSeg(seguimiento))
                {
                    reply.result = 1; reply.message = "Se Actualizo el seguimiento";
                }
                else
                {
                    reply.result = 0; reply.message = "No se pudo Actualizar el seguimiento, intente mas tarde";
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