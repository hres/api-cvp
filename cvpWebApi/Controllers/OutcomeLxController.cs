using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class OutcomeLxController : ApiController
    {
        static readonly IOutcomeLxRepository databasePlaceholder = new OutcomeLxRepository();

        public IEnumerable<OutcomeLx> GetAllOutcomeLx(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public OutcomeLx GetReportByID(int id, string lang)
        {
            OutcomeLx outcome = databasePlaceholder.Get(id, lang);
            if (outcome == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return outcome;
        }
    }
}
