
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class DrugProductIngredient
    {
        public int DrugProductIngredientId { get; set; }
        public int DrugProductId { get; set; }
        public int ProductId { get; set; }
        public string DrugName { get; set; }
        public int ActiveIngredientId { get; set; }
        public string ActiveIngredientName { get; set; }
    }
}