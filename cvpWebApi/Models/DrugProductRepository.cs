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


        public IEnumerable<DrugProduct> GetAll()
        {
            _drugProducts = dbConnection.GetAllDrugProduct();

            return _drugProducts;
        }


        public DrugProduct Get(int id)
        {
            _drugProduct = dbConnection.GetDrugProductById(id);
            return _drugProduct;
        }


        public IEnumerable<DrugProduct> Get(string drugName)
        {
            _drugProducts = dbConnection.GetDrugProductByDrugName(drugName);
            return _drugProducts;
        }



    }
}