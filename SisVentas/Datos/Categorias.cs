using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace Datos
{
    public class Categorias
    {
        #region "Atributos"
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        #endregion
        #region "Constructores"
        public Categorias()
        {

        }
        //Constructor con Parametros
        public Categorias(int pIdcategoria, string pNombre, string pDescripcion, string pTextoBuscar)
        {
            this.Idcategoria = pIdcategoria;
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.TextoBuscar = pTextoBuscar;

        }
        #endregion
        #region "Metodos"
        //Metodo para insertar categorias
        public string Insertar(Categorias Categoria)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                   
                        comando.Connection = conexion;
                        comando.CommandText = "spinsertar_categoria";
                        comando.CommandType = CommandType.StoredProcedure;

                        SqlParameter parIdCategoria = new SqlParameter();
                        parIdCategoria.ParameterName = "@idcategoria";
                        parIdCategoria.SqlDbType = SqlDbType.Int;
                        parIdCategoria.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(parIdCategoria);

                        SqlParameter parNombre = new SqlParameter();
                        parNombre.ParameterName = "@Nombre";
                        parNombre.SqlDbType = SqlDbType.VarChar;
                        parNombre.Size = 50;
                        parNombre.Value = Categoria.Nombre;
                        comando.Parameters.Add(parNombre);

                        SqlParameter parDescripcion = new SqlParameter();
                        parDescripcion.ParameterName = "@Descripcion";
                        parDescripcion.SqlDbType = SqlDbType.VarChar;
                        parDescripcion.Size = 256;
                        parDescripcion.Value = Categoria.Descripcion;
                        comando.Parameters.Add(parDescripcion);

                        rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";




        }
            catch(Exception Ex)
            {
                rpta = Ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return rpta;

        }
        //Metodo Editar Categorias
        public string Editar(Categorias Categoria)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                  
                        comando.Connection = conexion;
                        comando.CommandText = "speditar_categoria";
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlParameter parIdCategoria = new SqlParameter();
                        parIdCategoria.ParameterName = "@idcategoria";
                        parIdCategoria.SqlDbType = SqlDbType.Int;
                        parIdCategoria.Value = Categoria.Idcategoria;
                        comando.Parameters.Add(parIdCategoria);

                        SqlParameter parNombre = new SqlParameter();
                        parNombre.ParameterName = "@Nombre";
                        parNombre.SqlDbType = SqlDbType.VarChar;
                        parNombre.Size = 50;
                        parNombre.Value = Categoria.Nombre;
                        comando.Parameters.Add(parNombre);

                        SqlParameter parDescripcion = new SqlParameter();
                        parDescripcion.ParameterName = "@Descripcion";
                        parDescripcion.SqlDbType = SqlDbType.VarChar;
                        parDescripcion.Size = 256;
                        parDescripcion.Value = Categoria.Descripcion;
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
        //Metodo Eliminar Categorias
        public string Eliminar(Categorias Categoria)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                    SqlCommand comando = new SqlCommand();
                  
                        comando.Connection = conexion;
                        comando.CommandText = "speliminar_categoria";
                        comando.CommandType = CommandType.StoredProcedure;
                        SqlParameter parIdCategoria = new SqlParameter();
                        parIdCategoria.ParameterName = "@idcategoria";
                        parIdCategoria.SqlDbType = SqlDbType.Int;
                        parIdCategoria.Value = Categoria.Idcategoria;
                        comando.Parameters.Add(parIdCategoria);

                        

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
            DataTable Muestradt = new DataTable("Categoria");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                    
                        cmd.Connection = conexion;
                        cmd.CommandText = "spmostrar_categoria";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        
                        ad.Fill(Muestradt);



        }
            catch(Exception Ex)
            {
                Muestradt = null;

            }
            
            return Muestradt;

        }
        //Metodo Buscar Nombre
        public DataTable BuscarNombre(Categorias Categoria)
        {
            DataTable Muestradt = new DataTable("Categoria");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                   
                        cmd.Connection = conexion;
                        cmd.CommandText = "spbuscar_categoria";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter par = new SqlParameter();
                        par.ParameterName = "@textobuscar";
                        par.SqlDbType = SqlDbType.VarChar;
                        par.Size = 50;
                        par.Value = Categoria.TextoBuscar;
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
