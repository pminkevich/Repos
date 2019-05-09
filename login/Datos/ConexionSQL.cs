using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public abstract class ConexionSQL
    {
        private readonly string cadenadeconexion;

        public ConexionSQL()
        {
            cadenadeconexion = "server=(localdb)\\MSSQLLocalDB; database=Estacionamiento;integrated security=true";
        }
        protected SqlConnection GetConexion()
        {
            return new SqlConnection(cadenadeconexion);

        }
    }
}
