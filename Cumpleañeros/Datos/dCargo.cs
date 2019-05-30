using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    

    public class dCargo
    {

        #region"Atributos"

        private int _Idcargo;
        private int _Idarea;
        private string _Nombre;
        private int _Valor;

        
        public int Idarea { get => _Idarea; set => _Idarea = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Valor { get => _Valor; set => _Valor = value; }
        public int Idcargo { get => _Idcargo; set => _Idcargo = value; }
        #endregion

        #region"Constructor"
        public dCargo()
        {

        }
        #endregion

        #region"Metodos"

        //Metodo Insertar
        public string Insertar(dCargo Cargo)
    {
        string rpta = "";
        SqlConnection conexion = new SqlConnection();
        try
        {
            conexion.ConnectionString = Conexion.Cn;
            conexion.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "spinsertar_cargo";
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parIdpuesto = new SqlParameter();
            parIdpuesto.ParameterName = "@Idcargo";
            parIdpuesto.SqlDbType = SqlDbType.Int;
            parIdpuesto.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parIdpuesto);

            SqlParameter parIdarea = new SqlParameter();
            parIdarea.ParameterName = "@Idarea";
            parIdarea.SqlDbType = SqlDbType.Int;
            parIdarea.Value = Cargo.Idarea;
            comando.Parameters.Add(parIdarea);

            SqlParameter parNombre = new SqlParameter();
            parNombre.ParameterName = "@Nombre";
            parNombre.SqlDbType = SqlDbType.VarChar;
            parNombre.Size = 50;
            parNombre.Value = Cargo.Nombre;
            comando.Parameters.Add(parNombre);

                SqlParameter parValor = new SqlParameter();
                parValor.ParameterName = "@Valor";
                parValor.SqlDbType = SqlDbType.Int;
                parValor.Value = Cargo.Valor;
                comando.Parameters.Add(parValor);

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Agregar el Registro";

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

        //Metodo para actualizar
        public string Modificar(dCargo Cargo)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "speditar_cargo";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdpuesto = new SqlParameter();
                parIdpuesto.ParameterName = "@Idcargo";
                parIdpuesto.SqlDbType = SqlDbType.Int;
                parIdpuesto.Value = Cargo.Idcargo;
                comando.Parameters.Add(parIdpuesto);

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Value = Cargo.Idarea;
                comando.Parameters.Add(parIdarea);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@Nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Cargo.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parValor = new SqlParameter();
                parValor.ParameterName = "@Valor";
                parValor.SqlDbType = SqlDbType.Int;
                parValor.Value = Cargo.Valor;
                comando.Parameters.Add(parValor);

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Actualizar el Registro";

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
        //Metodo para Eliminar
        public string Eliminar(dCargo Cargo)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "speliminar_cargo";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdpuesto = new SqlParameter();
                parIdpuesto.ParameterName = "@Idcargo";
                parIdpuesto.SqlDbType = SqlDbType.Int;
                parIdpuesto.Value = Cargo.Idcargo;
                comando.Parameters.Add(parIdpuesto);

               

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Eliminar el Registro";

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
        public DataTable Mostrar()
        {
            DataTable Muestradt = new DataTable("Cargo");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_cargo";
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
        //Metodo para llenar el combobox
        public DataTable LlenarCombo(dCargo Cargo)
        {
            DataTable Muestradt = new DataTable("Combo_Cargo");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "llenar_combo_cargo";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdarea = new SqlParameter();
                parIdarea.ParameterName = "@Idarea";
                parIdarea.SqlDbType = SqlDbType.Int;
                parIdarea.Value = Cargo.Idarea;
                cmd.Parameters.Add(parIdarea);

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
