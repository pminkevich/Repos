using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;

namespace CallcenterAPI.Service
{
   public interface IAgenda:ISecurity,ICall
    {

        Task<bool> SendInfo(int idUser,ColaViewModel llamada);
        Task<bool> CheckPeople(int idUser, ColaViewModel llamada);
        ReplyViewModel GetData(int idUser);

    }
}
