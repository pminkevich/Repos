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
    public partial class FNReporteFac : Form
    {
        private int _Idventa;

        public int Idventa { get => _Idventa; set => _Idventa = value; }


        public FNReporteFac()
        {
            InitializeComponent();
        }


        private void FNReporteFac_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'DSPrincipal.spreporte_factura' Puede moverla o quitarla según sea necesario.
                this.spreporte_facturaTableAdapter.Fill(this.DSPrincipal.spreporte_factura, Idventa);

                this.reportViewer1.RefreshReport();

            }
            catch(Exception ex)
            {
                this.reportViewer1.RefreshReport();

            }
        }
    }
}
