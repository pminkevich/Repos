using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Model.ViewModel
{
    public class HomeViewModel:SecurityViewModel
    {
        public int llamados { get; set; }
        public int seguimientos { get; set; }
        public int agenda { get; set; }
        public int operaciones { get; set; }
    }
}
