using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IGenderRepository
    {
        IEnumerable<Gender> GetAll(string lang);
        Gender Get(int id, string lang);
    }
}
