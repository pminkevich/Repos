using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Cumpleañeros
{
    public partial class NArea : Form
    {
       
        public NArea()
        {
            InitializeComponent();
            
        }
        private bool Validar(string pArea)
        {
            Regex Exp = new Regex("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$");
            return Exp.IsMatch(pArea);



        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarArea_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (txtArea.Text != string.Empty)
                {
                    if (Validar(txtArea.Text))
                    {
                        DataTable Areas = new DataTable("Areas");
                        Areas = nArea.Mostrar();
                        bool Duplicada = false;
                        foreach(DataRow Fila in Areas.Rows)
                        {

                            string Area = Fila["Nombre"].ToString();

                            if(Area!= txtArea.Text)
                            {
                                Duplicada = false; 
                            }
                            else
                            {
                                Duplicada = true;
                            }
                        }
                        if (Duplicada == false)
                        {
                            rpta = nArea.Insertar(txtArea.Text.Trim().ToUpper());
                            if (rpta == "OK")
                            {
                                MessageBox.Show("Se Agrego el Area a La lista", "Cumpleañero 1.0");
                            }
                            else
                            {
                                MessageBox.Show(rpta);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Area ya esta en la Base de Datos", "Cumpleañero 1.0",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una Cadena de Texto","Cumpleañero 1.0");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ingrese el Nombre del Area", "Cumpleañero 1.0");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
