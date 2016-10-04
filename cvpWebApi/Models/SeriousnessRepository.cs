using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class SeriousnessRepository : ISeriousnessRepository
    {
        private List<Seriousness> _seriousnessls = new List<Seriousness>();
        private Seriousness _seriousness = new Seriousness();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Seriousness> GetAll(string lang)
        {
            _seriousnessls = dbConnection.GetAllSeriousness(lang);
            return _seriousnessls;
        }

        public Seriousness Get(int id, string lang)
        {
            _seriousness = dbConnection.GetSeriousnessById(id, lang);
            return _seriousness;
        }
    }
}