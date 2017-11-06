using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReactionRepository
    {
        IEnumerable<Reaction> GetAll(string lang);
        Reaction Get(Int64 id, string lang);
        IEnumerable<Reaction> GetReactionByReportId(string reportId, string lang);
    }
}
