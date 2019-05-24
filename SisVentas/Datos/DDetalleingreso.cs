using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DDetalleingreso
    {

        #region "Atributos"
        private int _Iddetalleingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Preciocompra;
        private decimal _Precioventa;
        private int _Stockinicial;
        private int _Stockactual;
        private DateTime _FechaProduccion;
        private DateTime _FechaVencimiento;

        public int Iddetalleingreso { get => _Iddetalleingreso; set => _Iddetalleingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Preciocompra { get => _Preciocompra; set => _Preciocompra = value; }
        public decimal Precioventa { get => _Precioventa; set => _Precioventa = value; }
        public int Stockinicial { get => _Stockinicial; set => _Stockinicial = value; }
        public int Stockactual { get => _Stockactual; set => _Stockactual = value; }
        public DateTime FechaProduccion { get => _FechaProduccion; set => _FechaProduccion = value; }
        public DateTime FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }
        #endregion
        #region "Constructores"
        public DDetalleingreso()
        {

        }
        public DDetalleingreso(int pIdDetalleIngreso, int pIdIngreso, int pIdArticulo,
                                decimal pPrecioCompra, decimal pPrecioVenta, 
                                 int pStockInicial, int pStockActual, 
                                 DateTime pFechaProduccion, DateTime pFechaVencimiento)
        {
            this.Iddetalleingreso = pIdDetalleIngreso;
            this.Idingreso = pIdIngreso;
            this.Idarticulo = pIdArticulo;
            this.Preciocompra = pPrecioCompra;
            this.Precioventa = pPrecioVenta;
            this.Stockinicial = pStockInicial;
            this.Stockactual = pStockActual;
            this.FechaProduccion = pFechaProduccion;
            this.FechaVencimiento = pFechaVencimiento;


        }
        #endregion

        #region "Metodos"

        public string Insertar(DDetalleingreso Detalle, ref SqlConnection SqlCon,
            ref SqlTransaction SqlTrans)
        {
            string rpta = "";
            
            try
            {
                
                SqlCommand comando = new SqlCommand();

                comando.Connection = SqlCon;
                comando.Transaction = SqlTrans;
                comando.CommandText = "spinsertar_detalle_ingreso";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIddetalleingreso = new SqlParameter();
                parIddetalleingreso.ParameterName = "@iddetalleingreso";
                parIddetalleingreso.SqlDbType = SqlDbType.Int;
                parIddetalleingreso.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIddetalleingreso);

                SqlParameter parIdingreso = new SqlParameter();
                parIdingreso.ParameterName = "@idingreso";
                parIdingreso.SqlDbType = SqlDbType.Int;
                parIdingreso.Value = Detalle.Idingreso;
                comando.Parameters.Add(parIdingreso);

                SqlParameter parIdarticulo = new SqlParameter();
                parIdarticulo.ParameterName = "@idarticulo";
                parIdarticulo.SqlDbType = SqlDbType.Int;
                parIdarticulo.Value = Detalle.Idarticulo;
                comando.Parameters.Add(parIdarticulo);

                SqlParameter parPrecioCompra = new SqlParameter();
                parPrecioCompra.ParameterName = "@precio_compra";
                parPrecioCompra.SqlDbType = SqlDbType.Money;
                parPrecioCompra.Value = Detalle.Preciocompra;
                comando.Parameters.Add(parPrecioCompra);

                SqlParameter parPrecioVenta = new SqlParameter();
                parPrecioVenta.ParameterName = "@precio_venta";
                parPrecioVenta.SqlDbType = SqlDbType.Money;
                parPrecioVenta.Value = Detalle.Precioventa;
                comando.Parameters.Add(parPrecioVenta);

                SqlParameter parsStockActual=new SqlParameter();
                parsStockActual.ParameterName = "@stock_actual";
                parsStockActual.SqlDbType = SqlDbType.Int;
                parsStockActual.Value = Detalle.Stockactual;
                comando.Parameters.Add(parsStockActual);

                SqlParameter parsStockInicial = new SqlParameter();
                parsStockInicial.ParameterName = "@stock_inicial";
                parsStockInicial.SqlDbType = SqlDbType.Int;
                parsStockInicial.Value = Detalle.Stockinicial;
                comando.Parameters.Add(parsStockInicial);

                SqlParameter parFechaProd = new SqlParameter();
                parFechaProd.ParameterName = "@fecha_produccion";
                parFechaProd.SqlDbType = SqlDbType.Date;
                parFechaProd.Value = Detalle.FechaProduccion;
                comando.Parameters.Add(parFechaProd);

                SqlParameter parFechaVenc = new SqlParameter();
                parFechaVenc.ParameterName = "@fecha_vencimiento";
                parFechaVenc.SqlDbType = SqlDbType.Date;
                parFechaVenc.Value = Detalle.FechaVencimiento;
                comando.Parameters.Add(parFechaVenc);

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";




            }
            catch (Exception Ex)
            {
                rpta = Ex.Message;
            }
            
            return rpta;

        }
        #endregion
    }
}
