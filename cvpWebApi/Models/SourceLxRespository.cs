using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class SourceLxRespository : ISourceLxRepository
    {
        private List<SourceLx> _sourceLxs = new List<SourceLx>();
        private SourceLx _sourceLx = new SourceLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<SourceLx> GetAll()
        {
            _sourceLxs = dbConnection.GetAllSourceLx();
            return _sourceLxs;
        }

        public SourceLx Get(int id)
        {
            _sourceLx = dbConnection.GetSourceLxById();
            return _sourceLx;
        }
    }
}