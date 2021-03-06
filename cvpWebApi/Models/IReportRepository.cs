﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvpWebApi.Models
{
    interface IReportRepository
    {
        IEnumerable<Report> GetAll(string lang);
        Report GetReportByID(int id, string lang);
        //IEnumerable<Report> GetReportByCriteria(string drugName, string lang);
        IEnumerable<Report> GetReportByCriteria(string searchTerm, string ageRange, string gender, string seriousReport, string sourceOfReport, 
            string reportOutcome, string startdate, string endDate, string lang);
    }
}
