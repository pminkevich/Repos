using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
   public interface IColas: ISecurity
    {


        Task<ReplyViewModel> VerCola(int idUser);
        Task<ReplyViewModel> Llamar(int idUser);
        Task<bool> UpdateCall(ColaViewModel llamada);
    }
}
