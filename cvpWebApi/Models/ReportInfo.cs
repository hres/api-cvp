
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportInfo
    {
        public int ReportId { get; set; }
        public string ReportNo { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateIntReceived { get; set; }
        public string MahNo { get; set; }
        public string GenderName { get; set; }
        public int Age { get; set; }
        public string AgeUnit { get; set; }
        public string PtName { get; set; }
        public string SocName { get; set; }
        public string DrugName { get; set; }

    }
}