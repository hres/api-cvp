using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportTypeLxRepository
    {
        IEnumerable<ReportTypeLx> GetAll(string lang);
        ReportTypeLx Get(int id, string lang);
    }
}
