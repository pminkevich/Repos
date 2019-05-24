using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;


namespace Dominio
{
    public class nProveedor
    {
        //metodo insertar que llama al objeto dproveedor de la capa datos

        public static string Insertar(string pRazon_Proveedor,string pSector_Comercial,
                                       string pTipo_Documento, string pNum_Documento,
                                       string pDireccion, string pTelefono,
                                       string pEmail, string pUrl)
        {
            DProveedor OBJProveedor= new DProveedor();
            OBJProveedor.Razon_Social = pRazon_Proveedor;
            OBJProveedor.Sector_Comercial = pSector_Comercial;
            OBJProveedor.Tipo_Documento = pTipo_Documento;
            OBJProveedor.Num_Documento = pNum_Documento;
            OBJProveedor.Direccion = pDireccion;
            OBJProveedor.Telefono = pTelefono;
            OBJProveedor.Email = pEmail;
            OBJProveedor.Url = pUrl;

            return OBJProveedor.Insertar(OBJProveedor);
        }
        //Metodo Editar que llama instancia el objeto dproveedor de la capa datos

        public static string Editar(int pIdproveedor,string pRazon_Proveedor, string pSector_Comercial,
                                       string pTipo_Documento, string pNum_Documento,
                                       string pDireccion, string pTelefono,
                                       string pEmail, string pUrl)
        {
            DProveedor OBJProveedor = new DProveedor();
            OBJProveedor.Idproveedor = pIdproveedor;
            OBJProveedor.Razon_Social = pRazon_Proveedor;
            OBJProveedor.Sector_Comercial = pSector_Comercial;
            OBJProveedor.Tipo_Documento = pTipo_Documento;
            OBJProveedor.Num_Documento = pNum_Documento;
            OBJProveedor.Direccion = pDireccion;
            OBJProveedor.Telefono = pTelefono;
            OBJProveedor.Email = pEmail;
            OBJProveedor.Url = pUrl;
            return OBJProveedor.Editar(OBJProveedor);
        }
        //Metodo Eliminar que crea un objeto del tipo dproveedor

        public static string Eliminar(int pIdProveedor)
        {
            DProveedor OBJProveedor = new DProveedor();
            OBJProveedor.Idproveedor = pIdProveedor;

            return OBJProveedor.Eliminar(OBJProveedor);
        }
        //Metodo mostrar de dproveedor

        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }
        //Busca por razon social crea el objeto de dproveedor, de la capa de datos
        public static DataTable BuscarRazonSocial(string pTextoaBuscar)
        {
            DProveedor OBJBuscar = new DProveedor();
            OBJBuscar.TextoBuscar = pTextoaBuscar;

            return OBJBuscar.BuscarRazonSocial(OBJBuscar);

        }
        //busca por numero de documento

        public static DataTable BuscarNumDocumento(string pTextoaBuscar)
        {
            DProveedor OBJBuscar = new DProveedor();
            OBJBuscar.TextoBuscar = pTextoaBuscar;

            return OBJBuscar.BuscarNumDocumento(OBJBuscar);

        }

    }
}
