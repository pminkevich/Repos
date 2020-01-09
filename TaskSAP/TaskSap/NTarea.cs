using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskSap.Logica;

namespace TaskSap
{
    public partial class NTarea : Form
    {
        private Ltareas NewTask;
        private object[] Textos;
        private object[] Labels;
        private object Date;
        public NTarea()
        {
            InitializeComponent();
            NewTask = new Ltareas();
            Textos = new object[3];
            Labels = new object[3];
            Date = new object();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           
            string rpta = "";
            Textos[0] = txtTitulo;
            Textos[1] = txtDescripcion;
            Date = dateFecha;
            Textos[2]=txtTelefono;

            Labels[0] = lblErrorTitulo;
            Labels[1] = lblErrorDescripcion;
            //Labels[2] = lblFecha;
            Labels[2] = lblErrorTelefono;

            if (NewTask.Validar(Textos, Labels))
            {
                rpta = NewTask.NTarea(Textos, Date);
                if (rpta.Equals("OK"))
                {
                    MessageBox.Show("Se Agrego La Tarea");
                    this.Close();

                }
                else
                {
                    //MessageBox.Show(rpta);
                }
            }
               
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {
           
            txtTitulo.CharacterCasing = CharacterCasing.Upper;
            if (lblErrorTitulo.Visible == true) lblErrorTitulo.Visible = false;
            
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (lblErrorDescripcion.Visible == true) lblErrorDescripcion.Visible = false;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (lblErrorTelefono.Visible == true) lblErrorTelefono.Visible = false;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) e.Handled = true;

        }
    }
}
