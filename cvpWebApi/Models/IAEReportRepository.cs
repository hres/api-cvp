using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IAEReportRepository
    {
        IEnumerable<AEReport> GetAll(string lang);
        AEReport Get(int id, string lang);
        //IEnumerable<AEReport> Get(string drugName, string lang);

    }
}
