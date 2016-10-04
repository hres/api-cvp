using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportTypeController : ApiController
    {
        static readonly IReportTypeRepository databasePlaceholder = new ReportTypeRepository();

        public IEnumerable<ReportType> GetAllReportType(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportType GetReportTypeByID(int id, string lang)
        {
            ReportType reporttype = databasePlaceholder.Get(id, lang);
            if (reporttype == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return reporttype;
        }

    }
}
