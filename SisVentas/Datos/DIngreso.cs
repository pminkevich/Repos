using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
   public class DIngreso
    {
        #region"Atributos"

        private int _IdIngreso;
        private int _IdTrabajador;
        private int _IdProveedor;
        private DateTime _Fecha;
        private string _TipodeComprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int IdIngreso { get => _IdIngreso; set => _IdIngreso = value; }
        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string TipodeComprobante { get => _TipodeComprobante; set => _TipodeComprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        #endregion
        #region "Constructores"

        public DIngreso()
        {

        }
        public DIngreso(int pIdIngreso, int pIdTrabajador, int pIdProveedor,
                        DateTime pFecha, string pTipoComprobante, string pSerie,
                        string pCorrelativo, decimal pIgv, string pEstado)
        {
            IdIngreso = pIdIngreso;
            IdTrabajador = pIdTrabajador;
            IdProveedor = pIdProveedor;
            Fecha = pFecha;
            TipodeComprobante = pTipoComprobante;
            Serie = pSerie;
            Correlativo = pCorrelativo;
            Igv = pIgv;
            Estado = pEstado;

        }
        #endregion

        #region "Metodos"

        //Metodo para insertar un Ingreso y sus Detalles
        public string Insertar(DIngreso Ingreso, List<DDetalleingreso> Detalle)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                //establecer la conexion
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                
                //establecer transacion
                SqlTransaction SqlTran = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = SqlTran;

                comando.CommandText = "spinsertar_ingreso";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdIngreso = new SqlParameter();
                parIdIngreso.ParameterName = "@idingreso";
                parIdIngreso.SqlDbType = SqlDbType.Int;
                parIdIngreso.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdIngreso);

                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                parIdtrabajador.Value = Ingreso.IdTrabajador;
                comando.Parameters.Add(parIdtrabajador);

                SqlParameter parIdproveedor = new SqlParameter();
                parIdproveedor.ParameterName = "@idproveedor";
                parIdproveedor.SqlDbType = SqlDbType.Int;
                parIdproveedor.Value = Ingreso.IdProveedor;
                comando.Parameters.Add(parIdproveedor);

                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.Date;
                parFecha.Value = Ingreso.Fecha;
                comando.Parameters.Add(parFecha);

                SqlParameter parTipodecomprobante = new SqlParameter();
                parTipodecomprobante.ParameterName = "@tipo_comprobante";
                parTipodecomprobante.SqlDbType = SqlDbType.VarChar;
                parTipodecomprobante.Size = 20;
                parTipodecomprobante.Value =Ingreso.TipodeComprobante;
                comando.Parameters.Add(parTipodecomprobante);

                SqlParameter parSerie = new SqlParameter();
                parSerie.ParameterName = "@serie";
                parSerie.SqlDbType = SqlDbType.VarChar;
                parSerie.Size = 4;
                parSerie.Value = Ingreso.Serie;
                comando.Parameters.Add(parSerie);

                SqlParameter parCorrelativo = new SqlParameter();
                parCorrelativo.ParameterName = "@correlativo";
                parCorrelativo.SqlDbType = SqlDbType.VarChar;
                parCorrelativo.Size = 7;
                parCorrelativo.Value = Ingreso.Correlativo;
                comando.Parameters.Add(parCorrelativo);

                SqlParameter parIgv = new SqlParameter();
                parIgv.ParameterName = "@igv";
                parIgv.SqlDbType = SqlDbType.Decimal;
                parIgv.Value = Ingreso.Igv;
                comando.Parameters.Add(parIgv);


                SqlParameter parEstado = new SqlParameter();
                parEstado.ParameterName = "@estado";
                parEstado.SqlDbType = SqlDbType.VarChar;
                parEstado.Size = 7;
                parEstado.Value = Ingreso.Estado;
                comando.Parameters.Add(parEstado);

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";
                //prosigo con los detalles de ingreso
                if (rpta == "OK")
                {
                    //obtengo el idingreso del ingreso realizado
                    this.IdIngreso = Convert.ToInt32(comando.Parameters["@idingreso"].Value);

                    foreach(DDetalleingreso Det in Detalle)
                    {
                        Det.Idingreso = this.IdIngreso;
                        //llamo al metodo insertar de la clase detalle de ingreso
                        rpta = Det.Insertar(Det, ref conexion, ref SqlTran);

                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                    }
                }
                //si todo esta bien la transaccion se concreta si no vuelve atras
                if (rpta.Equals("OK"))
                {
                    SqlTran.Commit();
                }
                else
                {
                    SqlTran.Rollback();
                }

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

        public string Anular(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spanular_ingreso";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdIngreso = new SqlParameter();
                parIdIngreso.ParameterName = "@idingreso";
                parIdIngreso.SqlDbType = SqlDbType.Int;
                parIdIngreso.Value =Ingreso.IdIngreso;
                comando.Parameters.Add(parIdIngreso);



                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Anulo el Registro";



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
            DataTable Muestradt = new DataTable("Ingreso");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_ingreso";
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
        //Metodo Buscar Nombre
        public DataTable BuscarFecha(string pTextobuscar, string pTextobuscar2)
        {
            DataTable Muestradt = new DataTable("Ingreso");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_ingreso_fecha";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = pTextobuscar;
                cmd.Parameters.Add(par);

                SqlParameter par2 = new SqlParameter();
                par2.ParameterName = "@textobuscar2";
                par2.SqlDbType = SqlDbType.VarChar;
                par2.Size = 50;
                par2.Value = pTextobuscar2;
                cmd.Parameters.Add(par2);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(Muestradt);



            }
            catch (Exception Ex)
            {
                Muestradt = null;

            }

            return Muestradt;
        }
        public DataTable MostrarDetalle(string pTextobuscar)
        {
            DataTable Muestradt = new DataTable("Detalle_Ingreso");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_detalleingreso";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@textobuscar";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Value = pTextobuscar;
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
