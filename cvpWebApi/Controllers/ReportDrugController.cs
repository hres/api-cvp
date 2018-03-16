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

        public IEnumerable<ReportDrug> GetAllReportDrug(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        //public ReportDrug GetReportByDrugID(int id, string lang = "en")
        //{
        //    ReportDrug report = databasePlaceholder.Get(id, lang);
        //    if (report == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return report;
        //}

        public IEnumerable<ReportDrug> GetReportDrugById(string id, string lang = "en")
        {
            return databasePlaceholder.GetReportDrugById(id, lang);
        }

    }
}
