using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportDrugIndicationController : ApiController
    {
        static readonly IReportDrugIndicationRepository databasePlaceholder = new ReportDrugIndicationRepository();

        public IEnumerable<ReportDrugIndication> GetAllReportDrugIndication(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ReportDrugIndication GetReportDrugIndicationByID(int id, string lang)
        {
            ReportDrugIndication report = databasePlaceholder.Get(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }
 
    }
}
