using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportLinkRepository : IReportLinkRepository
    {
        private List<ReportLink> _reportLinks = new List<ReportLink>();
        private ReportLink _reportLink = new ReportLink();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportLink> GetAll(string lang)
        {
            _reportLinks = dbConnection.GetAllReportLink(lang);
            return _reportLinks;
        }

        public ReportLink Get(int id, string lang)
        {
            _reportLink = dbConnection.GetReportLinkById(id, lang);
            return _reportLink;
        }
    }
}