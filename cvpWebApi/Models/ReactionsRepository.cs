﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReactionsRepository : IReactionsRepository
    {
        private List<Reactions> _reactions = new List<Reactions>();
        private Reactions _reaction = new Reactions();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Reactions> GetAll(string lang)
        {
            _reactions = dbConnection.GetAllReactions(lang);
            return _reactions;
        }

        public Reactions Get(int id, string lang)
        {
            _reaction = dbConnection.GetReactionsById(id, lang);
            return _reaction;
        }
        public IEnumerable<Reactions> GetReactionsByReportId(string reportId, string lang)
        {
            _reactions = dbConnection.GetReactionsByReportId(reportId, lang);
            return _reactions;
        }
    }
}