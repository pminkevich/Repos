using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class nArea
    {
        public static string Insertar(string pNombre)
        {
            dArea Area = new dArea();
            Area.Nombre = pNombre;
           return Area.Insertar(Area);
        }
        public static string Modificar(int pIdarea,string pNombre)
        {
            dArea Area = new dArea();
            Area.Idarea = pIdarea;
            Area.Nombre = pNombre;
        
            return Area.Modificar(Area);
        }
        public static string Eliminar(int pIdarea)
        {
            dArea Area = new dArea();
            Area.Idarea = pIdarea;
            return Area.Eliminar(Area);
        }
        public static DataTable Mostrar()
        {
            dArea Area = new dArea();

            return Area.Mostrar();
        }
        public static DataTable LlenarCombo()
        {
            dArea Area = new dArea();

            return Area.LlenarCombo();
        }
    }
}
