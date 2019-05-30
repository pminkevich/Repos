using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Cumpleañeros
{
    public partial class FCargo : Form
    {
        private DataGridViewCellStyle Celdas;
        private DataGridViewAdvancedCellBorderStyle Bordes;
        public FCargo()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre del Area");
        }
        private void AplicarEstilo()
        {
            Celdas = new DataGridViewCellStyle();
            Bordes = new DataGridViewAdvancedCellBorderStyle();


            Celdas.BackColor = Color.FromArgb(254, 211, 48);
            Celdas.ForeColor = Color.FromArgb(240, 147, 43);
            Celdas.Font = new Font("Century Gothic", 11, FontStyle.Regular);
            Bordes = DataGridViewAdvancedCellBorderStyle.None;



            dtgListado.BackgroundColor = Color.FromArgb(254, 211, 48);
            dtgListado.AdvancedCellBorderStyle.All = Bordes;
            dtgListado.EnableHeadersVisualStyles = false;

            dtgListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 202, 36);
            dtgListado.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(240, 147, 43);
            dtgListado.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dtgListado.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 202, 36);
            dtgListado.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(240, 147, 43);
            dtgListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;





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
            dtgListado.DataSource = nCargo.Mostrar();
            lblTotal.Text = dtgListado.Rows.Count.ToString();
        }
        private void OcultarColumnas()
        {
            dtgListado.Columns[0].Visible = false;
            dtgListado.Columns[1].Visible = false;
        }
        private void LlenarCombo()
        {
            cbAreas.DataSource = nArea.Mostrar();
            cbAreas.DisplayMember = "Nombre";
            cbAreas.ValueMember = "Idarea";
        }

        private void Habilitar(bool pValor)
        {
            if (pValor)
            {
                cbAreas.Enabled = true;
                txtNombre.ReadOnly = false;
                txtValor.ReadOnly = false;
                btnGuardar.Enabled = true;
                btnNuevo.Enabled = false;

            }
            else
            {
                cbAreas.Enabled = false;
                txtNombre.ReadOnly = true;
                txtValor.ReadOnly = true;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
            }
        }

        private bool Validacion()
        {
            if (cbAreas.Text != string.Empty)
            {
                if (txtNombre.Text != string.Empty)
                {
                    if (txtValor.Text!=string.Empty)
                    {
                        if (!IsNumeric(txtValor.Text))
                        {
                            return true;
                        }
                        else
                        {
                            errorIcono.SetError(txtValor, "Ingrese un Valor Numerico");
                        }
                    }
                    else
                    {
                        errorIcono.SetError(txtValor, "Ingrese un Valor");
                    }
                }
                else
                {
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre de Cargo");
                }
            }
            else
            {
                errorIcono.SetError(cbAreas, "Seleccione un Area");
            }
            return false;
       
           
        }
        private bool IsNumeric(string pValor)
        {
            Regex isnumber = new Regex("[^0-9]");

         return isnumber.IsMatch(pValor);
            
        }

        private void FCargo_Load(object sender, EventArgs e)
        {
            Mostrar();
            LlenarCombo();
            OcultarColumnas();
            AplicarEstilo();
            Habilitar(false);
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

                if (!Validacion())
                {
                    
                }
                else
                {
                   
                        errorIcono.SetError(txtNombre, "");
                        errorIcono.SetError(cbAreas, "");
                        errorIcono.SetError(txtValor, "");

                        rpta = nCargo.Insertar(Convert.ToInt32(cbAreas.SelectedValue), txtNombre.Text.Trim().ToUpper(), Convert.ToInt32(txtValor.Text));

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
                    Habilitar(false);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
    }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
        }

        private void dtgListado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string rpta = "";

            try
            {
                int Idcargo= Convert.ToInt32(dtgListado.CurrentRow.Cells["Idcargo"].Value);
                int Idarea = Convert.ToInt32(dtgListado.CurrentRow.Cells["Idarea"].Value);
                string Nombre = dtgListado.CurrentRow.Cells["Nombre"].Value.ToString();
                int Valor = Convert.ToInt32(dtgListado.CurrentRow.Cells["Valor"].Value);
                rpta = nCargo.Modificar(Idcargo, Idarea, Nombre, Valor);

                if (rpta == "OK")
                {
                    MessageBox.Show("Se Actualizo el Registro");
                }
                else
                {
                    MessageBox.Show("No Se Actualizo el Registro");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                int Idcargo = Convert.ToInt32(dtgListado.CurrentRow.Cells["Idcargo"].Value);
                DialogResult Respuesta;

                Respuesta = MessageBox.Show("Desea eliminar el Registro", "Cumpleañero 1.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (Respuesta == DialogResult.OK)
                {
                    rpta = nCargo.Eliminar(Idcargo);

                    if (rpta == "OK")
                    {
                        MessageBox.Show("Se Elimino el Registro");
                    }
                    else
                    {
                        MessageBox.Show("No Se pudo Eliminar el Registro");
                    }

                }
                Mostrar();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

     
    }
}
