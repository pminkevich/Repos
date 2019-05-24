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
    public partial class FNProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FNProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazonSocial, "Ingrese La Razon Social del proveedor");
            this.ttMensaje.SetToolTip(this.txtNumDocumento, "Ingrese El Numero de Documento del proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese La Direccion del proveedor");
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
            this.txtRazonSocial.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;


        }

        private void Habilitar(bool pValor)
        {
            this.txtRazonSocial.ReadOnly = !pValor;
            this.txtDireccion.ReadOnly = !pValor;
            this.cbSectorComercial.Enabled = pValor;
            this.cbTipoDocumento.Enabled = pValor;
            this.txtNumDocumento.ReadOnly = !pValor;
            this.txtTelefono.ReadOnly = !pValor;
            this.txtUrl.ReadOnly = !pValor;
            this.txtEmail.ReadOnly = !pValor;
            this.txtIdProveedor.ReadOnly = !pValor;



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

        private void FNProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.HabilitarBotones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazonSocial();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();

            }
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
                            Rpta = nProveedor.Eliminar(Convert.ToInt32(Codigo));
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

        private void btbNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazonSocial.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtRazonSocial.Text == string.Empty || this.txtNumDocumento.Text==string.Empty ||this.txtDireccion.Text==string.Empty )
                {
                    MensajeError("Falta Ingresar Ingresar");
                    errorIcono.SetError(txtRazonSocial, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                    errorIcono.SetError(txtNumDocumento, "Ingrese un Valor");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = nProveedor.Insertar(this.txtRazonSocial.Text.Trim().ToUpper(), 
                            this.cbSectorComercial.Text,this.cbTipoDocumento.Text,txtNumDocumento.Text.Trim().ToUpper(),
                            txtDireccion.Text.Trim().ToUpper(),txtTelefono.Text.Trim().ToUpper(),txtEmail.Text.Trim().ToUpper(),txtUrl.Text.Trim().ToUpper());
                    }
                    else
                    {
                        rpta = nProveedor.Editar(Convert.ToInt32(this.txtIdProveedor.Text),this.txtRazonSocial.Text.Trim().ToUpper(),
                            this.cbSectorComercial.Text, this.cbTipoDocumento.Text, txtNumDocumento.Text.Trim().ToUpper(),
                            txtDireccion.Text.Trim().ToUpper(), txtTelefono.Text.Trim().ToUpper(), txtEmail.Text.Trim().ToUpper(), txtUrl.Text.Trim().ToUpper());

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
            if (!txtIdProveedor.Text.Equals(""))
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
            this.txtIdProveedor.Text = string.Empty;

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
            this.txtIdProveedor.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtRazonSocial.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["razon_social"].Value);
            this.cbSectorComercial.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["sector_comercial"].Value);
            this.cbTipoDocumento.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["url"].Value);
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
