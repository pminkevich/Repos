using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
namespace Dominio
{
    public class nEmpleado
    {
        #region"Atributos"
        private dEmpleado Empleado;
        #endregion

        #region"Constructores"
        public nEmpleado(int pIdempleado,int pIdcargo,int pIdarea,string pNombre,string pApellido,
                        string pEmail, DateTime pFechaI, DateTime pFecha, byte[] pImagen)
        {
            Empleado = new dEmpleado();
            Empleado.Idempleado = pIdempleado;
            Empleado.Idcargo = pIdcargo;
            Empleado.Idarea = pIdarea;
            Empleado.Nombre = pNombre;
            Empleado.Apellido = pApellido;
            Empleado.Email = pEmail;
            Empleado.Fecha_ingreso = pFechaI;
            Empleado.Fecha_nacimiento = pFecha;
            Empleado.Imagen = pImagen;
        }
        public nEmpleado(int pIdcargo, int pIdarea, string pNombre, string pApellido,
                        string pEmail,DateTime pFechaI, DateTime pFecha, byte[] pImagen)
        {
            Empleado = new dEmpleado();
            Empleado.Idcargo = pIdcargo;
            Empleado.Idarea = pIdarea;
            Empleado.Nombre = pNombre;
            Empleado.Apellido = pApellido;
            Empleado.Email = pEmail;
            Empleado.Fecha_ingreso = pFechaI;
            Empleado.Fecha_nacimiento = pFecha;
            Empleado.Imagen = pImagen;
        }
        public nEmpleado(int pIdempleado)
        {
            Empleado = new dEmpleado();
            Empleado.Idempleado = pIdempleado;
        }
        public nEmpleado(string pTextobuscar)
        {
            Empleado = new dEmpleado();
            Empleado.Textobuscar = pTextobuscar;
        }
        public nEmpleado()
        {
            Empleado = new dEmpleado();

        }
        #endregion

        #region"Metodos"
        public string Insertar()
        {
            return Empleado.Insertar(Empleado);
        }

        public string Modificar()
        {
            return Empleado.Modificar(Empleado);
        }

        public string Eliminar()
        {
            return Empleado.Eliminar(Empleado);
        }

        public DataTable Mostrar()
        {
          
            return Empleado.Mostrar();
        }
        public DataTable Buscar()
        {
            return Empleado.Buscar(Empleado);
        }

        #endregion
    }
}
