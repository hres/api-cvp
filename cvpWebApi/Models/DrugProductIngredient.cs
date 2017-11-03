
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class DrugProductIngredient
    {
        public Int64 drug_product_ingredient_id { get; set; }
        public int drug_product_id { get; set; }
        public int product_id { get; set; }
        public string drug_name { get; set; }
        public int active_ingredient_id { get; set; }
        public string active_ingredient_name { get; set; }
    }
}