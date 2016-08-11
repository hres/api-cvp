using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class DrugProductIngredientController : ApiController
    {
        static readonly IDrugProductIngredientRepository databasePlaceholder = new DrugProductIngredientRepository();

        public IEnumerable<DrugProductIngredient> GetAllDrugProductIngredient(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public DrugProductIngredient GetDrugProductIngredientByID(int id, string lang)
        {
            DrugProductIngredient drugProductIngredient = databasePlaceholder.Get(id, lang);
            if (drugProductIngredient == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProductIngredient;
        }

    }
}
