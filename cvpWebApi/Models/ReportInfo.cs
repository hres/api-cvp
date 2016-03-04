
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
        public string GenderEng { get; set; }
        public string GenderFr { get; set; }
        public int Age { get; set; }
        public string AgeUnitEng { get; set; }
        public string AgeUnitFr { get; set; }
        public string PtNameEng { get; set; }
        public string PtNameFr { get; set; }
        public string SocNameEng { get; set; }
        public string SocNameFr { get; set; }
        public string DrugName { get; set; }

    }
}