using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportLinkController : ApiController
    {
        static readonly IReportLinkRepository databasePlaceholder = new ReportLinkRepository();

        public IEnumerable<ReportLink> GetAllReportLink(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportLink GetReportLinkByID(int id, string lang = "en")
        {
            ReportLink report = databasePlaceholder.Get(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }


    }
}
