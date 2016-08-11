using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportInfoController : ApiController
    {
        static readonly IReportInfoRepository databasePlaceholder = new ReportInfoRepository();

        public IEnumerable<ReportInfo> GetAllReportInfo(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportInfo GetReportByInfoID(int id, string lang)
        {
            ReportInfo report = databasePlaceholder.Get(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }
        public IEnumerable<ReportInfo> GetReportByDrugName(string drugName, string lang)
        {
            return databasePlaceholder.Get(drugName, lang);
        }

    }
}
