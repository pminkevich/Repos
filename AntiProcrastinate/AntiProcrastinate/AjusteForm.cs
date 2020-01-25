using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiProcrastinate
{
    public partial class FrmAjuste : Form
    {
        private Admin.Ajuste Ajuste;
        public FrmAjuste()
        {
            InitializeComponent();
            Ajuste = new Admin.Ajuste();
            Ajuste.ChangePreset += Ajuste_ChangePreset;
        }
        //Evento que se ejecuta cuando se cambian los valores del preset
        private void Ajuste_ChangePreset(object sender, Admin.AjusteEventArgs e)
        {
            NumOcio.Value = e.OcioTime;
            NumAP.Value = e.APTime;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Presets(object sender, EventArgs e)
        {
            //Pone todos los botones blancos menos el elegido

            Control.ControlCollection Botones = this.panel1.Controls;
            foreach (var item in Botones)
            {
                string Tipo = item.GetType().ToString();
                if (Tipo == "System.Windows.Forms.Button")
                {
                    ((Button)item).BackColor = Color.White;
                }
            }

            //Boton Presionado
            ((Button)sender).BackColor = Color.Gray;
          //SetPreset(((Button)sender).Name.ToString());
          //envia a ajuste el texto del boton 
            Ajuste.AdjModo(((Button)sender).Text);
        }

        private void SetPreset(string Value)
        {
           // throw new NotImplementedException();
        }
    }
}
