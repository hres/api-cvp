using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class SourceLxController : ApiController
    {
        static readonly ISourceLxRepository databasePlaceholder = new SourceLxRepository();

        public IEnumerable<SourceLx> GetAllSourceLx(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public SourceLx GetSourceLxByID(int id, string lang)
        {
            SourceLx source = databasePlaceholder.Get(id, lang);
            if (source == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return source;
        }

 
    }
}
