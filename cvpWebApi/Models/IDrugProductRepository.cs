using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IDrugProductRepository
    {
        IEnumerable<DrugProduct> GetAll();
        DrugProduct Get(int id);
        IEnumerable<DrugProduct> Get(string drugName);
        // DrugProduct Add(DrugProduct drugProduct);
        // void Remove(int id);
        // bool Update(DrugProduct drugProduct);
    }
}
