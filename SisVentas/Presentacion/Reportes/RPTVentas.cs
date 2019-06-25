using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class RPTVentas : Form
    {
        public RPTVentas()
        {
            InitializeComponent();
        }

        private void RPTVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSPrincipal.spmostrar_venta' Puede moverla o quitarla según sea necesario.
            this.spmostrar_ventaTableAdapter.Fill(this.DSPrincipal.spmostrar_venta);

            this.reportViewer1.RefreshReport();
        }
    }
}
