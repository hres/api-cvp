using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IOutcomeLxRepository
    {
        IEnumerable<OutcomeLx> GetAll(string lang);
        OutcomeLx Get(int id, string lang);
    }
}
