using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IOutcomeRepository
    {
        IEnumerable<Outcome> GetAll(string lang);
        Outcome Get(int id, string lang);
    }
}
