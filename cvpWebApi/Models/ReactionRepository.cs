﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class ReactionRepository : IReactionRepository
    {
        private List<Reaction> _reactions = new List<Reaction>();
        private Reaction _reaction = new Reaction();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Reaction> GetAll(string lang)
        {
            _reactions = dbConnection.GetAllReaction(lang);
            return _reactions;
        }

        public Reaction Get(Int64 id, string lang)
        {
            _reaction = dbConnection.GetReactionById(id, lang);
            return _reaction;
        }
        public IEnumerable<Reaction> GetReactionByReportId(string reportId, string lang)
        {
            _reactions = dbConnection.GetReactionByReportId(reportId, lang);
            return _reactions;
        }
    }
}