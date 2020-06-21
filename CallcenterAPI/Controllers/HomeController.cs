using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallcenterAPI.Model;
using CallcenterAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallcenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHome _service;
        private ReplyViewModel reply;

        public HomeController(IHome pservice)
        {
            this._service = pservice;
            reply = new ReplyViewModel();
        }


        [HttpGet]
        [Route("LoadHome")]
        public async Task<ReplyViewModel> LoadHome([FromHeader] string auth)
        {
           

            int IdUser = _service.CheckToken(auth);

            if (IdUser > 0)
            {
                reply =await  _service.LoadHome(IdUser);
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