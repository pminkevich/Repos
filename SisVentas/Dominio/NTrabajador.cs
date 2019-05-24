using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
namespace Dominio
{
   public class NTrabajador
    {

        public static string Insertar(string pNombre, string pApellidos,
                                       string pSexo, DateTime pFechaNac,
                                       string pNumDocumento,
                                       string pDireccion, string pTelefono,
                                       string pEmail, string pAcceso,string pUsuario, string pPassword)
        {
            DTrabajador objTrabajador = new DTrabajador();
            objTrabajador.Nombre = pNombre;
            objTrabajador.Apellido = pApellidos;
            objTrabajador.Sexo = pSexo;
            objTrabajador.FechaNacimiento = pFechaNac;
            objTrabajador.NumDocumento = pNumDocumento;
            objTrabajador.Direccion = pDireccion;
            objTrabajador.Telefono = pTelefono;
            objTrabajador.Email = pEmail;
            objTrabajador.Acceso = pAcceso;
            objTrabajador.Usuario = pUsuario;
            objTrabajador.Password = pPassword;


            return objTrabajador.Insertar(objTrabajador);
        }
        //Metodo Editar que llama instancia el objeto dproveedor de la capa datos

        public static string Editar(int pIdtrabajador, string pNombre, string pApellidos,
                                       string pSexo, DateTime pFechaNac,
                                       string pNumDocumento,
                                       string pDireccion, string pTelefono,
                                       string pEmail, string pAcceso, string pUsuario, string pPassword)
        {
            DTrabajador objTrabajador = new DTrabajador();
            objTrabajador.Idtrabajador = pIdtrabajador;
            objTrabajador.Nombre = pNombre;
            objTrabajador.Apellido = pApellidos;
            objTrabajador.Sexo = pSexo;
            objTrabajador.FechaNacimiento = pFechaNac;
            objTrabajador.NumDocumento = pNumDocumento;
            objTrabajador.Direccion = pDireccion;
            objTrabajador.Telefono = pTelefono;
            objTrabajador.Email = pEmail;
            objTrabajador.Acceso = pAcceso;
            objTrabajador.Usuario = pUsuario;
            objTrabajador.Password = pPassword;

            return objTrabajador.Editar(objTrabajador);
        }
        //Metodo Eliminar que crea un objeto del tipo dproveedor

        public static string Eliminar(int pIdtrabajador)
        {
            DTrabajador objTrabajador = new DTrabajador();
            objTrabajador.Idtrabajador = pIdtrabajador;

            return objTrabajador.Eliminar(objTrabajador);
        }
        //Metodo mostrar de dproveedor

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }
        //Busca por razon social crea el objeto de dproveedor, de la capa de datos
        public static DataTable BuscarApellidos(string pTextoaBuscar)
        {
            DTrabajador objTrabajador = new DTrabajador();
            objTrabajador.Textobuscar= pTextoaBuscar;

            return objTrabajador.BuscarApellidos(objTrabajador);

        }
        //busca por numero de documento

        public static DataTable BuscarNumDocumento(string pTextoaBuscar)
        {
            DTrabajador objTrabajador = new DTrabajador();
            objTrabajador.Textobuscar = pTextoaBuscar;


            return objTrabajador.BuscarNumDocumento(objTrabajador);

        }

        public static DataTable Login(string pUsuario,string pPassword)
        {
            DTrabajador objTrabajador = new DTrabajador();
            objTrabajador.Usuario = pUsuario;
            objTrabajador.Password = pPassword;



            return objTrabajador.Login(objTrabajador);

        }
    }
}
