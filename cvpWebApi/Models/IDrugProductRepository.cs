using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IDrugProductRepository
    {
        IEnumerable<DrugProduct> GetAll(string lang);
        DrugProduct Get(int id, string lang);
        //IEnumerable<DrugProduct> Get(string drugName, string lang);
 
    }
}
