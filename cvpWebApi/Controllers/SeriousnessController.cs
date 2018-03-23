using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class SeriousnessController : ApiController
    {
        static readonly ISeriousnessRepository databasePlaceholder = new SeriousnessRepository();

        public IEnumerable<Seriousness> GetAllSeriousness(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Seriousness GetSeriousnessByID(int id, string lang = "en")
        {
            Seriousness seriousness = databasePlaceholder.Get(id, lang);
            if (seriousness == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return seriousness;
        }

    }
}
