using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Model.ViewModel
{
    public class AgendaViewModel: SecurityViewModel
    {
        public int idPersona { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string comentario { get; set; }
        public int estado { get; set; }
    }
}
