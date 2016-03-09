using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReportTypeLxRepository : IReportTypeLxRepository
    {
        private List<ReportTypeLx> _reportTypeLxs = new List<ReportTypeLx>();
        private ReportTypeLx _reportTypeLx = new ReportTypeLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<ReportTypeLx> GetAll()
        {
            _reportTypeLxs = dbConnection.GetAllReportTypeLx();
            return _reportTypeLxs;
        }

        public ReportTypeLx Get(int id)
        {
            _reportTypeLx = dbConnection.GetReportTypeLxById(id);
            return _reportTypeLx;
        }
    }
}