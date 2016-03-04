using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportInfoRepository
    {
        IEnumerable<ReportInfo> GetAll();
        ReportInfo Get(int id);
        IEnumerable<ReportInfo> Get(string drugName);
        // ReportInfo Add(ReportInfo report);
        // void Remove(int id);
        // bool Update(ReportInfo report);
    }
}
