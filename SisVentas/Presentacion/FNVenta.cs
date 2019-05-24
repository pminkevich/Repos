using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class FNVenta : Form
    {
        private bool isNuevo = false;
        public int Idtrabajador;
        private DataTable Detalle;
        private decimal TotalPagado = 0;
        private static FNVenta _Instancia;

        public static FNVenta GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FNVenta();
            }
            return _Instancia;
        }
        public void SetCliente(string pIdCliente, string pNombreCliente)
        {
            this.txtIdCliente.Text = pIdCliente;
            this.txtCliente.Text = pNombreCliente;

        }

        public void SetArticulo(string pIdDetalleIngreso,string pNombre, 
            decimal pPrecioCompra, decimal pPrecioVenta,int pStock, DateTime pFechaVencimiento)
        {
            this.txtIdArticulo.Text = pIdDetalleIngreso;
            this.txtArticulo.Text = pNombre;
            this.txtPrecioCompra.Text = pPrecioCompra.ToString();
            this.txtPrecioVenta.Text = pPrecioVenta.ToString();
            this.txtStockActual.Text = pStock.ToString();
            this.dtFechaVen.Value = pFechaVencimiento;
        }
        public FNVenta()
        {
            InitializeComponent();
        }

        private void FNVenta_Load(object sender, EventArgs e)
        {

        }

        private void FNVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FNVistaClienteVenta Vista = new FNVistaClienteVenta();
            Vista.ShowDialog();

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FNVistaArticuloVenta Articulo = new FNVistaArticuloVenta();
            Articulo.ShowDialog();

        }
    }
}
