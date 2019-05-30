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
    public partial class NCargo : Form
    {
        private int Idarea;
        public NCargo(int pIdarea)
        {
            InitializeComponent();
            Idarea = pIdarea;
        }

        private bool Validar(Form Form,string pCargo)
        {
            bool Valido;
            if (txtNombre.Text != string.Empty)
            {
                Valido = true;
                errorProvider1.SetError(txtNombre, "");
                if (txtValor.Text != string.Empty)
                {
                    Valido = true;
                    errorProvider1.SetError(txtValor, "");
                }
                else
                {
                    Valido = false;
                    errorProvider1.SetError(txtValor, "Ingrese un Valor");
                }
            }
            else
            {
                Valido = false;
                errorProvider1.SetError(txtNombre, "Ingrese un Valor");
            }
            return Valido;
            

        }
        private bool Istexto(string pCargo)
        {
            Regex Exp = new Regex("^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$");
            return Exp.IsMatch(pCargo);
        }
        private bool Isnumero(string pArea)
        {
            
                Regex Exp = new Regex("[^0-9]");
                return !Exp.IsMatch(pArea);
            
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
                if (Validar(this, txtNombre.Text))
                {
                    if (Istexto(txtNombre.Text))
                    {
                        if (Isnumero(txtValor.Text))
                        {
                            DataTable Cargos = new DataTable();
                            Cargos = nCargo.Mostrar();
                            bool Duplicado = false;
                            foreach (DataRow Fila in Cargos.Rows)
                            {
                                string Cargo = Fila["Nombre"].ToString();
                              
                                if (Cargo != txtNombre.Text)
                                {
                                    Duplicado = false;
                                }
                                else
                                {
                                    Duplicado = true;
                                }
                            }
                            if (Duplicado == false)
                            {
                                rpta = nCargo.Insertar(Idarea, txtNombre.Text.Trim().ToUpper(),
                                                Convert.ToInt32(txtValor.Text));
                                if (rpta == "OK")
                                {
                                    MessageBox.Show("Se Ingreso Correctamente el Nuevo Cargo");
                                    
                                }
                                else
                                {
                                    MessageBox.Show(rpta);

                                }
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("El registro Ya esta en la Base de Datos", "No se puede Duplicar",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else
                        {
                            MessageBox.Show("El Valor tiene que ser Numerico", "Valor",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("El Valor tiene que ser Texto", "Nombre del Cargo",
                                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                    
                else
                {
                    MessageBox.Show("Ingrese un Valor");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
