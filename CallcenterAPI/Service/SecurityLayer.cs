using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class SecurityLayer
    {
        private readonly callcenterEntities db;
        public SecurityLayer(callcenterEntities pdb)
        {
            this.db = pdb;
        }

        public int CheckToken(string token)
        {

            try
            {
                if (token != null)
                {
                    var result = db.usuarios.Where(x => x.token == token && x.idstate == 1).FirstOrDefault();
                    if (result != null)
                        return result.iduser;
                }
                    
               
            }
            catch(Exception ex)
            {

            }
            

            return 0;
        }
    }
}
