using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class OutcomeController : ApiController
    {
        static readonly IOutcomeRepository databasePlaceholder = new OutcomeRepository();

        public IEnumerable<Outcome> GetAllOutcome(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Outcome GetOutcomeByID(int id, string lang)
        {
            Outcome outcome = databasePlaceholder.Get(id, lang);
            if (outcome == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return outcome;
        }
    }
}
