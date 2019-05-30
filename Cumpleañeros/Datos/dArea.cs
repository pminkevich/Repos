using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class dArea
    {
        #region"Atributos"
        private int _Idarea;
        private string _Nombre;

        public int Idarea { get => _Idarea; set => _Idarea = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        #endregion

        #region"Constructor"

        public dArea()
        {

        }
        #endregion

        #region"Metodos"

        //Metodo para insertar Areas
        public string Insertar(dArea Area)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "spinsertar_area";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdarea);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Area.Nombre;
                comando.Parameters.Add(parNombre);

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";

            }
            catch(Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();

            }
            return rpta;
        }
        //Metodos para modificar Areas
        public string Modificar(dArea Area)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "speditar_area";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Value = Area.Idarea;               
                comando.Parameters.Add(parIdarea);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Area.Nombre;
                comando.Parameters.Add(parNombre);

                
                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();

            }
            return rpta;
        }
        //Metodos para Eliminar Areas
        public string Eliminar(dArea Area)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();


                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "speliminar_area";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Value = Area.Idarea;
                comando.Parameters.Add(parIdarea);

               

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();

            }
            return rpta;
        }
        //Metodo para MOstrar Areas
        public DataTable Mostrar()
        {
            DataTable Muestradt = new DataTable("Area");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_area";
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
        //Metodo para llenar un combobox
        public DataTable LlenarCombo()
        {
            DataTable Muestradt = new DataTable("Combo_Area");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "llenar_combo_area";
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
        #endregion


    }
}
