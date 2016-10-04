using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportTypeRepository : IReportTypeRepository
    {
        private List<ReportType> _reportTypes = new List<ReportType>();
        private ReportType _reportType = new ReportType();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportType> GetAll(string lang)
        {
            _reportTypes = dbConnection.GetAllReportType(lang);
            return _reportTypes;
        }

        public ReportType Get(int id, string lang)
        {
            _reportType = dbConnection.GetReportTypeById(id, lang);
            return _reportType;
        }
    }
}