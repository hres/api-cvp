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

        public IEnumerable<ReportDrug> GetAll(string lang)
        {
            _reportDrugs = dbConnection.GetAllReportDrug(lang);
            return _reportDrugs;
        }

        //public ReportDrug Get(int id, string lang)
        //{
        //    _reportDrug = dbConnection.GetReportDrugById(id, lang);
        //    return _reportDrug;
        //}

        public IEnumerable<ReportDrug> GetReportDrugById(string id, string lang)
        {
            _reportDrugs = dbConnection.GetReportDrugByReportId(id, lang);
            return _reportDrugs;
        }
    }
}