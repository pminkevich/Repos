using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class NCliente
    {


        public static string Insertar(string pNombre, string pApellidos,
                                       string pSexo, DateTime pFechaNac, 
                                       string pTipoDocumento, string pNumDocumento,
                                       string pDireccion, string pTelefono,
                                       string pEmail)
        {
            DCliente objCliente = new DCliente();
            objCliente.Nombre = pNombre;
            objCliente.Apellido = pApellidos;
            objCliente.Sexo = pSexo;
            objCliente.FechaNacimiento = pFechaNac;
            objCliente.TipoDocumento = pTipoDocumento;
            objCliente.NumDocumento = pNumDocumento;
            objCliente.Direccion = pDireccion;
            objCliente.Telefono = pTelefono;
            objCliente.Email = pEmail;


            return objCliente.Insertar(objCliente);
        }
        //Metodo Editar que llama instancia el objeto dproveedor de la capa datos

        public static string Editar(int pIdcliente,string pNombre, string pApellidos,
                                       string pSexo, DateTime pFechaNac,
                                       string pTipoDocumento, string pNumDocumento,
                                       string pDireccion, string pTelefono,
                                       string pEmail)
        {
            DCliente objCliente = new DCliente();
            objCliente.Idcliente = pIdcliente;
            objCliente.Nombre = pNombre;
            objCliente.Apellido = pApellidos;
            objCliente.Sexo = pSexo;
            objCliente.FechaNacimiento = pFechaNac;
            objCliente.TipoDocumento = pTipoDocumento;
            objCliente.NumDocumento = pNumDocumento;
            objCliente.Direccion = pDireccion;
            objCliente.Telefono = pTelefono;
            objCliente.Email = pEmail;

            return objCliente.Editar(objCliente);
        }
        //Metodo Eliminar que crea un objeto del tipo dproveedor

        public static string Eliminar(int pIdCliente)
        {
           DCliente objCliente = new DCliente();
            objCliente.Idcliente = pIdCliente;

            return objCliente.Eliminar(objCliente);
        }
        //Metodo mostrar de dproveedor

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }
        //Busca por razon social crea el objeto de dproveedor, de la capa de datos
        public static DataTable BuscarApellidos(string pTextoaBuscar)
        {
           DCliente objCliente = new DCliente();
            objCliente.TextoBuscar = pTextoaBuscar;

            return objCliente.BuscarApellidos(objCliente);

        }
        //busca por numero de documento

        public static DataTable BuscarNumDocumento(string pTextoaBuscar)
        {
            DCliente objCliente = new DCliente();
            objCliente.TextoBuscar = pTextoaBuscar;


            return objCliente.BuscarNumDocumento(objCliente);

        }
    }
}
