using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text  = "";
                txtUser.ForeColor = Color.White;

            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.Gainsboro;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.Gainsboro;
                txtPass.UseSystemPasswordChar = false;

                



            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "Usuario")
            {
                if (txtPass.Text != "Contraseña")
                {
                    ModeloUsuario Usuario = new ModeloUsuario();
                    var IngresoCorrecto = Usuario.LoginUser(txtUser.Text, txtPass.Text);
                    if (IngresoCorrecto == true)
                    {
                        Principal Pr = new Principal();
                        Pr.Show();
                        this.Hide();
                        Pr.FormClosed += Logout;


                    }
                    else
                    {
                        MensajeError("Nombre de Usuario o Contraseña Incorrecta");
                        txtPass.Clear();
                        txtUser.Focus();
                    }
                }
                else
                {
                    MensajeError("No Ingreso la Contraseña");
                }
            }
            else
            {
                MensajeError("No Ingreso el Usuario");
            }
        }
        private void MensajeError(string pMensaje)
        {
            lblMensajeError.Text = pMensaje;
            lblMensajeError.Visible = true;
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                btnIngresar_Click(null, e);
            }
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {

           
            txtPass.UseSystemPasswordChar = false;
            txtPass.ForeColor = Color.Gainsboro;
            txtUser.ForeColor = Color.Gainsboro;
            txtPass.Text = "Contraseña";
            txtUser.Text = "Usuario";
            lblMensajeError.Visible = false;
           

            this.Show();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
