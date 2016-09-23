using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReactionController : ApiController
    {
        static readonly IReactionRepository databasePlaceholder = new ReactionRepository();

        public IEnumerable<Reaction> GetAllReport(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Reaction GetReactionsByID(int id, string lang)
        {
            Reaction reaction = databasePlaceholder.Get(id, lang);
            if (reaction == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return reaction;
        }

        public IEnumerable<Reaction> GetReactionsByReportId(string reportId, string lang)
        {
            return databasePlaceholder.GetReactionByReportId(reportId, lang);
        }

    }
}
