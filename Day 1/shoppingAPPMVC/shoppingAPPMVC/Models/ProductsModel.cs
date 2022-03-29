using System.Collections.Generic;

namespace shoppingAPPMVC.Models
{
    public class ProductsModel
    {
        #region Properties
        public int pId { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }
        public string pCategory { get; set; }
        public bool pIsInStock { get; set; }
        #endregion
        public ProductsModel GetProductDetails()
        {
            //connect to database and get the details
            return new ProductsModel() { pId=101, pName="Pepsi", pCategory= "Cold-Drink", pIsInStock=true, pPrice=50 };       
        }
        public List<ProductsModel> GetProductList()
        {
            //  //connect to database and the details
            List<ProductsModel> pList = new List<ProductsModel>()
            {
            new ProductsModel() { pId=101, pName="Pepsi", pCategory= "Cold-Drink", pIsInStock=true, pPrice=50 },
            new ProductsModel() { pId=102, pName="IPhone", pCategory= "Phone", pIsInStock=true, pPrice=50 },
            new ProductsModel() { pId=103, pName="Fossil", pCategory= "Watch", pIsInStock=false, pPrice=50 },
            new ProductsModel() { pId=104, pName="Dell", pCategory= "Laptop", pIsInStock=true, pPrice=50 },
            new ProductsModel() { pId=105, pName="Trailhawk", pCategory= "SUV", pIsInStock=false, pPrice=50 },
            new ProductsModel() { pId=106, pName="Maggie", pCategory= "Junk-Food", pIsInStock=true, pPrice=50 }
             };
            return pList;
        }


    }
}
