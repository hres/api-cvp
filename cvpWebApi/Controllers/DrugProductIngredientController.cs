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

        public IEnumerable<DrugProductIngredient> GetAllDrugProductIngredient()
        {

            return databasePlaceholder.GetAll();
        }


        public DrugProductIngredient GetDrugProductIngredientByID(Int64 id)
        {
            DrugProductIngredient drugProductIngredient = databasePlaceholder.Get(id);
            if (drugProductIngredient == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProductIngredient;
        }

    }
}
