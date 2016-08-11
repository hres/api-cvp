using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReactionsController : ApiController
    {
        static readonly IReactionsRepository databasePlaceholder = new ReactionsRepository();

        public IEnumerable<Reactions> GetAllReport(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Reactions GetReactionsByID(int id, string lang)
        {
            Reactions reaction = databasePlaceholder.Get(id, lang);
            if (reaction == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return reaction;
        }

        public IEnumerable<Reactions> GetReactionsByReportId(string reportId, string lang)
        {
            return databasePlaceholder.GetReactionsByReportId(reportId, lang);
        }

    }
}
