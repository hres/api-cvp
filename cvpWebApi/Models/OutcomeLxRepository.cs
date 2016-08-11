using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class OutcomeLxRepository : IOutcomeLxRepository
    {
        private List<OutcomeLx> _outcomeLxs = new List<OutcomeLx>();
        private OutcomeLx _outcomeLx = new OutcomeLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<OutcomeLx> GetAll(string lang)
        {
            _outcomeLxs = dbConnection.GetAllOutcomeLx(lang);
            return _outcomeLxs;
        }

        public OutcomeLx Get(int id, string lang)
        {
            _outcomeLx = dbConnection.GetOutcomeLxById(id, lang);
            return _outcomeLx;
        }
    }
}