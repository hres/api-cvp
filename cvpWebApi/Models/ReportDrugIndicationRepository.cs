using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportDrugIndicationRepository : IReportDrugIndicationRepository
    {
        private List<ReportDrugIndication> _reportDrugIndications = new List<ReportDrugIndication>();
        private ReportDrugIndication _reportDrugIndication = new ReportDrugIndication();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportDrugIndication> GetAll(string lang)
        {
            _reportDrugIndications = dbConnection.GetAllReportDrugIndication(lang);
            return _reportDrugIndications;
        }

        public ReportDrugIndication Get(int id, string lang)
        {
            _reportDrugIndication = dbConnection.GetReportDrugIndicationById(id, lang);
            return _reportDrugIndication;
        }
    }
}