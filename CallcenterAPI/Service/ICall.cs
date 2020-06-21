using CallcenterAPI.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public interface ICall
    {
         Task<bool> GoToCall<T>(int idUser, T allamar);
    }
}
