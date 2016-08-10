using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportRepository
    {
        IEnumerable<Report> GetAll();
        Report GetReportByID(string id, string lang);
        IEnumerable<Report> GetReportByCriteria(string reportId, string lang);
    }
}
