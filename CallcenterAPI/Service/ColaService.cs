using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CallcenterAPI.Service
{
 
    public class ColaService : SecurityLayer, IColas
    {
        private readonly callcenterEntities db;
        private ReplyViewModel reply;

        public ColaService(callcenterEntities pDb):base(pDb)
        {
            this.db = pDb;
            reply = new ReplyViewModel();
        }

        

        public async Task<ReplyViewModel> Llamar(int idUser)
        {
            try
            {
                DateTime hoy = DateTime.Now.Date;
                var Call = await (from d in db.llamados
                            where d.idusuario == idUser && d.fecha == hoy && d.idstate == 2
                            select new ColaViewModel
                            {
                                idLlamado = d.idllamado,
                                idPersona = d.idpersona,
                                idState = d.idstate,
                                idProducto=d.idproducto,
                                tipouser = d.usuarios.idtipouser,
                                nombre = d.personas.nombre,
                                cuil = d.personas.cuil,
                                rnos = d.personas.codem.nombre.Substring(0, 85),
                                telefono1 = d.personas.telefono1,
                                telefono2 = d.personas.telefono2,
                                telefono3 = d.personas.telefono3,
                                telefono4 = d.personas.telefono4,
                                aportes = d.personas.aportes,
                                noapto = d.personas.apto,
                                conformeos = d.personas.conformeos,
                                cambioOS = d.personas.cambioos.ToString(),
                                producto=d.productos.producto
                                

                            }).FirstOrDefaultAsync();

                if (Call != null)
                {
                    if (Call.noapto == true)
                    {
                        Call.noapto = false;

                    }
                    else if (Call.noapto == false)
                    {
                        Call.noapto = true;
                    }
                    reply.data = Call; reply.result = 1; reply.message = "En cola";

                }
                else
                {
                    //DateTime hoy = DateTime.Now.Date;
                    Call = await (from d in db.llamados
                                where d.idusuario == idUser && d.fecha == hoy && d.idstate == 1
                                select new ColaViewModel
                                {
                                    idLlamado = d.idllamado,
                                    idPersona = d.idpersona,
                                    idState = d.idstate,
                                    idProducto = d.idproducto,
                                    tipouser = d.usuarios.idtipouser,
                                    nombre = d.personas.nombre,
                                    cuil = d.personas.cuil,
                                    rnos = d.personas.codem.nombre.Substring(0, 85),
                                    telefono1 = d.personas.telefono1,
                                    telefono2 = d.personas.telefono2,
                                    telefono3 = d.personas.telefono3,
                                    telefono4 = d.personas.telefono4,
                                    aportes = d.personas.aportes,
                                    noapto = d.personas.apto,
                                    conformeos = d.personas.conformeos,
                                    cambioOS = d.personas.cambioos.ToString(),
                                    producto = d.productos.producto

                                }).FirstOrDefaultAsync();

                    if (Call != null)
                    {
                        if (Call.noapto == true)
                        {
                            Call.noapto = false;

                        }
                        else if (Call.noapto == false)
                        {
                            Call.noapto = true;
                        }

                        reply.data = Call; reply.result = 1; reply.message = "En cola";
                        Call.idState = 2;
                       await  UpdateCall(Call);
                    }
                    else
                    {
                        Call = await (from d in db.llamados
                                where d.idusuario == idUser && d.fecha == hoy && d.idstate == 3
                                select new ColaViewModel
                                {
                                    idLlamado = d.idllamado,
                                    idPersona = d.idpersona,
                                    idState = d.idstate,
                                    idProducto = d.idproducto,
                                    tipouser = d.usuarios.idtipouser,
                                    nombre = d.personas.nombre,
                                    cuil = d.personas.cuil,
                                    rnos = d.personas.codem.nombre,
                                    telefono1 = d.personas.telefono1,
                                    telefono2 = d.personas.telefono2,
                                    telefono3 = d.personas.telefono3,
                                    telefono4 = d.personas.telefono4,
                                    aportes = d.personas.aportes,
                                    noapto = d.personas.apto,
                                    conformeos = d.personas.conformeos,
                                    cambioOS = d.personas.cambioos.ToString(),
                                    producto = d.productos.producto
                                }).FirstOrDefaultAsync();

                        if (Call != null)
                        {
                            if (Call.noapto == true)
                            {
                                Call.noapto = false;

                            }
                            else if (Call.noapto == false)
                            {
                                Call.noapto = true;
                            }
                            reply.data = Call; reply.result = 1; reply.message = "Pendiente";
                            Call.idState = 2;
                           await  UpdateCall(Call);
                        }
                        else
                        {
                            reply.result = 0;
                            reply.message = "No Tiene Llamados a Realizar";
                        }
                    }

                
                   
                }

                    
            }
            catch(Exception ex)
            {
                reply.result = 0;
                reply.message = "Ocurrio un Error";
            }

            return reply;
        }

        //actualiza los datos de la llamada y la persona
        public async Task<bool> UpdateCall(ColaViewModel pllamada)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var hoy = DateTime.Now.Date;

                    var llamada = db.llamados.Where(x => x.idllamado == pllamada.idLlamado).FirstOrDefault();
                    llamada.idstate = pllamada.idState;
                    llamada.intentos += 1;
                    llamada.hora = DateTime.Now.TimeOfDay;

                    db.Entry(llamada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    var persona = db.personas.Where(x => x.idpersona == pllamada.idPersona).FirstOrDefault();
                    
                    if (pllamada.idState == 3||pllamada.idState==5)
                    {
                        persona.lastcall = hoy;

                    }
                    else if (pllamada.idState == 4)
                    {
                        persona.lastcall = hoy;
                        persona.lastcom = hoy;
                    }
                   
                    if (pllamada.noapto == true)
                    {
                        var apto = false;
                        persona.apto = apto;

                    }
                    else if(pllamada.noapto == false)
                    {
                        var apto = true;
                        persona.apto = apto;
                    }

                    if (pllamada.idState != 2)
                    {
                        if (persona.used == false) persona.used = true;

                        persona.conformeos = pllamada.conformeos;
                        persona.aportes = pllamada.aportes;
                    }
                    
                    
                    if(pllamada.cambioOS!=null)
                    persona.cambioos = DateTime.Parse(pllamada.cambioOS);

                    db.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    db.SaveChanges();
                   await  transaction.CommitAsync();
                    return true;
                }

            catch (Exception ex)
            {
                    transaction.Rollback();
                return false;
            }
        }
        }

        public async Task<ReplyViewModel> VerCola(int iduser)
        {
            

            try
            {
                var hoy = DateTime.Now.Date;
                var Consulta= await (from d in db.llamados
                              where d.idusuario == iduser && d.fecha == hoy
                              select new ColaViewModel
                              {
                                  idLlamado=d.idllamado,
                                  idPersona = d.idpersona,
                                  idState=d.idstate,
                                  nombre = d.personas.nombre,
                                  cuil = d.personas.cuil,
                                  rnos = d.personas.codem.nombre.Substring(0,85),
                                  telefono1 = d.personas.telefono1,
                                  telefono2 = d.personas.telefono2,
                                  producto=d.productos.producto
                              }).ToListAsync();
                if (Consulta.Count() > 0)
                {
                    reply.data = Consulta;
                    reply.result = 1;
                    reply.message = "Se Encontro "+ Consulta.Count().ToString()+ " Registros";
                }
                else
                {
                    reply.result = 0;
                    reply.message = "No se Encontraron Registros";
                }
               
            }
            catch(Exception ex)
            {
                reply.result = 0;
                reply.message = "Ocurrio un Error";
            }
                 


            return reply;
        }
    }
}
