using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class ReportDrug
    {
        public int report_drug_id { get; set; }
        public int report_id { get; set; }
        public int drug_product_id { get; set; }
        public String drug_name { get; set; }
        public String drug_involv_name { get; set; }
        public String route_admin { get; set; }
        public String route_admin_name { get; set; }
 
        public int unit_dose_qty { get; set; }
        public String dose_unit { get; set; }
        public String dose_unit_name { get; set; }
        public int frequency { get; set; }
        public int freq_time { get; set; }
        public String frequency_time { get; set; }
        public String freq_time_unit { get; set; }
        public int therapy_duration { get; set; }
        public String therapy_duration_unit { get; set; }
        public String dosage_form { get; set; }
        public String indication_name { get; set; }

    }
}