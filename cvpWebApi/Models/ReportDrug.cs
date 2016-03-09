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
        public String Drugname { get; set; }
        public String DruginvolvEng { get; set; }
        public String DruginvolvFr { get; set; }
        public String RouteadminEng { get; set; }
        public String RouteadminFr { get; set; }
        public int UnitDoseQty { get; set; }
        public String DoseUnitEng { get; set; }
        public String DoseUnitFr { get; set; }
        public int Frequency { get; set; }
        public int FreqTime { get; set; }
        public String FrequencyTimeEng { get; set; }
        public String FrequencyTimeFr { get; set; }
        public String FreqTimeUnitEng { get; set; }
        public String FreqTimeUnitFr { get; set; }
        public int TherapyDuration { get; set; }
        public String TherapyDurationUnitEng { get; set; }
        public String TherapyDurationUnitFr { get; set; }
        public String DosageformEng { get; set; }
        public String DosageformFr { get; set; }
    }
}