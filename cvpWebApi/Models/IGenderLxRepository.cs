using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IGenderLxRepository
    {
        IEnumerable<GenderLx> GetAll(string lang);
        GenderLx Get(int id, string lang);
    }
}
