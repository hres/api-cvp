using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportComparer : IEqualityComparer<Report>
    {

        public bool Equals(Report r1, Report r2)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(r1, r2)) return true;

            //Check whether the reports' properties are equal.
            return r1.report_id == r2.report_id;
        }

        public int GetHashCode(Report r)
        {
            return r.report_id.GetHashCode();
        }

    }
}