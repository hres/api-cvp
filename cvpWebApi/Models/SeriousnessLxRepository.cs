using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class SeriousnessLxRepository : ISeriousnessLxRepository
    {
        private List<SeriousnessLx> _seriousnessLxs = new List<SeriousnessLx>();
        private SeriousnessLx _seriousnessLx = new SeriousnessLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<SeriousnessLx> GetAll(string lang)
        {
            _seriousnessLxs = dbConnection.GetAllSeriousnessLx(lang);
            return _seriousnessLxs;
        }

        public SeriousnessLx Get(int id, string lang)
        {
            _seriousnessLx = dbConnection.GetSeriousnessLxById(id, lang);
            return _seriousnessLx;
        }
    }
}