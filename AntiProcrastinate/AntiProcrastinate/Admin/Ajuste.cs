using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiProcrastinate.Admin
{
      class AjusteEventArgs : EventArgs
    {
        public int OcioTime { get; set; }
        public int APTime { get; set; }
    }
     class Ajuste
    {
        public delegate void ChangeAjusteEventHandler(object sender, AjusteEventArgs e);
        public event ChangeAjusteEventHandler ChangePreset;


        public void AdjModo(string Modo)
        {
            switch (Modo)
            {
                case "Predeterminado":
                    SetTime(20, 5);
                    break;
                case "Moderado":
                    SetTime(30, 6);
                    break;
                case "Aprendizaje":
                    SetTime(5, 20);
                    break;
                case "Puro Ocio":
                    SetTime(180, 0);
                    break;
                case "AP Moderado":
                    SetTime(30, 10);
                    break;
                case "Sin Ocio":
                    SetTime(0, 180);
                    break;
                
            }
        }
        //Metodo para grebar en bd el tiempo de ocio y de Anti Procrastine
        public void SetTime(int OcioTime,int APTime)
        {
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {

                    Model.AntiP AP = db.AntiP.First();

                    AP.OcioTime=OcioTime;
                    AP.APTime = APTime;

                    db.Entry(AP).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    var e = new AjusteEventArgs();
                    e.OcioTime = OcioTime;
                    e.APTime = APTime;

                    ChangePreset(this, e);

                }
            }
            //cath para saber sobre error en Entity Framework
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
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
        }





    }
}
