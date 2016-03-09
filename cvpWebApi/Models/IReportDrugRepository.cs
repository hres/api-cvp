using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportDrugRepository
    {
        IEnumerable<ReportDrug> GetAll();
        ReportDrug Get(int id);
    }
}
