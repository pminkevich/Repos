using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Model.ViewModel
{
    public class ColaViewModel:SecurityViewModel
    {
        public int idLlamado { get; set; }
        public long idPersona { get; set; }
        public int idState { get; set; }
        public int idProducto { get; set; }
        public int tipouser { get; set; }
        public string nombre { get; set; }
        public string cuil { get; set; }
        public string rnos { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string telefono4 { get; set; }
        public bool? noapto { get; set; }
        public bool? conformeos { get; set; }
        public bool? aportes { get; set; }
        public string cambioOS { get; set; }
        public string producto { get; set; }


    }
}
