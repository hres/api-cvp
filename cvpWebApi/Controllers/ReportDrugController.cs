using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportDrugController : ApiController
    {
        static readonly IReportDrugRepository databasePlaceholder = new ReportDrugRepository();

        public IEnumerable<ReportDrug> GetAllReportDrug(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportDrug GetReportByDrugID(int id, string lang)
        {
            ReportDrug report = databasePlaceholder.Get(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }

        public IEnumerable<ReportDrug> GetReportDrugsById(string reportId, string lang)
        {
            return databasePlaceholder.GetReportDrugsById(reportId, lang);
        }

    }
}
