using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Model.ViewModel
{
    public class OpViewModel: SecurityViewModel
    {   
        public int idOperacion { get; set; }
        public int idPersona { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public string localidad { get; set; }
        public string calle { get; set; }
        public byte altura { get; set; }
        public byte piso { get; set; }
        public string dpto { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string comentario { get; set; }
    }
}
