using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DCliente
    {
        #region "Atributos"
        private int _Idcliente;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _TipoDocumento;
        private string _NumDocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        #endregion
        #region "Constructores"
        public DCliente()
        {

        }

        public DCliente(int pIdcliente, string pNombre, string pApellido, string pSexo,
                            DateTime pFechaNac, string pTipoDocumento, string pNumDocumento,
                            string pDireccion, string pTelefono, string pEmail, string pTextoBuscar)
        {
            this.Idcliente = pIdcliente;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Sexo = pSexo;
            this.FechaNacimiento = pFechaNac;
            this.TipoDocumento = pTipoDocumento;
            this.NumDocumento = pNumDocumento;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Email = pEmail;
            this.TextoBuscar = pTextoBuscar;

        }
        #endregion

        #region "Metodos"

        public string Insertar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spinsertar_cliente";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdcliente = new SqlParameter();
                parIdcliente.ParameterName = "@idcliente";
                parIdcliente.SqlDbType = SqlDbType.Int;
                parIdcliente.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdcliente);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Cliente.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter();
                parApellido.ParameterName = "@apellido";
                parApellido.SqlDbType = SqlDbType.VarChar;
                parApellido.Size = 50;
                parApellido.Value = Cliente.Apellido;
                comando.Parameters.Add(parApellido);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = Cliente.Sexo;
                comando.Parameters.Add(parSexo);

                SqlParameter parFechaNac = new SqlParameter();
                parFechaNac.ParameterName = "@fecha_nacimiento";
                parFechaNac.SqlDbType = SqlDbType.Date;
                parFechaNac.Value = Cliente.FechaNacimiento;
                comando.Parameters.Add(parFechaNac);

                SqlParameter parTipoDocumento = new SqlParameter();
                parTipoDocumento.ParameterName = "@tipo_documento";
                parTipoDocumento.SqlDbType = SqlDbType.VarChar;
                parTipoDocumento.Size = 20;
                parTipoDocumento.Value = Cliente.TipoDocumento;
                comando.Parameters.Add(parTipoDocumento);

                SqlParameter parNumDocumento = new SqlParameter();
                parNumDocumento.ParameterName = "@num_documento";
                parNumDocumento.SqlDbType = SqlDbType.VarChar;
                parNumDocumento.Size = 11;
                parNumDocumento.Value = Cliente.NumDocumento;
                comando.Parameters.Add(parNumDocumento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = Cliente.Direccion;
                comando.Parameters.Add(parDireccion);


                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = Cliente.Email;
                comando.Parameters.Add(parEmail);




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
        public string Editar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speditar_cliente";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdCliente = new SqlParameter();
                parIdCliente.ParameterName = "@idcliente";
                parIdCliente.SqlDbType = SqlDbType.Int;
                parIdCliente.Value = Cliente.Idcliente;
                comando.Parameters.Add(parIdCliente);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Cliente.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter();
                parApellido.ParameterName = "@apellido";
                parApellido.SqlDbType = SqlDbType.VarChar;
                parApellido.Size = 50;
                parApellido.Value = Cliente.Apellido;
                comando.Parameters.Add(parApellido);

                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                parSexo.Value = Cliente.Sexo;
                comando.Parameters.Add(parSexo);

                SqlParameter parFechaNac = new SqlParameter();
                parFechaNac.ParameterName = "@fecha_nacimiento";
                parFechaNac.SqlDbType = SqlDbType.Date;
                parFechaNac.Value = Cliente.FechaNacimiento;
                comando.Parameters.Add(parFechaNac);

                SqlParameter parTipoDocumento = new SqlParameter();
                parTipoDocumento.ParameterName = "@tipo_documento";
                parTipoDocumento.SqlDbType = SqlDbType.VarChar;
                parTipoDocumento.Size = 20;
                parTipoDocumento.Value = Cliente.TipoDocumento;
                comando.Parameters.Add(parTipoDocumento);

                SqlParameter parNumDocumento = new SqlParameter();
                parNumDocumento.ParameterName = "@num_documento";
                parNumDocumento.SqlDbType = SqlDbType.VarChar;
                parNumDocumento.Size = 11;
                parNumDocumento.Value = Cliente.NumDocumento;
                comando.Parameters.Add(parNumDocumento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = Cliente.Direccion;
                comando.Parameters.Add(parDireccion);


                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = Cliente.Email;
                comando.Parameters.Add(parEmail);

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
        public string Eliminar(DCliente Cliente)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speliminar_cliente";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdCliente = new SqlParameter();
                parIdCliente.ParameterName = "@idcliente";
                parIdCliente.SqlDbType = SqlDbType.Int;
                parIdCliente.Value = Cliente.Idcliente;
                comando.Parameters.Add(parIdCliente);



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
            DataTable Muestradt = new DataTable("Cliente");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_cliente";
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
        public DataTable BuscarApellidos(DCliente Cliente)
        {
            DataTable Muestradt = new DataTable("Cliente");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_cliente_apellido";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value =Cliente.TextoBuscar;
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
        public DataTable BuscarNumDocumento(DCliente Cliente)
        {
            DataTable Muestradt = new DataTable("Cliente");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_cliente_num_documento";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Cliente.TextoBuscar;
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
        #endregion
    }
}
