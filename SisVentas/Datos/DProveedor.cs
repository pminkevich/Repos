using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class DProveedor
    {
        #region"Atributos"
        private int _Idproveedor;
        private string _Razon_Social;
        private string _Sector_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        #endregion

        #region"Constructores"

        public DProveedor()
        {

        }
        public DProveedor(int pIdproveedor, string pRazon_Social, string pSector_Comercial,
                            string pTipo_Documento, string pNum_Documento,
                            string pDireccion, string pTelefono, string pEmail,
                            string pUrl,string pTextoBuscar)
        {
            this.Idproveedor = pIdproveedor;
            this.Razon_Social = pRazon_Social;
            this.Sector_Comercial = pSector_Comercial;
            this.Tipo_Documento = pTipo_Documento;
            this.Num_Documento = pNum_Documento;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Email = pEmail;
            this.Url = pUrl;
            this.TextoBuscar = pTextoBuscar;

        }
        #endregion

        #region"Metodos"

        public string Insertar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spinsertar_proveedor";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdProveedor);

                SqlParameter parRazonSocial = new SqlParameter();
                parRazonSocial.ParameterName = "@razon_social";
                parRazonSocial.SqlDbType = SqlDbType.VarChar;
                parRazonSocial.Size = 150;
                parRazonSocial.Value = Proveedor.Razon_Social;
                comando.Parameters.Add(parRazonSocial);

                SqlParameter parSector_Comercial = new SqlParameter();
                parSector_Comercial.ParameterName = "@sector_comercial";
                parSector_Comercial.SqlDbType = SqlDbType.VarChar;
                parSector_Comercial.Size = 50;
                parSector_Comercial.Value = Proveedor.Sector_Comercial;
                comando.Parameters.Add(parSector_Comercial);

                SqlParameter parTipo_Documento = new SqlParameter();
                parTipo_Documento.ParameterName = "@tipo_documento";
                parTipo_Documento.SqlDbType = SqlDbType.VarChar;
                parTipo_Documento.Size = 20;
                parTipo_Documento.Value = Proveedor.Tipo_Documento;
                comando.Parameters.Add(parTipo_Documento);

                SqlParameter parNum_Documento = new SqlParameter();
                parNum_Documento.ParameterName = "@num_documento";
                parNum_Documento.SqlDbType = SqlDbType.VarChar;
                parNum_Documento.Size = 11;
                parNum_Documento.Value = Proveedor.Num_Documento;
                comando.Parameters.Add(parNum_Documento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = Proveedor.Direccion;
                comando.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = Proveedor.Telefono;
                comando.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 10;
                parEmail.Value = Proveedor.Telefono;
                comando.Parameters.Add(parEmail);


                SqlParameter parUrl = new SqlParameter();
                parUrl.ParameterName = "@url";
                parUrl.SqlDbType = SqlDbType.VarChar;
                parUrl.Size = 100;
                parUrl.Value = Proveedor.Telefono;
                comando.Parameters.Add(parUrl);




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
        public string Editar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {

                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speditar_proveedor";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Value = Proveedor.Idproveedor;
                comando.Parameters.Add(parIdProveedor);

                SqlParameter parRazonSocial = new SqlParameter();
                parRazonSocial.ParameterName = "@razon_social";
                parRazonSocial.SqlDbType = SqlDbType.VarChar;
                parRazonSocial.Size = 150;
                parRazonSocial.Value = Proveedor.Razon_Social;
                comando.Parameters.Add(parRazonSocial);

                SqlParameter parSector_Comercial = new SqlParameter();
                parSector_Comercial.ParameterName = "@sector_comercial";
                parSector_Comercial.SqlDbType = SqlDbType.VarChar;
                parSector_Comercial.Size = 50;
                parSector_Comercial.Value = Proveedor.Sector_Comercial;
                comando.Parameters.Add(parSector_Comercial);

                SqlParameter parTipo_Documento = new SqlParameter();
                parTipo_Documento.ParameterName = "@tipo_documento";
                parTipo_Documento.SqlDbType = SqlDbType.VarChar;
                parTipo_Documento.Size = 20;
                parTipo_Documento.Value = Proveedor.Tipo_Documento;
                comando.Parameters.Add(parTipo_Documento);

                SqlParameter parNum_Documento = new SqlParameter();
                parNum_Documento.ParameterName = "@num_documento";
                parNum_Documento.SqlDbType = SqlDbType.VarChar;
                parNum_Documento.Size = 11;
                parNum_Documento.Value = Proveedor.Num_Documento;
                comando.Parameters.Add(parNum_Documento);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                parDireccion.Value = Proveedor.Direccion;
                comando.Parameters.Add(parDireccion);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                parTelefono.Value = Proveedor.Telefono;
                comando.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 10;
                parEmail.Value = Proveedor.Telefono;
                comando.Parameters.Add(parEmail);


                SqlParameter parUrl = new SqlParameter();
                parUrl.ParameterName = "@url";
                parUrl.SqlDbType = SqlDbType.VarChar;
                parUrl.Size = 100;
                parUrl.Value = Proveedor.Telefono;
                comando.Parameters.Add(parUrl);

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
        public string Eliminar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speliminar_proveedor";
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@idproveedor";
                parIdProveedor.SqlDbType = SqlDbType.Int;
                parIdProveedor.Value = Proveedor.Idproveedor;
                comando.Parameters.Add(parIdProveedor);



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
            DataTable Muestradt = new DataTable("Proveedor");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_proveedor";
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
        public DataTable BuscarRazonSocial(DProveedor Proveedor)
        {
            DataTable Muestradt = new DataTable("Proveedor");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_proveedor_razon_social";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Proveedor.TextoBuscar;
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
        public DataTable BuscarNumDocumento(DProveedor Proveedor)
        {
            DataTable Muestradt = new DataTable("Proveedor");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_proveedor_num_documento";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = Proveedor.TextoBuscar;
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
