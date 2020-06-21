using CallcenterAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class UsuarioService : IUsuario
    {
        private readonly callcenterEntities db;
       
        public UsuarioService(callcenterEntities pDb)
        {
            this.db = pDb;
           
        }

        public string CreateToken(int IdUser)
        {
            string Token="";
            try
            {
                var oUser = db.usuarios.Where(x => x.iduser == IdUser).FirstOrDefault();
                Token = Guid.NewGuid().ToString();
                oUser.token = Token;



                db.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {
                Token = "";
            }
            return Token;
        }

        public ReplyViewModel login(AccessViewModel DataAcess)
        {
            ReplyViewModel reply = new ReplyViewModel();

            try
            {
                var result = db.usuarios.Where(x => x.usuario == DataAcess.User
                                               && x.password == DataAcess.Password&&x.idstate==1).FirstOrDefault();
                if (result!= null)
                {
                    int IdUser = result.iduser;
                    string Nombre = result.nombre.ToString();

                    

                    reply.result = 1;

                    reply.data = CreateToken(IdUser);
                    reply.message = "Bienvenido " + Nombre;
                }
                else
                {
                    reply.result = 0;
                    reply.message = "Datos Incorrectos";
                }
            }
            catch(Exception ex)
            {
                reply.data = ex.Message;
                reply.result = 0;
                reply.message = "Ocurrio Un Error";
            }
            return reply;
        }
    }
}
