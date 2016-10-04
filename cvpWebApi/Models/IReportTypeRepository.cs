using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportTypeRepository
    {
        IEnumerable<ReportType> GetAll(string lang);
        ReportType Get(int id, string lang);
    }
}
