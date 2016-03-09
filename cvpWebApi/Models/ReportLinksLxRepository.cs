using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportLinksLxRepository : IReportLinksLxRepository
    {
        private List<ReportLinksLx> _reportLinksLxs = new List<ReportLinksLx>();
        private ReportLinksLx _reportLinksLx = new ReportLinksLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportLinksLx> GetAll()
        {
            _reportLinksLxs = dbConnection.GetAllReportLinksLx();
            return _reportLinksLxs;
        }

        public ReportLinksLx Get(int id)
        {
            _reportLinksLx = dbConnection.GetReportLinksLxById(id);
            return _reportLinksLx;
        }
    }
}