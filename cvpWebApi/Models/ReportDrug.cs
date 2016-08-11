using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportDrug
    {
        public int ReportDrugId { get; set; }
        public int ReportId { get; set; }
        public int DrugProductId { get; set; }
        public String DrugName { get; set; }
        public String DrugInvolvName { get; set; }
        public String RoutesAdmin { get; set; }
        public String RouteAdminName { get; set; }
 
        public int UnitDoseQty { get; set; }
        public String DoseUnit { get; set; }
        public String DoseUnitName { get; set; }
        public int Frequency { get; set; }
        public int FreqTime { get; set; }
        public String FrequencyTime { get; set; }
        public String FreqTimeUnit { get; set; }
        public int TherapyDuration { get; set; }
        public String TherapyDurationUnit { get; set; }
        public String DosageForm { get; set; }
        public String IndicationName { get; set; }

    }
}