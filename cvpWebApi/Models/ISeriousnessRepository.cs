using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface ISeriousnessRepository
    {
        IEnumerable<Seriousness> GetAll(string lang);
        Seriousness Get(int id, string lang);
    }
}
