using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;
namespace cvpWebApi.Models
{
    public class ReportInfoRepository : IReportInfoRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<ReportInfo> _reports = new List<ReportInfo>();
        private ReportInfo _report = new ReportInfo();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<ReportInfo> GetAll(string lang)
        {
            _reports = dbConnection.GetAllReportInfo(lang);

            return _reports;
        }


        public ReportInfo Get(int id, string lang)
        {
            _report = dbConnection.GetReportInfoById(id, lang);
            return _report;
        }
        public IEnumerable<ReportInfo> Get(string drugName, string lang)
        {
            _reports = dbConnection.GetReportInfoByDrugName(drugName, lang);


            return _reports;
        }

    }
}