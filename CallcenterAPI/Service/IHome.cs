using CallcenterAPI.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
   public interface IHome:ISecurity
    {
        Task<ReplyViewModel> LoadHome(int idUser);
    }
}
