using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportDrugIndication
    {
        public int ReportDrugId { get; set; }
        public int ReportId { get; set; }
        public int DrugProductId { get; set; }
        public String Drugname { get; set; }
        public String IndicationName { get; set; }
    }
}