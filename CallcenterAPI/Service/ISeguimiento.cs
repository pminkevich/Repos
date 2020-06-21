using CallcenterAPI.Model;
using CallcenterAPI.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public interface ISeguimiento:ISecurity,ICall
    {


        Task<ReplyViewModel> AgregarSeg(int idUser,SeguimientoViewModel Seg);
        Task<ReplyViewModel> GetData(int idUser);
        Task<bool> UpdateSeg(SeguimientoViewModel Seg);
        void Home(int idUser);//no implementado
       
    }
}
