using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportLinksController : ApiController
    {
        static readonly IReportLinksRepository databasePlaceholder = new ReportLinksRepository();

        public IEnumerable<ReportLinks> GetAllReportLinks(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportLinks GetReportLinksByID(int id, string lang)
        {
            ReportLinks report = databasePlaceholder.Get(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }


    }
}
