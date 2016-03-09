using System;
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

        public IEnumerable<Reactions> GetAll()
        {
            _reactions = dbConnection.GetAllReactions();
            return _reactions;
        }

        public Reactions Get(int id)
        {
            _reaction = dbConnection.GetReactionsById(id);
            return _reaction;
        }
    }
}