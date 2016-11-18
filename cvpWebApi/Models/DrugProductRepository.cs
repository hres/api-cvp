using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cvp;
namespace cvpWebApi.Models
{
    public class DrugProductRepository : IDrugProductRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<DrugProduct> _drugProducts = new List<DrugProduct>();
        private DrugProduct _drugProduct = new DrugProduct();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<DrugProduct> GetAll(string lang)
        {
            _drugProducts = dbConnection.GetAllDrugProduct(lang);

            return _drugProducts;
        }


        public DrugProduct Get(int id, string lang)
        {
            _drugProduct = dbConnection.GetDrugProductById(id, lang);
            return _drugProduct;
        }


        //public IEnumerable<DrugProduct> Get(string drugName, string lang)
        //{
        //    _drugProducts = dbConnection.GetDrugProductByDrugName(drugName, lang);
        //    return _drugProducts;
        //}



    }
}