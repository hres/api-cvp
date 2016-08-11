using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportLinksRepository
    {
        IEnumerable<ReportLinks> GetAll(string lang);
        ReportLinks Get(int id, string lang);
    }
}
