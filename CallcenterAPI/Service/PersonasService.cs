using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public class PersonasService : IPersona
    {
        //Para Futuras Actualizaciones (no Implementado)
        private readonly callcenterEntities db;

        public PersonasService(callcenterEntities pDb)
        {
            this.db = pDb;
        }

        public bool AddBlackList(int pIdPersona, string pMotivo)
        {
            throw new NotImplementedException();
        }

        public bool AddPeople()
        {
            throw new NotImplementedException();
        }

        public void GetData()
        {
            throw new NotImplementedException();
        }

        public void Seguimientos()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePeople()
        {
            throw new NotImplementedException();
        }
    }
}
