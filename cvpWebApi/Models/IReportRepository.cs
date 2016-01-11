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
        Report Get(int id);
        // Report Add(Report report);
        // void Remove(int id);
        // bool Update(Report report);
    }
}
