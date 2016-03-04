using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;
namespace cvpWebApi.Models
{
    public class AEReportRepository : IAEReportRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<AEReport> _reports = new List<AEReport>();
        private AEReport _report = new AEReport();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<AEReport> GetAll()
        {
            _reports = null; // dbConnection.GetAllReport();

            return _reports;
        }


        public AEReport Get(int id)
        {
            _report = null; //dbConnection.GetReportById(id);
            return _report;
        }

        public IEnumerable<AEReport> Get(string drugName)
        {
           
            _reports = dbConnection.GetAEExportReportByDrugName(drugName);
            return _reports;
        }


    }
}