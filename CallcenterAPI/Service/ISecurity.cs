using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallcenterAPI.Service
{
    public interface ISecurity
    {
        int CheckToken(string token);
    }
}
