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
    public partial class FNVistaProveedorI : Form
    {
        public FNVistaProveedorI()
        {
            InitializeComponent();
        }

        private void FNVistaProveedorI_Load(object sender, EventArgs e)
        {
            Mostrar();

        }
        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            this.dtgListado.Columns[1].Visible = false;



        }
        private void Mostrar()
        {
            this.dtgListado.DataSource = nProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        //metodo buscar razon social
        private void BuscarRazonSocial()
        {
            this.dtgListado.DataSource = nProveedor.BuscarRazonSocial(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNumDocumento()
        {
            this.dtgListado.DataSource = nProveedor.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazonSocial();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();

            }
        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            FNIngreso Form = FNIngreso.GetInstancia();
            string Par1, Par2;
            Par1 = this.dtgListado.CurrentRow.Cells["idproveedor"].Value.ToString();
            Par2 = this.dtgListado.CurrentRow.Cells["razon_social"].Value.ToString();
            Form.SetProveedor(Par1, Par2);
            this.Hide();
        }
    }
}
