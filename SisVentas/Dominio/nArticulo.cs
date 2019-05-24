using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;


namespace Dominio
{
    public class nArticulo
    {

        
        //Metodo Insertar Crea un obj de DArticulo de la capa de datos
        public static string Insertar(string pCodigo, string pNombre, string pDescripcion, byte[] pImagen, int pIdcategoria, int pIdpresentacion)
        {
            DArticulo OBJArticulo = new DArticulo();
            OBJArticulo.Codigo = pCodigo;
            OBJArticulo.Nombre = pNombre;
            OBJArticulo.Descripcion = pDescripcion;
            OBJArticulo.Imagen = pImagen;
            OBJArticulo.IdCategoria = pIdcategoria;
            OBJArticulo.IdPresentacion = pIdpresentacion;
            return OBJArticulo.Insertar(OBJArticulo);
            
        }
        //Metodo Editar
        public static string Editar(int pIdArticulo, string pCodigo, string pNombre, string pDescripcion, byte[] pImagen, int pIdcategoria, int pIdpresentacion)
        {
            DArticulo OBJArticulo = new DArticulo();
            OBJArticulo.IdArticulo = pIdArticulo;
            OBJArticulo.Codigo = pCodigo;
            OBJArticulo.Nombre = pNombre;
            OBJArticulo.Descripcion = pDescripcion;
            OBJArticulo.Imagen = pImagen;
            OBJArticulo.IdCategoria = pIdcategoria;
            OBJArticulo.IdPresentacion = pIdpresentacion;
            return OBJArticulo.Editar(OBJArticulo);
        }
        //Metodo Eliminar
        public static string Eliminar(int pIdArticulo)
        {
            DArticulo OBJArticulo = new DArticulo();
            OBJArticulo.IdArticulo = pIdArticulo;

            return OBJArticulo.Eliminar(OBJArticulo);
        }
        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }
        //Buscar por nombre de Articulo
        public static DataTable BuscarNombre(string pTextoaBuscar)
        {
            DArticulo OBJBuscar = new DArticulo();
            OBJBuscar.TextoBuscar = pTextoaBuscar;

            return OBJBuscar.BuscarNombre(OBJBuscar);

        }

    }
}
