using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class DVenta
    {
        #region"Atributos"
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_comprobante;
        private string _Serie;
        private string _Correlativo;
        private Decimal _Igv;

        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_comprobante { get => _Tipo_comprobante; set => _Tipo_comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        #endregion

        #region"Constructores"

        public DVenta()
        {

        }

        public DVenta(int pIdventa,int pIdcliente,int pIdtrabajador,DateTime pFecha,
                        string pTipo_comprobante,string pSerie,string pCorrelativo,
                        decimal pIgv)
        {
            this.Idventa = pIdventa;
            this.Idcliente = pIdcliente;
            this.Idtrabajador = pIdtrabajador;
            this.Fecha = pFecha;
            this.Tipo_comprobante = pTipo_comprobante;
            this.Serie = pSerie;
            this.Correlativo = pCorrelativo;
            this.Igv = pIgv;
        }
        #endregion

        #region"Metodos"
        public string DisminuirStock(int pIddetalle_ingreso,int pCantidad)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "spdisminuir_stock";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIddetalleingreso = new SqlParameter();
                parIddetalleingreso.ParameterName = "@iddetalle_ingreso";
                parIddetalleingreso.SqlDbType = SqlDbType.Int;
                parIddetalleingreso.Value = pIddetalle_ingreso;
                comando.Parameters.Add(parIddetalleingreso);

                SqlParameter parCantidad = new SqlParameter();
                parCantidad.ParameterName = "@cantidad";
                parCantidad.SqlDbType = SqlDbType.Int;
                parCantidad.Value =pCantidad;
                comando.Parameters.Add(parCantidad);



                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Stock";



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
        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
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

                comando.CommandText = "spinsertar_venta";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdventa = new SqlParameter();
                parIdventa.ParameterName = "@idventa";
                parIdventa.SqlDbType = SqlDbType.Int;
                parIdventa.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIdventa);

                SqlParameter parIdcliente = new SqlParameter();
                parIdcliente.ParameterName = "@idcliente";
                parIdcliente.SqlDbType = SqlDbType.Int;
                parIdcliente.Value = Venta.Idcliente;
                comando.Parameters.Add(parIdcliente);

                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                parIdtrabajador.Value = Venta.Idtrabajador;
                comando.Parameters.Add(parIdtrabajador);

                
                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.Date;
                parFecha.Value = Venta.Fecha;
                comando.Parameters.Add(parFecha);


                SqlParameter parTipodecomprobante = new SqlParameter();
                parTipodecomprobante.ParameterName = "@tipo_comprobante";
                parTipodecomprobante.SqlDbType = SqlDbType.VarChar;
                parTipodecomprobante.Size = 20;
                parTipodecomprobante.Value = Venta.Tipo_comprobante;
                comando.Parameters.Add(parTipodecomprobante);

                SqlParameter parSerie = new SqlParameter();
                parSerie.ParameterName = "@serie";
                parSerie.SqlDbType = SqlDbType.VarChar;
                parSerie.Size = 4;
                parSerie.Value = Venta.Serie;
                comando.Parameters.Add(parSerie);

                SqlParameter parCorrelativo = new SqlParameter();
                parCorrelativo.ParameterName = "@correlativo";
                parCorrelativo.SqlDbType = SqlDbType.VarChar;
                parCorrelativo.Size = 7;
                parCorrelativo.Value = Venta.Correlativo;
                comando.Parameters.Add(parCorrelativo);

                SqlParameter parIgv = new SqlParameter();
                parIgv.ParameterName = "@igv";
                parIgv.SqlDbType = SqlDbType.Decimal;
                parIgv.Value = Venta.Igv;
                comando.Parameters.Add(parIgv);


               

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";
                //prosigo con los detalles de ingreso
                if (rpta == "OK")
                {
                    //obtengo el idingreso del ingreso realizado
                    this.Idventa = Convert.ToInt32(comando.Parameters["@idventa"].Value);
                    

                    foreach (DDetalle_Venta Det in Detalle)
                    {
                        Det.Idventa = this.Idventa;
                        //llamo al metodo insertar de la clase detalle de ingreso
                        rpta = Det.Insertar(Det, ref conexion, ref SqlTran);

                        if (!rpta.Equals("OK"))
                        {
                            break;

                        }
                        else
                        {
                            //Actualizo el stock
                            rpta = DisminuirStock(Det.Iddetalle_ingreso, Det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
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
        //metodo eliminar
        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                conexion.Open();
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "speliminar_venta";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdVenta = new SqlParameter();
                parIdVenta.ParameterName = "@idventa";
                parIdVenta.SqlDbType = SqlDbType.Int;
                parIdVenta.Value = Venta.Idventa;
                comando.Parameters.Add(parIdVenta);



                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "OK";



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
            DataTable Muestradt = new DataTable("Venta");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_venta";
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
        //Metodo Buscar fecha
        public DataTable BuscarFecha(string pTextobuscar, string pTextobuscar2)
        {
            DataTable Muestradt = new DataTable("Venta");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_venta_fecha";
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
            DataTable Muestradt = new DataTable("Detalle_Venta");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_detalle_venta";
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
        //mostrar articulos por su nombre

        public DataTable MostrarArticuloNombre(string pTextobuscar)
        {
            DataTable Muestradt = new DataTable("Articulo");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_articulo_venta";
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

        public DataTable MostrarArticuloCodigo(string pTextobuscar)
        {
            DataTable Muestradt = new DataTable("Articulo");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Cn;
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conexion;
                cmd.CommandText = "spbuscar_articulo_venta_codigo";
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