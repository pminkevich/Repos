using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class AgendaService :Call,IAgenda
    {
        private readonly callcenterEntities db;
        private ReplyViewModel reply;

        public AgendaService(callcenterEntities pDb) : base(pDb)
        {
            this.db = pDb;
            reply = new ReplyViewModel();
        }
        public ReplyViewModel GetData(int idUser)
        {
            try
            {

                var hoy = DateTime.Now.Date;
                var result = from d in db.agenda
                             where d.idusuario == idUser && EF.Functions.DateDiffDay(d.fecha, hoy) < 4 
                             select new AgendaViewModel
                             {
                                 idPersona = (int)d.idpersona,
                                 idProducto=d.idproducto,
                                 nombre=d.personas.nombre,
                                 fecha = d.fecha.ToString(),
                                 hora = d.hora.ToString(@"hh\:mm"),
                                 comentario = d.comentario,
                                 estado = d.idstate

                             };

                if (result.Count() > 0)
                {
                    reply.result = 1; reply.message = "Tiene " + result.Count() + " Personas en Agenda";
                    reply.data = result;
                }
                else
                {
                    reply.result = 0; reply.message = "No Tiene Personas Agendadas";
                }
            }
            catch (Exception ex)
            {
                reply.result = 0; reply.message = "Ocurrio un Error";
            }
            return reply;
        }
        public async Task<bool> CheckPeople(int idUser, ColaViewModel llamada)
        {
            bool state = false;
            try
            {
                var Agendar = new agenda();
                Agendar.idusuario = idUser;
                Agendar.idpersona = llamada.idPersona;
                Agendar.idproducto = 1;
                Agendar.fecha = DateTime.Now.Date;
                Agendar.hora = DateTime.Now.Date.TimeOfDay;
                Agendar.idstate = 1;
                Agendar.comentario = "Para Verificar";

                db.Add(Agendar);
                await db.SaveChangesAsync();

                state = true;
            }
            catch(Exception ex)
            {

                state = false;
            }
            return state;
        }

      
        public async Task<bool> SendInfo(int idUser, ColaViewModel llamada)
        {
            bool state = false;
            try
            {
                var Agendar = new agenda();
                Agendar.idusuario = idUser;
                Agendar.idpersona = llamada.idPersona;
                Agendar.idproducto = 1;
                Agendar.fecha = DateTime.Now.Date;
                Agendar.hora = DateTime.Now.Date.TimeOfDay;
                Agendar.idstate = 1;
                Agendar.comentario = "Enviar Cartilla";

                db.Add(Agendar);
                await db.SaveChangesAsync();

                state = true;
            }
            catch (Exception ex)
            {

                state = false;
            }
            return state;
        }
    }
}
