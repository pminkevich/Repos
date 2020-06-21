using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using CallcenterAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallcenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        public readonly IAgenda _service;
        private ReplyViewModel reply;
        public AgendaController(IAgenda pservice)
        {
            this._service = pservice;
            reply = new ReplyViewModel();
        }
        [HttpPost]
        [Route("GoToCall")]
        public async Task<ReplyViewModel> GoToCall([FromHeader]string auth, AgendaViewModel agenda)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.GoToCall(IdUser, agenda))
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
        public  ReplyViewModel GetData([FromHeader]string auth)
        {
            try
            {
                var idUser = _service.CheckToken(auth);
                if (idUser > 0)
                {
                    reply = _service.GetData(idUser);
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

        [HttpPut]
        [Route("SendInfo")]
        public async Task<ReplyViewModel> SendInfo([FromHeader]string auth,[FromBody]ColaViewModel llamado)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.SendInfo(IdUser,llamado))
                {
                    reply.result = 1; reply.message = "En Breve se Enviara la Cartilla";
                }
                else
                {
                    reply.result = 0; reply.message = "No se Pudo Agendar,Intente mas Tarde";
                }

            }
            else
            {
                reply.result = 0;
                reply.message = "Acceso no Permitido";
            }

            return reply;
        }

        [HttpPut]
        [Route("CheckPeople")]
        public async Task<ReplyViewModel> CheckPeople([FromHeader]string auth, ColaViewModel llamado)
        {
            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                if (await _service.CheckPeople(IdUser, llamado))
                {
                    reply.result = 1; reply.message = "En Breve Verificaremos la Información";
                }
                else
                {
                    reply.result = 0; reply.message = "No Se Pudo Agendar,Intente mas Tarde";
                }

            }
            else
            {
                reply.result = 0;
                reply.message = "Acceso no Permitido";
            }

            return reply;
        }
    }
}