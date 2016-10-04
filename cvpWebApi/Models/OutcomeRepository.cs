using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class OutcomeRepository : IOutcomeRepository
    {
        private List<Outcome> _outcomes = new List<Outcome>();
        private Outcome _outcome = new Outcome();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Outcome> GetAll(string lang)
        {
            _outcomes = dbConnection.GetAllOutcome(lang);
            return _outcomes;
        }

        public Outcome Get(int id, string lang)
        {
            _outcome = dbConnection.GetOutcomeById(id, lang);
            return _outcome;
        }
    }
}