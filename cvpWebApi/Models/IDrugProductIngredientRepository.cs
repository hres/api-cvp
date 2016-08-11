using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IDrugProductIngredientRepository
    {
        IEnumerable<DrugProductIngredient> GetAll(string lang);
        DrugProductIngredient Get(int id, string lang);
    }
}
