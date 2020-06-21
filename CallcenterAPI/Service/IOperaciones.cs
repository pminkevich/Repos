using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public interface IOperaciones: ISecurity,ICall
    {
       

        Task<bool> AddOP(int idUser, OpViewModel operacion);
        void Home(int pageSelect = -1);
        bool UpdateOP();
        Task<ReplyViewModel> GetData(int idUser);
    }
}
