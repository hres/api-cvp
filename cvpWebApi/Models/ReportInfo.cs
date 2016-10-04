
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportInfo
    {
        public int report_id { get; set; }
        public string report_no { get; set; }
        public DateTime? date_received { get; set; }
        public DateTime? date_int_received { get; set; }
        public string mah_no { get; set; }
        public string gender_name { get; set; }
        public int age { get; set; }
        public string age_unit { get; set; }
        public string pt_name { get; set; }
        public string soc_name { get; set; }
        public string drug_name { get; set; }

    }
}