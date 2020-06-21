using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class SeguimientosService : Call,ISeguimiento
    {
        private readonly callcenterEntities db;
        private ReplyViewModel reply;

        public SeguimientosService(callcenterEntities pDb):base(pDb)
        {
            this.db = pDb;
            reply = new ReplyViewModel();
        }

       

        private bool TieneSeg(int idPersona)
        {
            bool state = false;
            try
            {
                var Seg = db.seguimientos.Where(x => x.idpersona == idPersona).Count();
                if (Seg > 0) return state = true;
                
            }
            catch(Exception ex)
            {
                
            }
            return state;
        }
        public async Task<ReplyViewModel> AgregarSeg(int idUser, SeguimientoViewModel seguimiento)
        {
           
            try
            {
                if (!TieneSeg(int.Parse(seguimiento.idPersona.ToString())))
                {
                    DateTime hora = DateTime.Parse(seguimiento.Hora);
                    var Seg = new seguimientos();
                    Seg.idusuario = idUser;
                    Seg.idpersona = seguimiento.idPersona;
                    Seg.idproducto = 1;
                    Seg.fecha = DateTime.Parse(seguimiento.Fecha);
                    Seg.hora = TimeSpan.Parse(hora.ToString("HH:mm"));
                    Seg.comentario = seguimiento.Comentario;
                    Seg.fechaseg = DateTime.Now.Date;
                    Seg.idstate = 1;


                    db.Add(Seg);
                    await db.SaveChangesAsync();

                    reply.result = 1;reply.message = "Se Agrego el Seguimiento";

                    
                }
                else
                {
                    reply.result = 0; reply.message = "Ya Hay Un Seguimiento para esta Persona";
                }
               
            }
            catch (Exception ex)
            {
                reply.result = 0; reply.message = "Ocurrio Un error";

            }
            return reply;
        }

        public async Task<ReplyViewModel> GetData(int idUser)
        {
            try
            {
                
                var hoy = DateTime.Now.Date;
                var result = await (from d in db.seguimientos
                             where d.idusuario == idUser && d.fecha == hoy && d.idstate==1
                             select new SeguimientoViewModel
                             {
                                 idSeg=d.idseg,
                                 Fecha = d.fecha.ToString(),
                                 Hora = d.hora.ToString(@"hh\:mm"),
                                 Comentario=d.comentario,
                                 idPersona=d.idpersona,
                                 nombre=d.personas.nombre,
                                 idProducto=d.idproducto,
                                 producto=d.productos.producto
                                 
                              
                             }).ToListAsync();

                if (result.Count() > 0)
                {
                    reply.result = 1;reply.message = "Tiene " + result.Count() + " Seguimientos";
                    reply.data = result;
                }
                else
                {
                    reply.result = 0;reply.message = "No Tiene Seguimientos";
                }
            }
            catch(Exception ex)
            {
                reply.result = 0;reply.message = "Ocurrio un Error";
            }
            return reply;
        }

        public void Home(int idUser)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateSeg(SeguimientoViewModel seguimiento)
        {
            bool state = false;
            try
            {
                var Seg = db.seguimientos.Where(x => x.idseg == seguimiento.idSeg).FirstOrDefault();

                if (Seg != null)
                {
                    Seg.idstate = seguimiento.idSegState;
                    Seg.fecha = DateTime.Parse(seguimiento.Fecha);
                    Seg.hora = TimeSpan.Parse(seguimiento.Hora);
                    Seg.comentario = seguimiento.Comentario;
                    db.Entry(Seg).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                    state = true;
                }
                

                
            }
            catch (Exception ex)
            {

                state = false;
            }
            return state;
        }

        
    }
}
