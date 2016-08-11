using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class DrugProductController : ApiController
    {
        static readonly IDrugProductRepository databasePlaceholder = new DrugProductRepository();

        public IEnumerable<DrugProduct> GetAllDrugProduct(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public DrugProduct GetDrugProductByID(int id, string lang)
        {
            DrugProduct drugProduct = databasePlaceholder.Get(id, lang);
            if (drugProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProduct;
        }

        public IEnumerable<DrugProduct> GetDrugProductByDrugName(string drugName, string lang)
        {
            return databasePlaceholder.Get(drugName, lang);

        }
       
    }
}
