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

        public IEnumerable<OutcomeLx> GetAll()
        {
            _outcomeLxs = dbConnection.GetAllOutcomeLx();
            return _outcomeLxs;
        }

        public OutcomeLx Get(int id)
        {
            _outcomeLx = dbConnection.GetOutcomeLxById(id);
            return _outcomeLx;
        }
    }
}