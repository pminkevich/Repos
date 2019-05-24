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
    public partial class FNPresentacion : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        
        public FNPresentacion()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de La Presentacion");
        }
        private void MensajeOk(string pMensaje)
        {
            MessageBox.Show(pMensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MensajeError(string pMensaje)
        {
            MessageBox.Show(pMensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdPresentacion.Text = string.Empty;

        }

        private void Habilitar(bool pValor)
        {
            this.txtNombre.ReadOnly = !pValor;
            this.txtDescripcion.ReadOnly = !pValor;
            this.txtIdPresentacion.ReadOnly = !pValor;


        }

        private void HabilitarBotones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btbNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;


            }
            else
            {
                this.Habilitar(false);
                this.btbNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            this.dtgListado.Columns[1].Visible = false;



        }
        private void Mostrar()
        {
            this.dtgListado.DataSource = nPresentacion.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dtgListado.DataSource = nPresentacion.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void FNPresentacion_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();
            Habilitar(false);
            this.HabilitarBotones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void btbNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar Ingresar");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = nPresentacion.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = nPresentacion.Editar(Convert.ToInt32(this.txtIdPresentacion.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim());

                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Inserto el Registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo el Registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.HabilitarBotones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdPresentacion.Text.Equals(""))
            {
                this.IsEditar = true;
                this.HabilitarBotones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dtgListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = nPresentacion.Eliminar(Convert.ToInt32(Codigo));
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente el Registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chEliminar.Checked)
            {
                this.dtgListado.Columns[0].Visible = true;

            }
            else
            {
                this.dtgListado.Columns[0].Visible = false;
            }
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dtgListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdPresentacion.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["idpresentacion"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["descripcion"].Value);
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
