using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportLinks
    {
        public int ReportLinkId { get; set; }
        public int ReportId { get; set; }
        public String RecordType { get; set; }
        public String ReportLinkNo { get; set; }
    }
}