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
        public String DurationUnitEng { get; set; }
        public String DurationUnitFr { get; set; }
        public String PtNameEng { get; set; }
        public String PtNameFr { get; set; }
        public String SocNameEng { get; set; }
        public String SocNameFr { get; set; }
        public String MeddraVersion { get; set; }

    }
}