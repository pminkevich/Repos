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
        private YouTubeAPI Get(string channel)
        {
            //url del Json
            var json = new WebClient().DownloadString("https://www.googleapis.com/youtube/v3/search?order=date&part=snippet&channelId=" + channel + "&maxResults=50&key=API KEY YOUTUBE");
            //Vuelco el Json a YoutubeAPI
            YouTubeAPI obj = JsonConvert.DeserializeObject<YouTubeAPI>(json);
            return obj;
        }
        public async Task<int> AgregarChannel(string channel)
        {
            int total=0;
            await Task.Run(()=> {

                var obj= Get(channel);
                total = ((ICollection)obj.items).Count;
                GuardarChannel(obj,total);
                

            });
            return total;

            
        }

        private void GuardarChannel(YouTubeAPI obj,int total)
        {
            List<Model.Videos> Videos = new List<Model.Videos>();
            try
            {
                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {
                    for (int i = 0; i < total; i++)
                    {

                        Model.Videos Video = new Model.Videos();

                        Video.Id_Video = obj.items[i].id.videoId;
                        Video.Nombre = obj.items[i].snippet.title;
                        Video.Url = "https://www.youtube.com/embed/" + obj.items[i].id.videoId;
                        Video.ESTADO = "Listo";
                        Videos.Add(Video);



                    }
                    if (total > 0)
                    {
                        db.Videos.AddRange(Videos);
                        // db.Entry(Videos).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                    //return total;

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
                //return total;
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex

                ); // Add the original exception as the innerException



            }
            catch (Exception ex)
            {
                string Error = ex.Message;
               // return total;
            }
        }

        public int Vistos()
        {
            int Vistos;
            try
            {
                
                using (Model.AntiProcrastineEntities db= new Model.AntiProcrastineEntities())
                {
                    
                    Vistos = db.Videos.Where(x => x.ESTADO == "Visto").Count();
                    
                }
            }
            catch (Exception)
            {
                Vistos = 0;
                throw;
                
            }

            return Vistos;

        }
        public int PorVer()
        {
            int PorVer;
            try
            {

                using (Model.AntiProcrastineEntities db = new Model.AntiProcrastineEntities())
                {

                    PorVer= db.Videos.Where(x => x.ESTADO == "Listo").Count();

                }
            }
            catch (Exception)
            {
                PorVer = 0;
                throw;

            }

            return PorVer;
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
