using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class NVenta
    {
        public static string Insertar(int pIdcliente, int pIdtrabajador, DateTime pFecha,
                                        string pTipo_Comprobante, string pSerie,
                                        string pCorrelativo, Decimal pIgv,
                                        DataTable pDetalles)
        {
            DVenta OBJVenta = new DVenta();
            OBJVenta.Idcliente = pIdcliente;
            OBJVenta.Idtrabajador = pIdtrabajador;
            OBJVenta.Fecha = pFecha;
            OBJVenta.Tipo_comprobante = pTipo_Comprobante;
            OBJVenta.Serie = pSerie;
            OBJVenta.Correlativo = pCorrelativo;
            OBJVenta.Igv = pIgv;
           
            List<DDetalle_Venta> Detalles = new List<DDetalle_Venta>();

            foreach (DataRow row in pDetalles.Rows)
            {
                DDetalle_Venta DetalleI = new DDetalle_Venta();
                
                DetalleI.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                DetalleI.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                DetalleI.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                DetalleI.Descuento = Convert.ToDecimal(row["descuento"].ToString());
                Detalles.Add(DetalleI);

            }

            return OBJVenta.Insertar(OBJVenta, Detalles);
        }
        public static string Eliminar(int pIdVenta)
        {
            DVenta OBJ = new DVenta();
            OBJ.Idventa = pIdVenta;

            return OBJ.Eliminar(OBJ);
        }
        //Metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }
        //Buscar por nombre de categoria
        public static DataTable BuscarFechas(string pTextoaBuscar, string pTextoBuscar2)
        {
            DVenta OBJBuscar = new DVenta();


            return OBJBuscar.BuscarFecha(pTextoaBuscar, pTextoBuscar2);

        }
        public static DataTable MostrarDetalle(string pTextoaBuscar)
        {
            DVenta OBJMostrar = new DVenta();


            return OBJMostrar.MostrarDetalle(pTextoaBuscar);

        }
        public static DataTable MostrarArticuloVentaNombre(string pTextoaBuscar)
        {
            DVenta OBJMostrar = new DVenta();


            return OBJMostrar.MostrarArticuloNombre(pTextoaBuscar);

        }
        public static DataTable MostrarArticuloVentaCodigo(string pTextoaBuscar)
        {
            DVenta OBJMostrar = new DVenta();


            return OBJMostrar.MostrarArticuloCodigo(pTextoaBuscar);

        }
    }
}
