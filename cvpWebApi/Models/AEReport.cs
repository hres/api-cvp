
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class AEReport
    {
        public int ReportId { get; set; }
        public string ReportNo { get; set; }
        public int VersionNo { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateIntReceived { get; set; }
        public string MahNo { get; set; }
        public string ReportTypeCode { get; set; }
        public string ReportTypeEng { get; set; }
        public string ReportTypeFr { get; set; }
        public string GenderCode { get; set; }
        public string GenderEng { get; set; }
        public string GenderFr { get; set; }
        public int Age { get; set; }
        public int AgeY { get; set; }
        public string AgeUnitCode { get; set; }
        public string AgeUnitEng { get; set; }
        public string AgeUnitFr { get; set; }
        public string AgeGroupCode { get; set; }
        public string AgeGroupEng { get; set; }
        public string AgeGroupFr { get; set; }
        public string OutcomeCode { get; set; }
        public string OutcomeEng { get; set; }
        public string OutcomeFr { get; set; }
        public int Weight { get; set; }
        public string WeightUnitCode { get; set; }
        public string WeightUnitEng { get; set; }
        public string WeightUnitFr { get; set; }
        public int Height { get; set; }
        public string HeightUnitCode { get; set; }
        public string HeightUnitEng { get; set; }
        public string HeightUnitFr { get; set; }
        public string SeriousnessCode { get; set; }
        public string SeriousnessEng { get; set; }
        public string SeriousnessFr { get; set; }
        public string Death { get; set; }
        public string Disability { get; set; }
        public string CongenitalAnomaly { get; set; }
        public string LifeThreatening { get; set; }
        public string HospRequired { get; set; }
        public string OtherMedicallyImpCond { get; set; }
        public string ReporterTypeCode { get; set; }
        public string ReporterTypeEng { get; set; }
        public string ReporterTypeFr { get; set; }
        public string SourceCode { get; set; }
        public string SourceEng { get; set; }
        public string SourceFr { get; set; }
        public int ReportLinkFlg { get; set; }
        public long AerId { get; set; }
        public string PtNameEng { get; set; }
        public string PtNameFr { get; set; }
        public string SocNameEng { get; set; }
        public string SocNameFr { get; set; }
        public int Duration { get; set; }
        public string DurationUnitEng { get; set; }
        public string DurationUnitFr { get; set; }
        public string DrugName { get; set; }

        public string DosageFormEng { get; set; }
        public string DosageFormFr { get; set; }
        public string DrugInvolvEng { get; set; }
        public string DrugInvolvFr { get; set; }
        public string RouteAdminEng { get; set; }
        public string RouteAdminFr { get; set; }
        public string UnitDoseQty { get; set; }
        public string DoseUnitEng  { get; set; }
        public string DoseUnitFr { get; set; }
        public string FrequencyTimeEng { get; set; }
        public string FrequencyTimeFr { get; set; }
        public string TherapyDuration { get; set; }
        public string TherapyDurationUnitEng { get; set; }
        public string TherapyDurationUnitFr { get; set; }
        public string MeddraVersion { get; set; }
        public string RecordTypeEng { get; set; }
      










        public int CpdFlag { get; set; }
    }
}