using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportLinksRepository : IReportLinksRepository
    {
        private List<ReportLinks> _reportLinks = new List<ReportLinks>();
        private ReportLinks _reportLink = new ReportLinks();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportLinks> GetAll()
        {
            _reportLinks = dbConnection.GetAllReportLinks();
            return _reportLinks;
        }

        public ReportLinks Get(int id)
        {
            _reportLink = dbConnection.GetReportLinksById(id);
            return _reportLink;
        }
    }
}