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
    public partial class FNVistaArticuloI : Form
    {
        public FNVistaArticuloI()
        {
            InitializeComponent();
        }

        private void FNVistaArticuloI_Load(object sender, EventArgs e)
        {
            Mostrar();

        }
        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            this.dtgListado.Columns[1].Visible = false;
            this.dtgListado.Columns[6].Visible = false;
            this.dtgListado.Columns[8].Visible = false;




        }
        
        private void Mostrar()
        {
            this.dtgListado.DataSource = nArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dtgListado.DataSource = nArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            FNIngreso Form = FNIngreso.GetInstancia();

            string Par1, Par2;
            Par1 = dtgListado.CurrentRow.Cells["idarticulo"].Value.ToString();
            Par2 = dtgListado.CurrentRow.Cells["nombre"].Value.ToString();
            Form.SetArticulo(Par1, Par2);
            this.Hide();

        }
    }
}
