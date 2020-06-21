using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class OperacionesService : Call, IOperaciones
    {
        private readonly callcenterEntities db;
        private ReplyViewModel reply;

        public OperacionesService(callcenterEntities pDb):base(pDb) 
        {
            this.db = pDb;
            reply = new ReplyViewModel();
        }

        public async Task<bool> AddOP(int idUser,OpViewModel operacion)
        {
            bool state = false;
            using(var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var oPersona = db.personas.Where(x => x.idpersona == operacion.idPersona).FirstOrDefault();
                    oPersona.localidad = operacion.localidad;
                    oPersona.calle = operacion.calle;
                    oPersona.altura = operacion.altura.ToString();
                    oPersona.piso = operacion.piso.ToString();
                    oPersona.dpto = operacion.dpto;
                    db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    var Op = new cerrados();
                    DateTime hora = DateTime.Parse(operacion.hora);
                    Op.idpersona = operacion.idPersona;
                    Op.idproducto = 1;
                    Op.idusuario = idUser;
                    Op.idstate = 1;
                    Op.idargumento = 3;
                    Op.fechacierre = DateTime.Now.Date;
                    Op.fecha = DateTime.Parse(operacion.fecha);
                    Op.hora = TimeSpan.Parse(hora.ToString("HH:mm"));
                    Op.comentario = operacion.comentario;

                    db.Add(Op);
                    db.SaveChanges();

                    await transaction.CommitAsync();
                    state = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    state = false;
                }
            }
           
            return state;
        }

        public async Task<ReplyViewModel> GetData(int idUser)
        {
            try
            {

                var hoy = DateTime.Now.Date;
                var result = await (from d in db.cerrados
                             where d.idusuario == idUser && EF.Functions.DateDiffDay(d.fechacierre, hoy) <= 31 && d.idstate == 1
                             select new OpViewModel
                             {
                                 idOperacion = d.idcierre,
                                 fecha = d.fecha.ToString(),
                                 hora = d.hora.ToString(@"hh\:mm"),
                                 comentario = d.comentario,
                                 idPersona = (int)d.idpersona,
                                 nombre = d.personas.nombre,
                                 estado = d.closestate.valor
                                
                             }).ToListAsync();

                if (result.Count() > 0)
                {
                    reply.result = 1; reply.message = "Tiene " + result.Count() + " Operaciones";
                    reply.data = result;
                }
                else
                {
                    reply.result = 0; reply.message = "No Tiene Operaciones";
                }
            }
            catch (Exception ex)
            {
                reply.result = 0; reply.message = "Ocurrio un Error";
            }
            return reply;
        }

        public void Home(int pageSelect = -1)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOP()
        {
            throw new NotImplementedException();
        }
    }
}
