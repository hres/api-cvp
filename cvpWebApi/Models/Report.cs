
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportNo { get; set; }
        public int VersionNo { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateIntReceived { get; set; }
        public string MahNo { get; set; }
        public string ReportTypeCode { get; set; }
        public string ReportTypeName { get; set; }
        public string GenderCode { get; set; }
        public string GenderName { get; set; }
        public int Age { get; set; }
        public int AgeY { get; set; }
        public string AgeUnitCode { get; set; }
        public string AgeUnit { get; set; }
        public string AgeGroupCode { get; set; }
        public string AgeGroupName { get; set; }
        public string OutcomeCode { get; set; }
        public string Outcome { get; set; }
        public int Weight { get; set; }
        public string WeightUnitCode { get; set; }
        public string WeightUnit { get; set; }
        public int Height { get; set; }
        public string HeightUnitCode { get; set; }
        public string HeightUnit { get; set; }
         public string SeriousnessCode { get; set; }
        public string Seriousness { get; set; }
        public string Death { get; set; }
        public string Disability { get; set; }
        public string CongenitalAnomaly { get; set; }
        public string LifeThreatening { get; set; }
        public string HospRequired { get; set; }
        public string OtherMedicallyImpCond { get; set; }
        public string ReporterTypeCode { get; set; }
        public string ReporterType { get; set; }
         public string SourceCode { get; set; }
        public string SourceName { get; set; }
         public int ReportLinkFlg { get; set; }
        public long AerId { get; set; }
        public string PtName { get; set; }
         public string SocName { get; set; }
         public int Duration { get; set; }
        public string DurationUnit { get; set; }
        public string DrugName { get; set; }














        public int CpdFlag { get; set; }
    }
}