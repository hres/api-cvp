
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class Report
    {
        public int report_id { get; set; }
        public string report_no { get; set; }
        public int version_no { get; set; }
        public DateTime? date_received { get; set; }
        public DateTime? date_int_received { get; set; }
        public string mah_no { get; set; }
        public string report_type_code { get; set; }
        public string report_type_name { get; set; }
        public string gender_code { get; set; }
        public string gender_name { get; set; }
        public double age { get; set; }
        public double age_y { get; set; }
        //public string age_unit_code { get; set; } removed until approved and described by client
        public string age_unit { get; set; }
        //public string age_group_code { get; set; } removed until approved and described by client
        //public string age_group_name { get; set; } removed until approved and described by client
        public string outcome_code { get; set; }
        public string outcome { get; set; }
        public double weight { get; set; }
        //public string weight_unit_code { get; set; } removed until approved and described by client
        public string weight_unit { get; set; }
        public double height { get; set; }
        //public string height_unit_code { get; set; } removed until approved and described by client
        public string height_unit { get; set; }
         public string seriousness_code { get; set; }
        public string seriousness { get; set; }
        public string death { get; set; }
        public string disability { get; set; }
        public string congenital_anomaly { get; set; }
        public string life_threatening { get; set; }
        public string hosp_required { get; set; }
        public string other_medically_imp_cond { get; set; }
        public string reporter_type_code { get; set; }
        public string reporter_type { get; set; }
         public string source_code { get; set; }
        public string source_name { get; set; }
        //public int report_link_flg { get; set; } removed until approved and described by client
        //public long aer_id { get; set; } removed until approved and described by client
        public string pt_name { get; set; }
         public string soc_name { get; set; }
         public double duration { get; set; }
        public string duration_unit { get; set; }
        public string drug_name { get; set; }

        public int cpd_flag { get; set; }
    }
}