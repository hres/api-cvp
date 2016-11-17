using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class AEReportController : ApiController
    {
        static readonly IAEReportRepository databasePlaceholder = new AEReportRepository();

        public IEnumerable<AEReport> GetAllReport(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public AEReport GetReportByID(int id, string lang)
        {
            AEReport report = databasePlaceholder.Get(id, lang);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }


        //public IEnumerable<AEReport> GetReportByDrugName(string drugName, string lang)
        //{
        //    return databasePlaceholder.Get(drugName, lang);
        //}
        
    }
}
