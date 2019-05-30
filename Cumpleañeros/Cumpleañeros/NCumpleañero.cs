using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Dominio;

namespace Cumpleañeros
{
    public partial class NCumpleañero : Form
    {

        private nEmpleado Empleado;
        private DataGridViewCellStyle Celdas;
        private DataGridViewAdvancedCellBorderStyle Bordes;
        private bool Isnuevo=true;
        private bool Iseditar = false;
        private string Idempleado;

        public NCumpleañero()
        {
            InitializeComponent();

            
            
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
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            pImagen.Image = global::Cumpleañeros.Properties.Resources.Close;
        }
        private void Mostrar()
        {
            Empleado = new nEmpleado();
            dtgListado.DataSource = Empleado.Mostrar();
        }
        private void OcultarColumnas()
        {
            dtgListado.Columns[0].Visible = false;
            dtgListado.Columns[1].Visible = false;
            dtgListado.Columns[2].Visible = false;
            dtgListado.Columns[3].Visible = false;
            dtgListado.Columns[6].Visible = false;
        }
        private void Iniciartt()
        {
            ttMensaje.SetToolTip(txtNombre, "Ingrese un Nombre");
            txtNombre.Focus();
        }
        private bool Validar(NCumpleañero Form)
        {
            
            bool Valido = true;
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtEmail, "");

            foreach (Control Controles in Form.Controls)
            {
                if(Controles is TextBox && Controles.Text == string.Empty)
                {
                    errorProvider1.SetError(Controles, "Debe Ingresar un Valor");

                    Valido = false;
                }
            }
            return Valido;
        }
        private bool IsMail(string pEmail)
        {
            Regex Exp = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            return Exp.IsMatch(pEmail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Explorar = new OpenFileDialog();
            DialogResult Respuesta = Explorar.ShowDialog();
            if (Respuesta == DialogResult.OK)
            {

                this.pImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pImagen.Image = Image.FromFile(Explorar.FileName);
                
                if (this.pImagen.Image.Size.Height > 300)
                {
                    MensajeError("La Imagen es muy Grande");
                    pImagen.Image = global::Cumpleañeros.Properties.Resources.Close;
                }
            }


        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnAgregarArea_Click(object sender, EventArgs e)
        {
            NArea form = new NArea();
            form.ShowDialog();
            LlenarCombo();
            LlenarComboC();

        }

        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            int Idarea = Convert.ToInt32(cbArea.SelectedValue);
            NCargo form = new NCargo(Idarea);
            form.ShowDialog();
            LlenarCombo();
            LlenarComboC();
        }
        private void LlenarCombo()
        {
            cbArea.DataSource = nArea.Mostrar();
            cbArea.ValueMember = "Idarea";
            cbArea.DisplayMember = "Nombre";
        }

        private void LlenarComboC()
        {


            cbCargo.DisplayMember = "Nombre";
            cbCargo.ValueMember = "Idcargo";
            cbCargo.DataSource = nCargo.LlenarCombo(Convert.ToInt32(cbArea.SelectedValue));
            //cbCargo.ValueMember = "Idcargo";
            //cbCargo.DisplayMember = "Nombre";
        }
        private void NCumpleañero_Load(object sender, EventArgs e)
        {

            LlenarCombo();
            LlenarComboC();
            AplicarEstilo();
            Mostrar();
            OcultarColumnas();
            Iniciartt();




        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            LlenarComboC();
        }

        private void cbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LlenarComboC();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Isnuevo == true)
                {
                    if (Validar(this))
                    {
                        if (IsMail(txtEmail.Text))
                        {
                            string rpta = "";


                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            this.pImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] Imagen = ms.GetBuffer();

                            Empleado = new nEmpleado(Convert.ToInt32(cbCargo.SelectedValue), Convert.ToInt32(cbArea.SelectedValue), txtNombre.Text.Trim().ToUpper(),
                                                        txtApellido.Text.Trim().ToUpper(),
                                                        txtEmail.Text, dtFecha.Value,
                                                        Imagen);
                            rpta = Empleado.Insertar();

                            if (rpta == "OK")
                            {
                                MensajeOK("Ingreso un nuevo Cumpleañero!!!");
                            }
                            else
                            {
                                MensajeError("No se pudo Insertar el Registro");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ingrese un E-Mail Valido");
                        }
                    }
                    else
                    {

                        //para poder agregar del form cargos y areas
                        MensajeError("Faltan Datos");
                    }
                    Mostrar();
                    Limpiar();
                }
            }
                
            catch(Exception ex)
            {
                MensajeError(ex.Message);
            }
           
           

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dtgListado.Columns[0].Visible = true;
                btnNuevo.Visible = false;
                button1.Enabled = true;
            }
            else
            {
                dtgListado.Columns[0].Visible = false;
                if (btnGuardarE.Visible == true)
                {
                    btnNuevo.Visible = true;
                }
                button1.Enabled = false;

            }
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell cheliminar =
                (DataGridViewCheckBoxCell)dtgListado.Rows[e.RowIndex].Cells["Eliminar"];
                cheliminar.Value = !Convert.ToBoolean(cheliminar.Value);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Resp = MessageBox.Show("¿Realmente desea Eliminar el Registro?", "Cumpleañero 1.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Resp == DialogResult.OK)
                {
                    string Codigo = "";
                    string rpta = "";
                    

                    foreach (DataGridViewRow Fila in dtgListado.Rows)
                    {
                        if (Convert.ToBoolean(Fila.Cells[0].Value))
                        {
                            Codigo = Fila.Cells[1].Value.ToString();
                            Empleado = new nEmpleado(Convert.ToInt32(Codigo));
                            rpta = Empleado.Eliminar();

                            if (rpta == "OK")
                            {
                                MensajeOK("Se Elimino El/los Registro/s");
                            }
                            else
                            {
                                MensajeError("No se pudo Eliminar El/los registro/s");
                            }
                        }
                    }
                }
                checkBox1.Checked = false;
                //checkBox1_CheckedChanged(this, null);
                Mostrar();
                Limpiar();
            }
            catch(Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            string rpta = "";
            Isnuevo = false;
            btnGuardarE.Visible = true;
            btnNuevo.Visible = true;

            try
            {
                Idempleado=dtgListado.CurrentRow.Cells["Idempleado"].Value.ToString();
                cbArea.SelectedValue = Convert.ToInt32(dtgListado.CurrentRow.Cells["Idarea"].Value);
                LlenarComboC();
                cbCargo.SelectedValue = Convert.ToInt32(dtgListado.CurrentRow.Cells["Idcargo"].Value);

                txtNombre.Text = dtgListado.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dtgListado.CurrentRow.Cells["Apellido"].Value.ToString();
                txtEmail.Text= dtgListado.CurrentRow.Cells["Email"].Value.ToString();

                byte[] Imagenbd = (Byte[])dtgListado.CurrentRow.Cells["Foto"].Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Imagenbd);

                pImagen.Image = Image.FromStream(ms);
                pImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                Iseditar = true;


            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnGuardarE.Visible = false;
            btnNuevo.Visible = false;
        }

        private void btnGuardarE_Click(object sender, EventArgs e)
        {
            try
            {
                if (Iseditar == true)
                {
                    if (Validar(this))
                    {
                        if (IsMail(txtEmail.Text))
                        {
                            string rpta = "";


                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            this.pImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] Imagen = ms.GetBuffer();

                            Empleado = new nEmpleado(Convert.ToInt32(Idempleado),Convert.ToInt32(cbCargo.SelectedValue), Convert.ToInt32(cbArea.SelectedValue), txtNombre.Text.Trim().ToUpper(),
                                                        txtApellido.Text.Trim().ToUpper(),
                                                        txtEmail.Text, dtFecha.Value,
                                                        Imagen);
                            rpta = Empleado.Modificar();

                            if (rpta == "OK")
                            {
                                MensajeOK("Se Guardaron los Cambio");
                            }
                            else
                            {
                                MensajeError("No se pudo Actualizar los campos");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ingrese un E-Mail Valido");
                        }
                    }
                    else
                    {

                        //para poder agregar del form cargos y areas
                        MensajeError("Faltan Datos");
                    }
                    Mostrar();
                    Limpiar();
                }
            }

            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }

        }
    }
}
