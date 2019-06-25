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

namespace Presentacion.Consultas
{
    public partial class FNConsultaStockA : Form
    {
        public FNConsultaStockA()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            




        }
        
        private void Mostrar()
        {
            this.dtgListado.DataSource = nArticulo.Stock_Articulos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        private void FNConsultaStockA_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
