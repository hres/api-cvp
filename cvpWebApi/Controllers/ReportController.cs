using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportController : ApiController
    {
        static readonly IReportRepository databasePlaceholder = new ReportRepository();

        public IEnumerable<Report> GetAllReport(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Report GetReportByID(int id, string lang = "en")
        {
            Report report = databasePlaceholder.GetReportByID(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }

        //public IEnumerable<Report> GetReportByCriteria(string drugName, string lang)
        //{
        //    return databasePlaceholder.GetReportByCriteria(drugName, lang);
        //}

        public IEnumerable<Report> GetReportByCriteria(string drugName, string ageRange, string gender, string seriousReport, string sourceOfReport, 
            string reportOutcome, string startdate, string endDate, string lang = "en")
        {
            return databasePlaceholder.GetReportByCriteria(drugName, ageRange, gender, seriousReport, sourceOfReport, reportOutcome, startdate, endDate, lang);
        }

    }
}
