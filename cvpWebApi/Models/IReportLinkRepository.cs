using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportLinkRepository
    {
        IEnumerable<ReportLink> GetAll(string lang);
        ReportLink Get(Int64 id, string lang);
    }
}
