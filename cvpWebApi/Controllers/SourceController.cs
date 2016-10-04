using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class SourceController : ApiController
    {
        static readonly ISourceRepository databasePlaceholder = new SourceRepository();

        public IEnumerable<Source> GetAllSource(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Source GetSourceByID(int id, string lang)
        {
            Source source = databasePlaceholder.Get(id, lang);
            if (source == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return source;
        }

 
    }
}
