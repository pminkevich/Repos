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
    public partial class FCategoriaArticulo : Form
    {
        public FCategoriaArticulo()
        {
            InitializeComponent();
        }

       
        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            this.dtgListado.Columns[1].Visible = false;



        }
        private void Mostrar()
        {
            this.dtgListado.DataSource = nCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dtgListado.DataSource = nCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void FCategoriaArticulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            //llama a setcategoria del formulario fnarticulo y se oculta
            FNArticulo form = FNArticulo.GetInstancia();
            string Param1, Param2;
            Param1 = Convert.ToString(this.dtgListado.CurrentRow.Cells["idcategoria"].Value);
            Param2 = Convert.ToString(this.dtgListado.CurrentRow.Cells["nombre"].Value);
            form.SetCategoria(Param1, Param2);
            this.Hide();

        }
    }
}
