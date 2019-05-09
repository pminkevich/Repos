using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace login
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void LoadUserData()
        {
            lblNombre.Text = UserLoginCache.Nombre;
            lblApellido.Text = UserLoginCache.Apellido;
            lblPosicion.Text = UserLoginCache.Posicion;
            lblEmail.Text = UserLoginCache.Email;

        }
    }
}
