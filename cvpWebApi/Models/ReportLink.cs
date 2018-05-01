using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportLink
    {
        public Int64 report_link_id { get; set; }
        public int report_id { get; set; }
        public String record_type { get; set; }
        public String report_link_no { get; set; }
    }
}