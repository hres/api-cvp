using System;
using System.Collections.Generic;



namespace cvp
{
    public enum programType
    {
        rds,
        ssr,
        sbd,
        dhpr
    }


    public class regulatoryDecisionItem
    {
        public int Id { get; set; }
        public string LinkId { get; set; }
        public string Drugname { get; set; }
        public string ContactName { get; set; }
        public string ContactUrl { get; set; }
        public string MedicalIngredient { get; set; }
        public string TherapeuticArea { get; set; }
        public string Purpose { get; set; }
        public string ReasonDecision { get; set; }      
        public string Decision { get; set; }
        public string Outcome { get; set; }
        public DateTime DateDecision { get; set; }
        public string Manufacture { get; set; }
        public string PrescriptionStatus { get; set; }
        public string TypeSubmission { get; set; }
        public DateTime DateFiled { get; set; }
        public string ControlNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Footnotes { get; set; }
        public List<string> DinList { get; set; }
        public List<string> BulletList { get; set; }

    }
    public class rdsSearchItem
    {
        public string LinkId { get; set; }
        public string Drugname { get; set; }
        public string MedicalIngredient { get; set; }
        public string Manufacture { get; set; }
        public string Outcome { get; set; }
        public DateTime DateDecision { get; set; }
        public string ControlNumber { get; set; }
        public string TypeSubmission { get; set; }
    }

    public class summarySafetyItem
    {
        public string LinkId { get; set; }
        public string DrugName { get; set; }
        public string Safetyissue { get; set; }
        public string Issue { get; set; }
        public string Background { get; set; }
        public string Objective { get; set; }        
        public string KeyFindings { get; set; }
  
        public string Additional { get; set; }
        public string FullReview { get; set; }
        public string SrReferences { get; set; }
        public string Footnotes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Template { get; set; }
        public List<BulletPoint> ConclusionList { get; set; }
        public List<BulletPoint> KeyMessageList { get; set; }
        public List<BulletPoint> UseCanadaList { get; set; }
        public List<BulletPoint> FindingList { get; set; }        
        public string Overview { get; set; }
        public List<BulletItem> FootnotesList { get; set; }
        public List<BulletItem> ReferenceList { get; set; }
    }
    public class ssrSearchItem
    {
        public string LinkId { get; set; }
        public string Drugname { get; set; }
        public string Safetyissue { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class BulletPoint
    {
        public int FieldId { get; set; }
        public int OrderNo { get; set; }
        public string Bullet { get; set; }
    }
    public class BulletItem
    {
        public string title { get; set; }
        public List<string> bulletList { get; set; }
    }
}