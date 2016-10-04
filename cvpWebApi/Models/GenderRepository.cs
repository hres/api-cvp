using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;

namespace cvpWebApi.Models
{
    public class GenderRepository : IGenderRepository
    {
        private List<Gender> _genders = new List<Gender>();
        private Gender _gender = new Gender();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Gender> GetAll(string lang)
        {
            _genders = dbConnection.GetAllGender(lang);
            return _genders;
        }

        public Gender Get(int id, string lang)
        {
            _gender = dbConnection.GetGenderById(id, lang);
            return _gender;
        }
    }
}