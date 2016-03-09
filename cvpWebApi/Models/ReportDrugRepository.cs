using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportDrugRepository : IReportDrugRepository
    {
        private List<ReportDrug> _reportDrugs = new List<ReportDrug>();
        private ReportDrug _reportDrug = new ReportDrug();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportDrug> GetAll()
        {
            _reportDrugs = dbConnection.GetAllReportDrug();
            return _reportDrugs;
        }

        public ReportDrug Get(int id)
        {
            _reportDrug = dbConnection.GetReportDrugById(id);
            return _reportDrug;
        }
    }
}