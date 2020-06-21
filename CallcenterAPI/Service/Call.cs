using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class Call:SecurityLayer
    {
        private readonly callcenterEntities db;
        public Call(callcenterEntities pdb):base(pdb)
        {
            this.db = pdb;
        }

        public async Task<bool> GoToCall<T>(int idUser, T model)
        {
            bool state = false;
            //uso reflexion
            PropertyInfo personaid = model.GetType().GetProperty("idPersona");
            PropertyInfo productoid = model.GetType().GetProperty("idProducto");

            int idPersona = int.Parse(personaid.GetValue(model).ToString());
            int idProducto = int.Parse(productoid.GetValue(model).ToString());

     
            using (var transaction = db.Database.BeginTransaction())
            {

                try
                {
                    DateTime hoy = DateTime.Now.Date;
                    var enCola = db.llamados.Where(x => x.fecha == hoy && x.idusuario == idUser && x.idpersona == idPersona);
                    var llamando = db.llamados.Where(x => x.fecha == hoy && x.idusuario == idUser && x.callstate.valor == "llamando");


                    if (llamando.Count() > 0)
                    {
                        //paso el estado a  en cola

                        var llamandoahora = llamando.FirstOrDefault();
                        llamandoahora.idstate = 1;
                        db.Entry(llamandoahora).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }

                    if (enCola.Count() > 0)
                    {
                        //cambio el estado a llamando
                        var llamadoencola = enCola.FirstOrDefault();
                        llamadoencola.idstate = 2;
                        db.Entry(llamadoencola).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {


                        //agrego el seguimiento a la cola de hoy
                        var newcall = new llamados();
                        newcall.idusuario = idUser;
                        newcall.idpersona = idPersona;//seguimiento.idPersona;
                        newcall.idproducto = idProducto;//seguimiento.idProducto;
                        newcall.idargumento = 3;
                        newcall.idstate = 2;
                        newcall.fecha = DateTime.Now;
                        newcall.hora = DateTime.Now.TimeOfDay;
                        db.Add(newcall);
                        db.SaveChanges();
                    }

                    await transaction.CommitAsync();
                    state = true;

                }
                catch (Exception ex)
                {

                }
            }

            return state;
        }

    }
}
