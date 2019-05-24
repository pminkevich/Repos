using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class DPresentacion
    {
        #region "Atributos"
        private int _IdPresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        #endregion

        #region "Constructores"
        public DPresentacion()
        {

        }
        public DPresentacion(int pIdPresentacion, string pNombre, string pDescripcion, string pTextoBuscar)
        {
            this.IdPresentacion = pIdPresentacion;
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.TextoBuscar = pTextoBuscar;

        }
        #endregion

        #region"Metodos"
        //Metodo Insertar
        public string Insertar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spinsertar_presentacion";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdPresentacion);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Presentacion.Nombre ;
                comando.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@Descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = Presentacion.Descripcion;
                comando.Parameters.Add(parDescripcion);

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
        //Metodo Editar
        public string Editar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speditar_presentacion";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = Presentacion.IdPresentacion;
                comando.Parameters.Add(parIdPresentacion);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Presentacion.Nombre ;
                comando.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@Descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = Presentacion.Descripcion ;
                comando.Parameters.Add(parDescripcion);

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
        //Metodo Eliminar
        public string Eliminar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speliminar_presentacion";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = Presentacion.IdPresentacion;
                comando.Parameters.Add(parIdPresentacion);



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
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable Muestradt = new DataTable("presentacion");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_presentacion";
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
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable Muestradt = new DataTable("presentacion");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_presentacion_nombre";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Presentacion.TextoBuscar ;
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
