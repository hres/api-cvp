
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class DrugProduct
    {
        public int DrugProductId { get; set; }
        public int ProductId { get; set; }
        public string DrugName { get; set; }
        public int CpdFlag { get; set; }
    }
}