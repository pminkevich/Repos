﻿using System;
using System.Collections;
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
    public partial class AdminForm : Form
    {
        private Admin.Control AdminController;
        private Admin.Videos Videos;
        private string Estado;
        

        public AdminForm()
        {
            InitializeComponent();
            AdminController = new Admin.Control();
            Videos = new Admin.Videos();
            AdminController.EventState += Control_ChangeState;
            
        }
        //Metodo que se ejecuta cuando se consulta el estado del SISTEMA
        private void Control_ChangeState(object sender, Admin.StateEventArgs e)
        {
            Estado = e.State;

            if (Estado == "Down")
            {
                
                btnDeshabilitar.Visible = false;
                lblStatus.Text = "Down";
                lblStatus.ForeColor = Color.Red;
                lblStatus.Visible = true;

            }
            else
            {
                btnDeshabilitar.Visible = true;
                lblStatus.Text = "Up";
                lblStatus.ForeColor = Color.Green;
                lblStatus.Visible = true;
            }

        }
        //BOTON PARA AGREGAR CANAl, :-)
        private async void button1_Click(object sender, EventArgs e)
        {
            string channel = txtChannel.Text;
            //int Agregados= await Videos.AgregarChannel(channel);
            txtChannel.Text = "Agregando...";
            int Agregados = await Videos.AgregarPlayList(channel);
            txtChannel.Text = "";

            if (Agregados == 0)
            {
                MessageBox.Show("No se encontraron Videos");
            }
            else
            {
                ShowLabel(Agregados);
                
            }

           
            
        }
        //metodo para mostrar por 3 segundos los videos que se agregaron
        private void ShowLabel(int agregados)
        {
            lblAgregados.Text += " " + agregados.ToString()+ " Videos";
            lblAgregados.Visible = true;
            //txtChannel.Text = "Se agregaron " + agregados.ToString() +" Videos";
            TimerText.Start();
            ActLabels();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ActLabels();
            AdminController.State();

        }
        //Metodo para cargar los datos en los labels
        public void ActLabels()
        {
            lblVistos.Text = Videos.Vistos().ToString();
            lblVistos.Visible = true;
            lblVer.Text = Videos.PorVer().ToString();
            lblVer.Visible = true;
        }
        
        //para el sistema
        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            AdminController.Stop();
            

        }
        //Habilita el sistema
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            AdminController.Start();
           

        }

        

       

       
        private void TimerIn_Tick(object sender, EventArgs e)
        {
            //si tiene menos del 100% de opacidad le sumo 10%
            if (this.Opacity < 1) this.Opacity += 0.1;
            //paro el timer en 100%
            if (this.Opacity == 1) TimerIn.Stop();
        }

        private void TimerOut_Tick(object sender, EventArgs e)
        {
            //si tiene mas del 50% de opacidad le resto opacidad
            if (this.Opacity > 0.5) this.Opacity -= 0.1;
            //paro el timer en 50%
            if (this.Opacity <= 0.5) TimerOut.Stop();
        }

        private void btnAjuste_Click(object sender, EventArgs e)
        {
            FrmAjuste Ajuste = new FrmAjuste();

            
            /*Antes de abrir el formulario se realiza
            un efecto de desvanecimiento*/
            TimerOut.Start();
            Ajuste.ShowDialog();
            /*Se restablece la opacidad del formulario*/
            TimerIn.Start();
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCuenta Cuenta = new FrmCuenta();


            /*Antes de abrir el formulario se realiza
            un efecto de desvanecimiento*/
            TimerOut.Start();
            Cuenta.ShowDialog();
            /*Se restablece la opacidad del formulario*/
            TimerIn.Start();
        }

        private void TimerText_Tick(object sender, EventArgs e)
        {

            
            lblAgregados.Text = "Se Agregaron";
            lblAgregados.Visible = false;
            txtChannel.Text = "";
            TimerText.Stop();
       


        }

       
    }
}
