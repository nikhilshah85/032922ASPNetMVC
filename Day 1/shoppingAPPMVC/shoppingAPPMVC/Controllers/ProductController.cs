using Microsoft.AspNetCore.Mvc;
using shoppingAPPMVC.Models;
namespace shoppingAPPMVC.Controllers
{
    public class ProductController : Controller
    {

        ProductsModel pModelObj = new ProductsModel(); //Developer will use DI instead of createing and manageing the object
        public IActionResult ProductDetails()
        {
            #region Hardcoded values passed using Viewbag
            //ViewBag.Title = "Product Details";
            //ViewBag.productName = "IPhone 13";
            //ViewBag.price = 156000;
            //ViewBag.isInStock = false;
            //data will be collected from Model
            #endregion

            return View(pModelObj.GetProductDetails());
        }

        public IActionResult ProductList()
        {           
            return View(pModelObj.GetProductList());
        }
    }
}
