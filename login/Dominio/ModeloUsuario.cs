using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;


namespace Dominio
{
    public class ModeloUsuario
    {
        Usuario Usuario = new Usuario();

        public bool LoginUser(string pUsuario, string pClave)
        {
            return Usuario.Login(pUsuario, pClave);
        }

    }
}
