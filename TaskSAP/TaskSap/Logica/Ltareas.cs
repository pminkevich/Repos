using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskSap.Modelo;

namespace TaskSap.Logica
{
    class Ltareas
    {
        

        public Ltareas()
        {
           
        }

        public void DtgConnect(object Grilla)
        {
           
            using (tareasEntities db= new tareasEntities())
            {
                ((DataGridView)Grilla).DataSource = db.tareas.ToList();
            }
        }

        public bool Validar(object[] Textos, object[] Labels)
        {
            bool Valida = true;   
            for (int i = 0; i < Textos.Length; i++)
            {
                if (((TextBox)Textos[i]).Text == string.Empty)
                {
                    //((Label)Labels[i]).Text = " Ingrese Un Dato";
                    //((Label)Labels[i]).ForeColor = Color.Red;
                    ((Label)Labels[i]).Visible = true;
                    Valida = false;
                }
                
                   
            }
            return Valida;
        }
        public string NTarea(object[] Textos, object Date)
        {
            string rpta = "";
            try
            {
                using (tareasEntities db = new tareasEntities())
                {
                    tareas tarea = new tareas();
                    tarea.titulo = ((TextBox)Textos[0]).Text;
                    tarea.descripcion = ((TextBox)Textos[1]).Text;
                    tarea.fecha = ((DateTimePicker)Date).Value;
                    tarea.telefono = Convert.ToInt32(((TextBox)Textos[2]).Text);
                    tarea.estado = "CREADO";
                    db.tareas.Add(tarea); 
                    db.SaveChanges();
                   
                    rpta = "OK";



                }
                return rpta;
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex

                ); // Add the original exception as the innerException

               
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                rpta = e.Message;
                return rpta;
            }

            
        }

        
    }
}
