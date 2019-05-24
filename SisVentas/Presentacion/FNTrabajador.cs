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
    public partial class FNTrabajador : Form
    {
        private bool isNuevo = false;
        private bool isEditar = false;

        public FNTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el Nombre del Trabajador");
            this.ttMensaje.SetToolTip(txtApellido, "Ingrese el Apellido del Trabajador");
            this.ttMensaje.SetToolTip(txtUsuario, "Ingrese el Usuario del Trabajador");
            this.ttMensaje.SetToolTip(txtPassword, "Ingrese el Password del Trabajador");
            this.ttMensaje.SetToolTip(cbAcceso, "Seleccione el nivel de Acceso del Trabajador");
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
            this.txtApellido.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdTrabajador.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;


        }

        private void Habilitar(bool pValor)
        {
            this.txtNombre.ReadOnly = !pValor;
            this.txtApellido.ReadOnly = !pValor;
            this.cbSexo.Enabled = pValor;
            this.txtDireccion.ReadOnly = !pValor;           
            this.txtNumDocumento.ReadOnly = !pValor;
            this.txtTelefono.ReadOnly = !pValor;
            this.txtEmail.ReadOnly = !pValor;
            this.cbAcceso.Enabled = pValor;
            this.txtUsuario.ReadOnly = !pValor;
            this.txtPassword.ReadOnly = !pValor;
            this.txtIdTrabajador.ReadOnly = !pValor;



        }

        private void HabilitarBotones()
        {
            if (this.isNuevo || this.isEditar)
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
            this.dtgListado.DataSource = NTrabajador.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        //metodo buscar razon social
        private void BuscarApellido()
        {
            this.dtgListado.DataSource = NTrabajador.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNumDocumento()
        {
            this.dtgListado.DataSource = NTrabajador.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void FNTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 9;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.HabilitarBotones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
            else if (cbBuscar.Text.Equals("Apellido"))
            {
                this.BuscarApellido();
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
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));
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
            this.txtIdTrabajador.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["idtrabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["apellido"].Value);
            this.cbSexo.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["email"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["password"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btbNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtIdTrabajador.Text = string.Empty;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty 
                    || this.txtNumDocumento.Text == string.Empty || this.txtDireccion.Text == string.Empty
                    ||this.txtUsuario.Text==string.Empty|| this.txtPassword.Text==string.Empty)
                {
                    MensajeError("Falta Ingresar Ingresar");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellido, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                    errorIcono.SetError(txtNumDocumento, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Usuario");
                    errorIcono.SetError(txtPassword, "Ingrese un Password");

                }
                else
                {
                    if (this.isNuevo)
                    {
                        rpta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellido.Text.Trim().ToUpper(), this.cbSexo.Text,
                            this.dtFechaNac.Value, txtNumDocumento.Text.Trim().ToUpper(),
                            txtDireccion.Text.Trim().ToUpper(), txtTelefono.Text.Trim().ToUpper(),
                            txtEmail.Text.Trim().ToUpper(), this.cbAcceso.Text,this.txtUsuario.Text.Trim(),
                            this.txtPassword.Text);
                    }
                    else
                    {
                        rpta = NTrabajador.Editar(Convert.ToInt32(this.txtIdTrabajador.Text), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellido.Text.Trim().ToUpper(), this.cbSexo.Text,
                            this.dtFechaNac.Value, txtNumDocumento.Text.Trim().ToUpper(),
                            txtDireccion.Text.Trim().ToUpper(), txtTelefono.Text.Trim().ToUpper(),
                            txtEmail.Text.Trim().ToUpper(), this.cbAcceso.Text, this.txtUsuario.Text.Trim(),
                            this.txtPassword.Text);

                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.isNuevo)
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
                    this.isNuevo = false;
                    this.isEditar = false;
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
            if (!txtIdTrabajador.Text.Equals(""))
            {
                this.isEditar = true;
                this.HabilitarBotones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a Modificar");
            }
        }
    }
}
