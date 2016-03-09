using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportDrugIndicationRepository
    {
        IEnumerable<ReportDrugIndication> GetAll();
        ReportDrugIndication Get(int id);
    }
}
