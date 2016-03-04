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

        public IEnumerable<AEReport> GetAllReport()
        {

            return databasePlaceholder.GetAll();
        }


        public AEReport GetReportByID(int id)
        {
            AEReport report = databasePlaceholder.Get(id);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }


        public IEnumerable<AEReport> GetReportByDrugName(string drugName)
        {
            return databasePlaceholder.Get(drugName);
        }
        
    }
}
