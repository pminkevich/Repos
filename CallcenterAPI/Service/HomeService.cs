using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CallcenterAPI.Service
{
    public class HomeService : SecurityLayer, IHome
    {
        private readonly callcenterEntities db;
        private ReplyViewModel reply;
        
        public HomeService(callcenterEntities pDb):base(pDb)
        {
            this.db = pDb;
            this.reply = new ReplyViewModel();

        }

        public async Task<ReplyViewModel> LoadHome(int idUser)
        {
            try
            {
                await Task.Run(() => 
                {
                                      
                    var hoy = DateTime.Now.Date;
                    var llamados = db.llamados.Where(x => x.idusuario == idUser && x.fecha == hoy).Where(x => x.idstate == 1 || x.idstate == 3).Count();
                    var seguimientos = db.seguimientos.Where(x => x.idusuario == idUser && x.fecha == hoy && x.idstate == 1).Count();
                    var agenda = db.agenda.Where(x => x.idusuario == idUser && EF.Functions.DateDiffDay(x.fecha, hoy) <= 4).Count();
                    var operaciones = db.cerrados.Where(x => x.idusuario == idUser && EF.Functions.DateDiffDay(x.fechacierre, hoy) <= 31).Count();

                    HomeViewModel Home = new HomeViewModel();
                    Home.agenda = agenda;
                    Home.llamados = llamados;
                    Home.seguimientos = seguimientos;
                    Home.operaciones = operaciones;

                    reply.data = Home; reply.result = 1; reply.message = "On Line";


                });
                
            }
            catch(Exception ex)
            {
                reply.result = 0; reply.message = "No se Pudo Cargar el Home";
            }

            return reply;
        }
    }
}
