using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Dominio
{
    public class nPresentacion
    {
        //Metodo Insertar instancia a un objeto de dpresentacion y llama a su metodo
        //insertar
        public static string Insertar(string pNombre, string pDescripcion)
        {
            DPresentacion  OBJPresentacion = new DPresentacion();
            OBJPresentacion.Nombre = pNombre;
            OBJPresentacion.Descripcion = pDescripcion;
            return OBJPresentacion.Insertar(OBJPresentacion);
        }
        //Metodo Editar crea un tipo dpresentacion de la capa de datos
        public static string Editar(int pIdPresentacion, string pNombre, string pDescripcion)
        {
            DPresentacion OBJPresentacion = new DPresentacion();
            OBJPresentacion.IdPresentacion  = pIdPresentacion;
            OBJPresentacion.Nombre = pNombre;
            OBJPresentacion.Descripcion = pDescripcion;
            return OBJPresentacion.Editar(OBJPresentacion);
        }
        //Elimina una presentacion creando un obj de tipo dpresentacion
        public static string Eliminar(int pIdPresentacion)
        {
            DPresentacion OBJPresentacion = new DPresentacion();
            OBJPresentacion.IdPresentacion = pIdPresentacion;

            return OBJPresentacion.Eliminar(OBJPresentacion);
        }
        //Mostrar 
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
        //Buscar por nombre
        public static DataTable BuscarNombre(string pTextoaBuscar)
        {
            DPresentacion OBJBuscar = new DPresentacion();
            OBJBuscar.TextoBuscar = pTextoaBuscar;

            return OBJBuscar.BuscarNombre(OBJBuscar);

        }
    }
}
