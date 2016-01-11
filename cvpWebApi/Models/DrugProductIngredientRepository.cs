using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;
namespace cvpWebApi.Models
{
    public class DrugProductIngredientRepository : IDrugProductIngredientRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<DrugProductIngredient> _drugProductIngredients = new List<DrugProductIngredient>();
        private DrugProductIngredient _drugProductIngredient = new DrugProductIngredient();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<DrugProductIngredient> GetAll()
        {
            _drugProductIngredients = dbConnection.GetAllDrugProductIngredient();

            return _drugProductIngredients;
        }


        public DrugProductIngredient Get(int id)
        {
            _drugProductIngredient = dbConnection.GetDrugProductIngredientById(id);
            return _drugProductIngredient;
        }


    }
}