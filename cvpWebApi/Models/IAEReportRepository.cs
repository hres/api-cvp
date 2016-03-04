using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IAEReportRepository
    {
        IEnumerable<AEReport> GetAll();
        AEReport Get(int id);
        IEnumerable<AEReport> Get(string drugName);
        // DrugProduct Add(DrugProduct drugProduct);
        // void Remove(int id);
        // bool Update(DrugProduct drugProduct);
    }
}
