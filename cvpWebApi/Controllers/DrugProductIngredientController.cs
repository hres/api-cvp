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


        public DrugProductIngredient GetDrugProductIngredientByID(int id)
        {
            DrugProductIngredient drugProductIngredient = databasePlaceholder.Get(id);
            if (drugProductIngredient == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProductIngredient;
        }


        //public HttpResponseMessage PostDrugProduct(DrugProductIngredient drugProductIngredient)
        //{
        //    drugProductIngredient = databasePlaceholder.Add(drugProductIngredient);
        //    string apiName = App_Start.WebApiConfig.DEFAULT_ROUTE_NAME;
        //    var response =
        //        this.Request.CreateResponse<DrugProduct>(HttpStatusCode.Created, drugProductIngredient);
        //    string uri = Url.Link(apiName, new { id = drugProductIngredient.DrugCode });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}


        //public bool PutPerson(DrugProductIngredient drugProductIngredient)
        //{
        //    if (!databasePlaceholder.Update(drugProductIngredient))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    return true;
        //}


        //public void DeleteDrugProductIngredient(int id)
        //{
        //    DrugProductIngredient drugProductIngredient = databasePlaceholder.Get(id);
        //    if (drugProduct == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    databasePlaceholder.Remove(id);
        //}
    }
}
