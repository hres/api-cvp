using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class SourceLxRepository : ISourceLxRepository
    {
        private List<SourceLx> _sourceLxs = new List<SourceLx>();
        private SourceLx _sourceLx = new SourceLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<SourceLx> GetAll(string lang)
        {
            _sourceLxs = dbConnection.GetAllSourceLx(lang);
            return _sourceLxs;
        }

        public SourceLx Get(int id, string lang)
        {
            _sourceLx = dbConnection.GetSourceLxById(id, lang);
            return _sourceLx;
        }
    }
}