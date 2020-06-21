using CallcenterAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public interface IUsuario
    {

        ReplyViewModel login(AccessViewModel DataAcess);
        string CreateToken(int IdUser);

    }
}
