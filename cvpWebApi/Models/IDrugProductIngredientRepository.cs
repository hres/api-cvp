using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IDrugProductIngredientRepository
    {
        IEnumerable<DrugProductIngredient> GetAll();
        DrugProductIngredient Get(int id);
        // DrugProductIngredient Add(DrugProductIngredient drugProductIngredient);
        // void Remove(int id);
        // bool Update(DrugProductIngredient drugProductIngredient);
    }
}
