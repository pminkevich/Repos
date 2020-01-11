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
    public partial class Form1 : Form
    {
        private Ltareas tareas;
        public Form1()
        {
            InitializeComponent();
            tareas = new Ltareas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid(dataGridView1);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        public void LlenarGrid(object Grilla)
        {
            tareas.DtgConnect(Grilla);
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            NTarea NTarea = new NTarea();
            /* Antes de abrir el formulario para cargar una
             * nueva tarea, se transparenta el formulario padre*/
            
            OutTimer.Start();

           NTarea.ShowDialog();
            /*Luego de cerrar el formulario de carga de nueva tarea
             * el formulario padre vuelve al estado original*/
            InTimer.Start();
            LlenarGrid(dataGridView1);
           // MessageBox.Show(this.Opacity.ToString());
        }

        private void OutTimer_Tick(object sender, EventArgs e)
        {
            
            //si tiene mas del 30% de opacidad le resto opacidad
            if (this.Opacity > 0.3) this.Opacity -= 0.1;
            //paro el timer en 30%
            if (this.Opacity <= 0.3) OutTimer.Stop();
        }

        private void InTimer_Tick(object sender, EventArgs e)
        {

            //si tiene menos del 100% de opacidad le sumo 10%
            if (this.Opacity < 1) this.Opacity += 0.1;
            //paro el timer en 100%
            if (this.Opacity == 1) InTimer.Stop();
          
        }
    }
}
