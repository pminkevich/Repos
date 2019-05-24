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
    public partial class FNLogin : Form
    {

        public FNLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString(); 

        }

        private void FNLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = Dominio.NTrabajador.Login(txtUsuario.Text, txtPassword.Text);
            //Evaluo si existe
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("El Usuario No Existe", "Ingreso no Autorizado",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else
            {
                Principal FPrincipal = new Principal();
                FPrincipal.Idtrabajador = Datos.Rows[0][0].ToString();
                FPrincipal.Apellidos = Datos.Rows[0][1].ToString();
                FPrincipal.Nombre = Datos.Rows[0][2].ToString();
                FPrincipal.Acceso = Datos.Rows[0][3].ToString();

                FPrincipal.Show();
                this.Hide();


            }
        }
    }
}
