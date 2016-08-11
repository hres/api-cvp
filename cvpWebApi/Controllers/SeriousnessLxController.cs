using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class SeriousnessLxController : ApiController
    {
        static readonly ISeriousnessLxRepository databasePlaceholder = new SeriousnessLxRepository();

        public IEnumerable<SeriousnessLx> GetAllSeriousnessLx(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public SeriousnessLx GetSeriousnessLxByID(int id, string lang)
        {
            SeriousnessLx seriousness = databasePlaceholder.Get(id, lang);
            if (seriousness == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return seriousness;
        }

    }
}
