
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class DrugProduct
    {
        public int drug_product_id { get; set; }
        public int product_id { get; set; }
        public string drug_name { get; set; }
        public int cpd_flag { get; set; }
    }
}