using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DTrabajador
    {
        #region"Atributos"

        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _NumDocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _Textobuscar;

        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }

        #endregion

        #region"Constructores"

        public DTrabajador()
        {

        }
        public DTrabajador(int pIdtrabajador, string pNombre, string pApellido, string pSexo, DateTime pFechaNac,
                            string pNumDocumento, string pDireccion, string pTelefono, string pEmail,
                            string pAcceso, string pUsuario, string pPassword)
        {
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Sexo = pSexo;
            this.FechaNacimiento = pFechaNac;
            this.NumDocumento = pNumDocumento;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Email = pEmail;
            this.Acceso = pAcceso;
            this.Usuario = pUsuario;
            this.Password = pPassword;
        }
        #endregion
        #region "Metodos"

        public string Insertar(DTrabajador Trabajador)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spinsertar_trabajador";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                parIdtrabajador.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdtrabajador);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 20;
                parNombre.Value = Trabajador.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter();
                parApellido.ParameterName = "@apellido";
                parApellido.SqlDbType = SqlDbType.VarChar;
                parApellido.Size = 40;
                parApellido.Value = Trabajador.Apellido;
                comando.Parameters.Add(parApellido);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = Trabajador.Sexo;
                comando.Parameters.Add(parSexo);

                SqlParameter parFechaNac = new SqlParameter();
                parFechaNac.ParameterName = "@fecha_nacimiento";
                parFechaNac.SqlDbType = SqlDbType.Date;
                parFechaNac.Value = Trabajador.FechaNacimiento;
                comando.Parameters.Add(parFechaNac);

                
                SqlParameter parNumDocumento = new SqlParameter();
                parNumDocumento.ParameterName = "@num_documento";
                parNumDocumento.SqlDbType = SqlDbType.VarChar;
                parNumDocumento.Size = 11;
                parNumDocumento.Value = Trabajador.NumDocumento;
                comando.Parameters.Add(parNumDocumento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value =Trabajador.Direccion;
                comando.Parameters.Add(parDireccion);


                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = Trabajador.Telefono;
                comando.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = Trabajador.Email;
                comando.Parameters.Add(parEmail);

                SqlParameter parAcceso = new SqlParameter();
                parAcceso.ParameterName = "@acceso";
                parAcceso.SqlDbType = SqlDbType.VarChar;
                parAcceso.Size = 50;
                parAcceso.Value = Trabajador.Acceso;
                comando.Parameters.Add(parAcceso);

                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 50;
                parUsuario.Value = Trabajador.Usuario;
                comando.Parameters.Add(parUsuario);

                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 50;
                parPassword.Value = Trabajador.Password;
                comando.Parameters.Add(parPassword);




                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";




            }
            catch (Exception Ex)
            {
                rpta = Ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return rpta;

        }
        public string Editar(DTrabajador Trabajador)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speditar_trabajador";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCliente = new SqlParameter();
                parIdCliente.ParameterName = "@idtrabajador";
                parIdCliente.SqlDbType = SqlDbType.Int;
                parIdCliente.Value = Trabajador.Idtrabajador;
                comando.Parameters.Add(parIdCliente);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 20;
                parNombre.Value = Trabajador.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter();
                parApellido.ParameterName = "@apellido";
                parApellido.SqlDbType = SqlDbType.VarChar;
                parApellido.Size = 40;
                parApellido.Value = Trabajador.Apellido;
                comando.Parameters.Add(parApellido);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = Trabajador.Sexo;
                comando.Parameters.Add(parSexo);

                SqlParameter parFechaNac = new SqlParameter();
                parFechaNac.ParameterName = "@fecha_nacimiento";
                parFechaNac.SqlDbType = SqlDbType.Date;
                parFechaNac.Value = Trabajador.FechaNacimiento;
                comando.Parameters.Add(parFechaNac);


                SqlParameter parNumDocumento = new SqlParameter();
                parNumDocumento.ParameterName = "@num_documento";
                parNumDocumento.SqlDbType = SqlDbType.VarChar;
                parNumDocumento.Size = 11;
                parNumDocumento.Value = Trabajador.NumDocumento;
                comando.Parameters.Add(parNumDocumento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = Trabajador.Direccion;
                comando.Parameters.Add(parDireccion);


                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = Trabajador.Telefono;
                comando.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = Trabajador.Email;
                comando.Parameters.Add(parEmail);

                SqlParameter parAcceso = new SqlParameter();
                parAcceso.ParameterName = "@acceso";
                parAcceso.SqlDbType = SqlDbType.VarChar;
                parAcceso.Size = 50;
                parAcceso.Value = Trabajador.Acceso;
                comando.Parameters.Add(parAcceso);

                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 50;
                parUsuario.Value = Trabajador.Usuario;
                comando.Parameters.Add(parUsuario);

                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 50;
                parPassword.Value = Trabajador.Password;
                comando.Parameters.Add(parPassword);

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";




            }
            catch (Exception Ex)
            {
                rpta = Ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return rpta;
        }
        public string Eliminar(DTrabajador Trabajador)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speliminar_trabajador";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdTrabajador = new SqlParameter();
                parIdTrabajador.ParameterName = "@idtrabajador";
                parIdTrabajador.SqlDbType = SqlDbType.Int;
                parIdTrabajador.Value = Trabajador.Idtrabajador;
                comando.Parameters.Add(parIdTrabajador);



                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";



            }
            catch (Exception Ex)
            {
                rpta = Ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return rpta;
        }
        public DataTable Mostrar()
        {
            DataTable Muestradt = new DataTable("Trabajador");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_trabajador";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);

                ad.Fill(Muestradt);



            }
            catch (Exception Ex)
            {
                Muestradt = null;

            }

            return Muestradt;

        }
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable Muestradt = new DataTable("Trabajador");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_trabajador_apellido";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Trabajador.Textobuscar;
                cmd.Parameters.Add(par);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(Muestradt);



            }
            catch (Exception Ex)
            {
                Muestradt = null;

            }

            return Muestradt;
        }
        public DataTable BuscarNumDocumento(DTrabajador Trabajador)
        {
            DataTable Muestradt = new DataTable("Trabajador");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_trabajador_num_documento";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Trabajador.Textobuscar;
                cmd.Parameters.Add(par);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(Muestradt);



            }
            catch (Exception Ex)
            {
                Muestradt = null;

            }

            return Muestradt;
        }
        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable Muestradt = new DataTable("Trabajador");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "splogin";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@usuario";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size =20;
                par.Value = Trabajador.Usuario;
                cmd.Parameters.Add(par);

                SqlParameter parp = new SqlParameter();
                parp.ParameterName = "@password";
                parp.SqlDbType = SqlDbType.VarChar;
                parp.Size = 20;
                parp.Value = Trabajador.Password;
                cmd.Parameters.Add(parp);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(Muestradt);



            }
            catch (Exception Ex)
            {
                Muestradt = null;

            }

            return Muestradt;
        }
        #endregion
    }
}
