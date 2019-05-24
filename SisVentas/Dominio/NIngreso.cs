using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Dominio
{
    public class NIngreso
    {

        //Metodo Insertar Ingreso
        public static string Insertar(int pIdTrabajador,int pIdProveedor, DateTime pFecha, 
                                        string pTipo_Comprobante,string pSerie, 
                                        string pCorrelativo, Decimal pIgv, string pEstado,
                                        DataTable pDetalles)
        {
           DIngreso OBJIngreso= new DIngreso();
            OBJIngreso.IdTrabajador = pIdTrabajador;
            OBJIngreso.IdProveedor = pIdProveedor;
            OBJIngreso.Fecha = pFecha;
            OBJIngreso.TipodeComprobante = pTipo_Comprobante;
            OBJIngreso.Serie = pSerie;
            OBJIngreso.Correlativo = pCorrelativo;
            OBJIngreso.Igv = pIgv;
            OBJIngreso.Estado = pEstado;
            List<DDetalleingreso> Detalles = new List<DDetalleingreso>();
           foreach(DataRow row in pDetalles.Rows)
            {
                DDetalleingreso DetalleI = new DDetalleingreso();
                DetalleI.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                DetalleI.Preciocompra = Convert.ToDecimal(row["precio_compra"].ToString());
                DetalleI.Precioventa = Convert.ToDecimal(row["precio_venta"].ToString());
                DetalleI.Stockinicial = Convert.ToInt32(row["stock_inicial"].ToString());
                DetalleI.Stockactual = Convert.ToInt32(row["stock_inicial"].ToString());
                DetalleI.FechaProduccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                DetalleI.FechaVencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                Detalles.Add(DetalleI);

            }

            return OBJIngreso.Insertar(OBJIngreso, Detalles);
        }
        public static string Anular(int pIdIngreso)
        {
            DIngreso OBJIngreso = new DIngreso();
            OBJIngreso.IdIngreso = pIdIngreso;

            return OBJIngreso.Anular(OBJIngreso);
        }
        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
        //Buscar por nombre de categoria
        public static DataTable BuscarFechas(string pTextoaBuscar, string pTextoBuscar2)
        {
            DIngreso OBJBuscar = new DIngreso();
            

            return OBJBuscar.BuscarFecha(pTextoaBuscar,pTextoBuscar2);

        }
        public static DataTable MostrarDetalle(string pTextoaBuscar)
        {
            DIngreso OBJMostrar = new DIngreso();


            return OBJMostrar.MostrarDetalle(pTextoaBuscar);

        }
    }
}
