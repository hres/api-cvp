using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class GenderLxRepository : IGenderLxRepository
    {
        private List<GenderLx> _genderLxs = new List<GenderLx>();
        private GenderLx _genderLx = new GenderLx();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<GenderLx> GetAll(string lang)
        {
            _genderLxs = dbConnection.GetAllGenderLx(lang);
            return _genderLxs;
        }

        public GenderLx Get(int id, string lang)
        {
            _genderLx = dbConnection.GetGenderLxById(id, lang);
            return _genderLx;
        }
    }
}