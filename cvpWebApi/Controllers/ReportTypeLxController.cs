using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportTypeLxController : ApiController
    {
        static readonly IReportTypeLxRepository databasePlaceholder = new ReportTypeLxRepository();

        public IEnumerable<ReportTypeLx> GetAllReportTypeLx(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportTypeLx GetReportTypeLxByID(int id, string lang)
        {
            ReportTypeLx reporttype = databasePlaceholder.Get(id, lang);
            if (reporttype == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return reporttype;
        }

    }
}
