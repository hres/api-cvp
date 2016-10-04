﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class Reaction
    {
        public long reaction_id { get; set; }
        public int report_id { get; set; }
        public int duration { get; set; }
        public String duration_unit { get; set; }
        public String pt_name { get; set; }
        public String soc_name { get; set; }
        public String meddra_version { get; set; }

    }
}