using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class SourceRepository : ISourceRepository
    {
        private List<Source> _sources = new List<Source>();
        private Source _source = new Source();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Source> GetAll(string lang)
        {
            _sources = dbConnection.GetAllSource(lang);
            return _sources;
        }

        public Source Get(int id, string lang)
        {
            _source = dbConnection.GetSourceById(id, lang);
            return _source;
        }
    }
}