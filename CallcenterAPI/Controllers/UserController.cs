using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CallcenterAPI.Service;
using CallcenterAPI.Model;

namespace CallcenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuario _service;

        public UserController(IUsuario pservice)
        {
            _service = pservice;
        }

        [HttpPost]
        [Route("login")]
        public ReplyViewModel Login([FromBody] AccessViewModel DataAccess)
        {
            ReplyViewModel Resp = new ReplyViewModel();
            try
            {
                Resp = _service.login(DataAccess);
            }
            catch(Exception ex)
            {
                Resp.result = 0;
                Resp.message = "Ocurrio Un Error";
            }
   
            return Resp;
        }
    }
}