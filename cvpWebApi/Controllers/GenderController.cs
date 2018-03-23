using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class GenderController : ApiController
    {
        static readonly IGenderRepository databasePlaceholder = new GenderRepository();

        public IEnumerable<Gender> GetAllGender(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Gender GetGenderByID(int id, string lang = "en")
        {
            Gender gender = databasePlaceholder.Get(id, lang);
            if (gender == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return gender;
        }
        
    }
}
