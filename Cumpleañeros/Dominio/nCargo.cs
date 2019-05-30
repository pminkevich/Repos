using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class nCargo
    {
        public static string Insertar(int pIdarea,string pNombre, int pValor)
        {
            dCargo Cargo = new dCargo();
            Cargo.Idarea = pIdarea;
            Cargo.Nombre = pNombre;
            Cargo.Valor = pValor;

            return Cargo.Insertar(Cargo);
        }
        public static string Modificar(int pIdcargo,int pIdarea, string pNombre, int pValor)
        {
            dCargo Cargo = new dCargo();
            Cargo.Idcargo = pIdcargo;
            Cargo.Idarea = pIdarea;
            Cargo.Nombre = pNombre;
            Cargo.Valor = pValor;
            

            return Cargo.Modificar(Cargo);
        }
        public static string Eliminar(int pIdcargo)
        {
            dCargo Cargo = new dCargo();
            Cargo.Idcargo = pIdcargo;


            return Cargo.Eliminar(Cargo);
        }
        public static DataTable Mostrar()
        {
            dCargo Cargo = new dCargo();

            return Cargo.Mostrar();
        }
        public static DataTable LlenarCombo(int pIdarea)
        {
            dCargo Cargo = new dCargo();
            Cargo.Idarea = pIdarea;

            return Cargo.LlenarCombo(Cargo);
        }
    }
}
