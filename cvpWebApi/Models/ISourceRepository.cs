using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface ISourceRepository
    {
        IEnumerable<Source> GetAll(string lang);
        Source Get(int id, string lang);
    }
}
