using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class GenderLxController : ApiController
    {
        static readonly IGenderLxRepository databasePlaceholder = new GenderLxRepository();

        public IEnumerable<GenderLx> GetAllGender(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public GenderLx GetGenderLxByID(int id, string lang)
        {
            GenderLx gender = databasePlaceholder.Get(id, lang);
            if (gender == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return gender;
        }
        
    }
}
