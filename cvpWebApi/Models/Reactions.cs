using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cvpWebApi.Models
{
    public class Reactions
    {
        public int ReactionId { get; set; }
        public int ReportId { get; set; }
        public int Duration { get; set; }
        public String DurationUnit { get; set; }
        public String PtName { get; set; }
        public String SocName { get; set; }
        public String MeddraVersion { get; set; }

    }
}