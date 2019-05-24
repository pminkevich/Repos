using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Datos
{
    public class DArticulo
    {

        #region "Atributos"
        private int _IdArticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _IdCategoria;
        private int _IdPresentacion;
        private string _TextoBuscar;

        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        #endregion
        #region "Constructores"
        public DArticulo()
        {

        }
        public DArticulo(int pIdarticulo, string pCodigo, string pNombre, string pDescripcion, byte[] pImagen, int pIdecategoria, int pIdpresentacion, string pTextobuscar)
        {
            this.IdArticulo = pIdarticulo;
            this.Codigo = pCodigo;
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.Imagen = pImagen;
            this.IdCategoria = pIdecategoria;
            this.IdPresentacion = pIdpresentacion;
            this.TextoBuscar = pTextobuscar;

        }
        #endregion

        #region "Metodos"
        //Metodo Insertar
        public string Insertar(DArticulo  Articulo)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spinsertar_articulo";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdArticulo);

                SqlParameter parCodigo = new SqlParameter();
                parCodigo.ParameterName = "@codigo";
                parCodigo.SqlDbType = SqlDbType.VarChar;
                parCodigo.Size = 50;
                parCodigo.Value = Articulo.Codigo ;
                comando.Parameters.Add(parCodigo);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Articulo.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = Articulo.Descripcion ;
                comando.Parameters.Add(parDescripcion);

                SqlParameter parImagen = new SqlParameter();
                parImagen.ParameterName = "@imagen";
                parImagen.SqlDbType = SqlDbType.Image;
                parImagen.Value = Articulo.Imagen ;
                comando.Parameters.Add(parImagen);

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Value = Articulo.IdCategoria;
                comando.Parameters.Add(parIdCategoria);

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = Articulo.IdPresentacion ;
                comando.Parameters.Add(parIdPresentacion);



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
        public string Editar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speditar_articulo";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = Articulo.IdArticulo;
                comando.Parameters.Add(parIdArticulo);

                SqlParameter parCodigo = new SqlParameter();
                parCodigo.ParameterName = "@codigo";
                parCodigo.SqlDbType = SqlDbType.VarChar;
                parCodigo.Size = 50;
                parCodigo.Value = Articulo.Codigo;
                comando.Parameters.Add(parCodigo);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Articulo.Nombre;
                comando.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = Articulo.Descripcion;
                comando.Parameters.Add(parDescripcion);

                SqlParameter parImagen = new SqlParameter();
                parImagen.ParameterName = "@imagen";
                parImagen.SqlDbType = SqlDbType.Image;
                parImagen.Value = Articulo.Imagen;
                comando.Parameters.Add(parImagen);

                SqlParameter parIdCategoria = new SqlParameter();
                parIdCategoria.ParameterName = "@idcategoria";
                parIdCategoria.SqlDbType = SqlDbType.Int;
                parIdCategoria.Value = Articulo.IdCategoria;
                comando.Parameters.Add(parIdCategoria);

                SqlParameter parIdPresentacion = new SqlParameter();
                parIdPresentacion.ParameterName = "@idpresentacion";
                parIdPresentacion.SqlDbType = SqlDbType.Int;
                parIdPresentacion.Value = Articulo.IdPresentacion;
                comando.Parameters.Add(parIdPresentacion);

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
        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speliminar_articulo";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdArticulo = new SqlParameter();
                parIdArticulo.ParameterName = "@idarticulo";
                parIdArticulo.SqlDbType = SqlDbType.Int;
                parIdArticulo.Value = Articulo.IdArticulo ;
                comando.Parameters.Add(parIdArticulo);



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
            DataTable Muestradt = new DataTable("articulo");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_articulo";
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
        //Metodo Buscar por nombre
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable Muestradt = new DataTable("presentacion");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_articulo_nombre";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Articulo.TextoBuscar ;
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
