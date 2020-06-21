using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Model.ViewModel
{
    public class SeguimientoViewModel:ColaViewModel
    {
        public int idSeg { get; set; }
        public string Fecha { get; set; }
        public string Hora { get;set; }
        public string Comentario { get; set; }
        public int idSegState { get; set; }
    }
}
