using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;
namespace cvpWebApi.Models
{
    public class ReportRepository : IReportRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<Report> _reports = new List<Report>();
        private Report _report = new Report();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<Report> GetAll(string lang)
        {
            _reports = dbConnection.GetAllReport(lang);

            return _reports;
        }


        public Report GetReportByID(int id, string lang)
        {
            _report = dbConnection.GetReportById(id, lang);
            return _report;
        }
        //public IEnumerable<Report> GetReportByCriteria(string drugName, string lang)
        //{
        //    _reports = dbConnection.GetReportByCriteria(drugName, lang);
        //    return _reports;
        //}

        public IEnumerable<Report> GetReportByCriteria(string searchTerm, string ageRange, string gender, string seriousReport, string sourceOfReport, 
            string reportOutcome, string startdate, string endDate, string lang)
        {
            _reports = dbConnection.GetAllReportByBrandName(searchTerm, ageRange, gender, seriousReport, sourceOfReport, reportOutcome, startdate, endDate, lang);
            //_reports = dbConnection.GetAllReportByIngredientName(drugName);
            return _reports;
        }

    }
}