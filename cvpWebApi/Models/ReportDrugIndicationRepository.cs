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

        public IEnumerable<ReportDrugIndication> GetAll()
        {
            _reportDrugIndications = dbConnection.GetAllReportDrugIndication();
            return _reportDrugIndications;
        }

        public ReportDrugIndication Get(int id)
        {
            _reportDrugIndication = dbConnection.GetReportDrugIndicationById(id);
            return _reportDrugIndication;
        }
    }
}