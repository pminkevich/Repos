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
    public partial class FNArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static FNArticulo _Instancia;

        public static FNArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FNArticulo();

            }
            return _Instancia;
        }
        public void SetCategoria(string pIdcategoria,string pNombre)
        {
            this.txtIdcategoria.Text = pIdcategoria;
            this.txtCategoria.Text = pNombre;

        }

        public FNArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la imagen del Articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la Categoria del Articulo");
            this.ttMensaje.SetToolTip(this.cbIdpresentacion, "Seleccione la presentación del articulo");
            this.txtIdcategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();


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
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdArticulo.Text = string.Empty;
            this.pxImagen.Image = global::Presentacion.Properties.Resources._52254;


        }

        private void Habilitar(bool pValor)
        {
            this.txtCodigo.ReadOnly = !pValor;
            this.txtNombre.ReadOnly = !pValor;
            this.txtDescripcion.ReadOnly = !pValor;
            this.btnBuscar.Enabled = pValor;
            this.cbIdpresentacion.Enabled = pValor;
            this.btnCargar.Enabled = pValor;
            this.btnLimpiar.Enabled = pValor;
            this.txtIdArticulo.ReadOnly = !pValor;


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
            this.dtgListado.Columns[6].Visible = false;
            this.dtgListado.Columns[8].Visible = false;




        }
        private void LlenarComboPresentacion()
        {
            cbIdpresentacion.DataSource = nPresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "idpresentacion";
            cbIdpresentacion.DisplayMember = "nombre";
        }
        private void Mostrar()
        {
            this.dtgListado.DataSource = nArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dtgListado.DataSource = nArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

       

       

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::Presentacion.Properties.Resources._52254;

        }

       

        private void FNArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
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

                if (txtNombre.Text == string.Empty||txtIdcategoria.Text==string.Empty ||txtCodigo.Text==string.Empty )
                {
                    MensajeError("Falta Ingresar Ingresar");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCategoria, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");


                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        rpta = nArticulo.Insertar(this.txtCodigo.Text.Trim().ToUpper(),this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(),imagen,Convert.ToInt32(this.txtIdcategoria.Text),Convert.ToInt32(this.cbIdpresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = nArticulo.Editar(Convert.ToInt32(this.txtIdArticulo.Text),this.txtCodigo.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdcategoria.Text), Convert.ToInt32(this.cbIdpresentacion.SelectedValue));

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
            if (!txtIdArticulo.Text.Equals(""))
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
            this.txtIdArticulo.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["descripcion"].Value);

            byte[] imagenbuffer = (byte[])this.dtgListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.txtIdcategoria.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dtgListado.CurrentRow.Cells["categoria"].Value);
            this.cbIdpresentacion.SelectedValue= Convert.ToString(this.dtgListado.CurrentRow.Cells["idpresentacion"].Value);
            this.tabControl1.SelectedIndex = 1;
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
                            Rpta = nArticulo.Eliminar(Convert.ToInt32(Codigo));
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

        private void btnBuscasCat_Click(object sender, EventArgs e)
        {
            FCategoriaArticulo form = new FCategoriaArticulo();
            form.ShowDialog();

        }
    }
}
