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
    public partial class FNVistaArticuloVenta : Form
    {
        public FNVistaArticuloVenta()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            this.dtgListado.Columns[1].Visible = false;
                       
        }
        
        //metodo buscar por nombre
        private void MostrarArticuloPorNombre()
        {
            this.dtgListado.DataSource = NVenta.MostrarArticuloVentaNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        private void MostrarArticuloPorCodigo()
        {
            this.dtgListado.DataSource = NVenta.MostrarArticuloVentaCodigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void FNVistaArticuloVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarArticuloPorCodigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticuloPorNombre();
            }
            
        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            FNVenta Form = FNVenta.GetInstancia();
            string Par1, Par2;
            decimal Par3, Par4;
            int Par5;
            DateTime Par6;

            Par1 = this.dtgListado.CurrentRow.Cells["iddetalle_ingreso"].Value.ToString();
            Par2 = this.dtgListado.CurrentRow.Cells["nombre"].Value.ToString();
            Par3 = Convert.ToDecimal(this.dtgListado.CurrentRow.Cells["precio_compra"].Value);
            Par4= Convert.ToDecimal(this.dtgListado.CurrentRow.Cells["precio_venta"].Value);
            Par5 = Convert.ToInt32(this.dtgListado.CurrentRow.Cells["stock_actual"].Value);
            Par6=Convert.ToDateTime(this.dtgListado.CurrentRow.Cells["fecha_vencimiento"].Value);
            Form.SetArticulo(Par1, Par2, Par3, Par4, Par5, Par6);
            this.Hide();

        }
    }
}
