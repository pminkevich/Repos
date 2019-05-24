using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
   public class DDetalle_Venta
    {

        #region"Atributos"

        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private Decimal _Precio_venta;
        private Decimal _Descuento;

        public int Iddetalle_venta { get => _Iddetalle_venta; set => _Iddetalle_venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }

        #endregion

        #region"Constructores"

        public DDetalle_Venta()
        {

        }
        public DDetalle_Venta(int pIddetalle_venta, int pIdventa, int pIddetalle_ingreso,
                            int pCantidad, Decimal pPrecio_venta, Decimal pDescuento)
        {
            this.Iddetalle_venta = pIddetalle_venta;
            this.Idventa = pIdventa;
            this.Iddetalle_ingreso = pIddetalle_ingreso;
            this.Cantidad = pCantidad;
            this.Precio_venta = pPrecio_venta;
            this.Descuento = pDescuento;
         
        }
        #endregion

        #region"Metodos"

        public string Insertar(DDetalle_Venta DetalleVenta, ref SqlConnection SqlCon,
            ref SqlTransaction SqlTrans)
        {
            string rpta = "";

            try
            {

                SqlCommand comando = new SqlCommand();

                comando.Connection = SqlCon;
                comando.Transaction = SqlTrans;
                comando.CommandText = "spinsertar_detalle_venta";
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parIddetalleventa = new SqlParameter();
                parIddetalleventa.ParameterName = "@iddetalle_venta";
                parIddetalleventa.SqlDbType = SqlDbType.Int;
                parIddetalleventa.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parIddetalleventa);

                SqlParameter parIddventa = new SqlParameter();
                parIddventa.ParameterName = "@idventa";
                parIddventa.SqlDbType = SqlDbType.Int;
                parIddventa.Value = DetalleVenta.Idventa;
                comando.Parameters.Add(parIddventa);


                SqlParameter parIddetalleingreso = new SqlParameter();
                parIddetalleingreso.ParameterName = "@iddetalle_ingreso";
                parIddetalleingreso.SqlDbType = SqlDbType.Int;
                parIddetalleingreso.Value = DetalleVenta.Iddetalle_ingreso;
                comando.Parameters.Add(parIddetalleingreso);

                SqlParameter parCantidad = new SqlParameter();
                parCantidad.ParameterName = "@cantidad";
                parCantidad.SqlDbType = SqlDbType.Int;
                parCantidad.Value = DetalleVenta.Cantidad;
                comando.Parameters.Add(parCantidad);

                SqlParameter parPrecioVenta = new SqlParameter();
                parPrecioVenta.ParameterName = "@precio_venta";
                parPrecioVenta.SqlDbType = SqlDbType.Money;
                parPrecioVenta.Value = DetalleVenta.Precio_venta;
                comando.Parameters.Add(parPrecioVenta);

                SqlParameter parDescuento= new SqlParameter();
                parDescuento.ParameterName = "@descuento";
                parDescuento.SqlDbType = SqlDbType.Money;
                parDescuento.Value = DetalleVenta.Descuento;
                comando.Parameters.Add(parDescuento);

                

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
