using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportDrugRepository
    {
        IEnumerable<ReportDrug> GetAll(string lang);
        ReportDrug Get(int id, string lang);
        IEnumerable<ReportDrug> GetReportDrugById(string reportId, string lang);

    }
}
