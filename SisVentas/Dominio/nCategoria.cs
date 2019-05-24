using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;


namespace Dominio
{
    public class nCategoria
    {
        //Metodo Insertar crea un obj del tipo categorias
        public static string Insertar(string pNombre, string pDescripcion)
        {
            Categorias  OBJCategoria = new Categorias();
            OBJCategoria.Nombre = pNombre;
            OBJCategoria.Descripcion = pDescripcion;
            return OBJCategoria.Insertar(OBJCategoria);
        }
        //Metodo editar instancia a Categorias de la capa de datos
        public static string Editar(int pIdCategoria,string pNombre, string pDescripcion)
        {
            Categorias OBJCategoria = new Categorias();
            OBJCategoria.Idcategoria = pIdCategoria;
            OBJCategoria.Nombre = pNombre;
            OBJCategoria.Descripcion = pDescripcion;
            return OBJCategoria.Editar(OBJCategoria);
        }
        //Metodo Eliminar Obj de Categorias
        public static string Eliminar(int pIdCategoria)
        {
            Categorias OBJCategoria = new Categorias();
            OBJCategoria.Idcategoria = pIdCategoria;
            
            return OBJCategoria.Eliminar(OBJCategoria);
        }
        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new Categorias().Mostrar();
        }
        //Buscar por nombre de categoria
        public static DataTable BuscarNombre(string pTextoaBuscar)
        {
            Categorias OBJBuscar = new Categorias();
            OBJBuscar.TextoBuscar = pTextoaBuscar;

            return OBJBuscar.BuscarNombre(OBJBuscar);

        }
    }
}
