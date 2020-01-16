using AntiProcrastinate.Antip;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace AntiProcrastinate.Admin
{
      class StateEventArgs : EventArgs
    {
        public string State { get; set; }
    }

    class Control
    {
        public delegate void StateEventHandler(object sender, StateEventArgs e);
        public event StateEventHandler EventState;
        

       // public Ajuste Preset;

        public Control()
        {
            //Preset = new Ajuste();
            
            

        }
        
        public void Start()
        {
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {
                   
                    Model.AntiP AP = db.AntiP.First();
                    
                    //if (AP.State == "Down")
                        AP.State = "Up";
                   
                    db.Entry(AP).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    var e = new StateEventArgs();
                    e.State = "Up";
                    EventState(this, e);

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
        public void State()
        {
         string State = "";
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {
                    //Reviso el Estado de ANTI PROCRASTINE
                    // y Lo agrego el StateEventArgs
                    Model.AntiP AP = db.AntiP.First();
                    State = AP.State.ToString();
                    var e = new StateEventArgs();
                    e.State = State;
                    EventState(this, e);
                    


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
                State = ex.Message;
            }

            //return State;
        }
        public void Stop()
        {
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {

                    Model.AntiP AP = db.AntiP.First();

                    //if (AP.State == "Down")
                    AP.State = "Down";

                    db.Entry(AP).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    var e = new StateEventArgs();
                    e.State = "Down";
                    EventState(this, e);

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
