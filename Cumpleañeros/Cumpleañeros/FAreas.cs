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

namespace Cumpleañeros
{
    public partial class FAreas : Form
    {
        
        private DataGridViewCellStyle Celdas;
        private DataGridViewAdvancedCellBorderStyle Bordes;
  
        
        
    
        public FAreas()
        {
            InitializeComponent();
            //Areas = new nArea();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre del Area");

        }
        private void AplicarEstilo()
        {
            Celdas = new DataGridViewCellStyle();
            Bordes = new DataGridViewAdvancedCellBorderStyle();
            

            Celdas.BackColor= Color.FromArgb(254, 211, 48);
            Celdas.ForeColor = Color.FromArgb(240, 147, 43);
            Celdas.Font = new Font("Century Gothic", 11, FontStyle.Regular);
            Bordes = DataGridViewAdvancedCellBorderStyle.None;
            


            dtgListado.BackgroundColor = Color.FromArgb(254, 211, 48);
            dtgListado.AdvancedCellBorderStyle.All = Bordes;
            dtgListado.EnableHeadersVisualStyles = false;
           
            dtgListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 202, 36);
            dtgListado.ColumnHeadersDefaultCellStyle.ForeColor= Color.FromArgb(240, 147, 43);
            dtgListado.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dtgListado.RowHeadersDefaultCellStyle.BackColor= Color.FromArgb(249, 202, 36);
            dtgListado.RowHeadersDefaultCellStyle.ForeColor= Color.FromArgb(240, 147, 43);
            dtgListado.AutoSizeColumnsMode=  DataGridViewAutoSizeColumnsMode.AllCells;
         
            
           


            dtgListado.DefaultCellStyle = Celdas;
        }
        private void MensajeError(string pMensaje)
        {
            MessageBox.Show(pMensaje, "Cumpleañero 1.0", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void MensajeOK(string pMensaje)
        {
            MessageBox.Show(pMensaje, "Cumpleañero 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }

        private void Mostrar()
        {
            dtgListado.DataSource = nArea.Mostrar();
            lblTotal.Text = dtgListado.Rows.Count.ToString();
        }
        private void OcultarColumnas()
        {
            dtgListado.Columns[0].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FAreas_Load(object sender, EventArgs e)
        {
            Mostrar();
            OcultarColumnas();
            AplicarEstilo();

            
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if(txtNombre.Text== string.Empty)
                {
                    MensajeError("Ingrese el Nombre del Area");
                    errorIcono.SetError(txtNombre,"Ingrese un Nombre");
                }
                else
                {
                    
                    errorIcono.SetError(txtNombre, "");
                    rpta = nArea.Insertar(txtNombre.Text.Trim().ToUpper());

                    if (rpta == "OK")
                    {
                        MensajeOK("Se Ingreso el Registro");


                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                    Mostrar();
                    Limpiar();
                }

               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                DialogResult Resp = MessageBox.Show("Desea Eliminar el Registro", "Cumpleañero 1.0",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                int Idarea=Convert.ToInt32(dtgListado.CurrentRow.Cells["Idarea"].Value);

                if (Resp == DialogResult.OK)
                {
                    rpta = nArea.Eliminar(Idarea);
                }
                if (rpta == "OK")
                {
                    MessageBox.Show("Se Elimino el Registro");
                }
                else
                {
                    MessageBox.Show("No se pudo Eliminar el Registro");
                }
                Mostrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
