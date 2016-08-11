using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface ISourceLxRepository
    {
        IEnumerable<SourceLx> GetAll(string lang);
        SourceLx Get(int id, string lang);
    }
}
