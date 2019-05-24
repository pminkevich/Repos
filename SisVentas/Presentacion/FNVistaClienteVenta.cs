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
    public partial class FNVistaClienteVenta : Form
    {
        public FNVistaClienteVenta()
        {
            InitializeComponent();
        }

        private void FNVistaClienteVenta_Load(object sender, EventArgs e)
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
            this.dtgListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        //metodo buscar razon social
        private void BuscarApellido()
        {
            this.dtgListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNumDocumento()
        {
            this.dtgListado.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellido"))
            {
                this.BuscarApellido();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            FNVenta Form = FNVenta.GetInstancia();
            string Par1, Par2;
            Par1 = this.dtgListado.CurrentRow.Cells["idcliente"].Value.ToString();
            Par2 = this.dtgListado.CurrentRow.Cells["apellido"].Value.ToString() + " " +
                   this.dtgListado.CurrentRow.Cells["nombre"].Value.ToString();
            Form.SetCliente(Par1, Par2);
            this.Hide();

        }
    }
}
