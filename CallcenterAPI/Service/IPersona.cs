using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public interface IPersona
    {
        //Para Futuras Actualizaciones (no Implementado)
        void GetData();
        void Seguimientos();
        bool UpdatePeople();
        bool AddBlackList(int pIdPersona, string pMotivo);
        bool AddPeople();

    }
}
