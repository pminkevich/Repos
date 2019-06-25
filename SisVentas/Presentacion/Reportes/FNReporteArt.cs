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
    public partial class FNReporteArt : Form
    {
        public FNReporteArt()
        {
            InitializeComponent();
        }

        private void FNReporteArt_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'DSPrincipal.spmostrar_articulo' Puede moverla o quitarla según sea necesario.
                this.spmostrar_articuloTableAdapter.Fill(this.DSPrincipal.spmostrar_articulo);

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {

            }
           
           
        }
    }
}
