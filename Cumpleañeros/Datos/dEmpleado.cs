using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class dEmpleado
    {
        #region"Atributos"
        private int idempleado;
        private int idcargo;
        private int idarea;
        private string nombre;
        private string apellido;
        private string email;
        private DateTime fecha_nacimiento;
        private byte[] imagen;
        private string textobuscar;

        public int Idempleado { get => idempleado; set => idempleado = value; }
        public int Idcargo { get => idcargo; set => idcargo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public string Textobuscar { get => textobuscar; set => textobuscar = value; }
        public int Idarea { get => idarea; set => idarea = value; }
        #endregion
        #region"Constructor"
        public dEmpleado()
        {

        }
        #endregion

        #region"Metodos"
        //Metodo insertar
        public string Insertar(dEmpleado Empleado)
        {
            string rpta = "";
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Conexion.Cn;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spinsertar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdempleado = new SqlParameter();
                parIdempleado.ParameterName = "@Idempleado";
                parIdempleado.SqlDbType = SqlDbType.Int;
                parIdempleado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdempleado);

                SqlParameter parIdcargo = new SqlParameter();
                parIdcargo.ParameterName = "@Idcargo";
                parIdcargo.SqlDbType = SqlDbType.Int;
                parIdcargo.Value = Empleado.idcargo;
                cmd.Parameters.Add(parIdcargo);

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Value = Empleado.Idarea;
                cmd.Parameters.Add(parIdarea);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Empleado.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter();
                parApellido.ParameterName = "@Apellido";
                parApellido.SqlDbType = SqlDbType.VarChar;
                parApellido.Size = 50;
                parApellido.Value = Empleado.Apellido;
                cmd.Parameters.Add(parApellido);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@Email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = Empleado.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@Fecha_nacimiento";
                parFecha.SqlDbType = SqlDbType.Date;
                parFecha.Value = Empleado.Fecha_nacimiento;
                cmd.Parameters.Add(parFecha);

                SqlParameter parFoto = new SqlParameter();
                parFoto.ParameterName = "@Foto";
                parFoto.SqlDbType = SqlDbType.Image;
                parFoto.Value = Empleado.Imagen;
                cmd.Parameters.Add(parFoto);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso El Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return rpta;

        }

        public string Modificar(dEmpleado Empleado)
        {
            string rpta = "";
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Conexion.Cn;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spmodificar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdempleado = new SqlParameter();
                parIdempleado.ParameterName = "@Idempleado";
                parIdempleado.SqlDbType = SqlDbType.Int;
                parIdempleado.Value = Empleado.Idempleado;
                cmd.Parameters.Add(parIdempleado);

                SqlParameter parIdcargo = new SqlParameter();
                parIdcargo.ParameterName = "@Idcargo";
                parIdcargo.SqlDbType = SqlDbType.Int;
                parIdcargo.Value = Empleado.idcargo;
                cmd.Parameters.Add(parIdcargo);

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Value = Empleado.Idarea;
                cmd.Parameters.Add(parIdarea);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Empleado.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parApellido = new SqlParameter();
                parApellido.ParameterName = "@Apellido";
                parApellido.SqlDbType = SqlDbType.VarChar;
                parApellido.Size = 50;
                parApellido.Value = Empleado.Apellido;
                cmd.Parameters.Add(parApellido);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@Email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                parEmail.Value = Empleado.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@Fecha_nacimiento";
                parFecha.SqlDbType = SqlDbType.Date;
                parFecha.Value = Empleado.Fecha_nacimiento;
                cmd.Parameters.Add(parFecha);

                SqlParameter parFoto = new SqlParameter();
                parFoto.ParameterName = "@Foto";
                parFoto.SqlDbType = SqlDbType.Image;
                parFoto.Value = Empleado.Imagen;
                cmd.Parameters.Add(parFoto);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo El Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return rpta;
        }

       public string Eliminar(dEmpleado Empleado)
        {
            string rpta = "";
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Conexion.Cn;
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "speliminar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdempleado = new SqlParameter();
                parIdempleado.ParameterName = "@Idempleado";
                parIdempleado.SqlDbType = SqlDbType.Int;
                parIdempleado.Value = Empleado.Idempleado;
                cmd.Parameters.Add(parIdempleado);

                
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino El Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return rpta;
        }
        public DataTable Mostrar()
        {
            DataTable Muestradt = new DataTable("Empleados");
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spmostrar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(Muestradt);

                
            }
            catch(Exception ex)
            {
                Muestradt = null;
            }
            return Muestradt;
        }
        public DataTable Buscar(dEmpleado Empleado)
        {
            DataTable Muestradt = new DataTable("Empleado");
            SqlConnection conn= new SqlConnection();
            try
            {
                conn.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spbuscar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parTextobuscar = new SqlParameter();
                parTextobuscar.ParameterName = "@Textobuscar";
                parTextobuscar.SqlDbType = SqlDbType.VarChar;
                parTextobuscar.Size = 20;
                parTextobuscar.Value = Empleado.Textobuscar;
                cmd.Parameters.Add(parTextobuscar);

                SqlDataAdapter ad = new SqlDataAdapter();
                ad.Fill(Muestradt);





            }
            catch(Exception ex)
            {
                Muestradt = null;
            }

            return Muestradt;
        }

        #endregion
    }
}
