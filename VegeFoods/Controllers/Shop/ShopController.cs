using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AdminModel;
using VegeFoods.Models.BD_VegeFoods;
using VegeFoods.Models.CustomerModel;

namespace VegeFoods.Controllers
{
    public class ShopController : Controller
    {
        ProductModel productModel = new ProductModel();
        public ActionResult Index(int? idCategoryFilter)
        {
            return View(productModel.getProductListByCategory(idCategoryFilter));    
        }

        public ActionResult ProductSingle(int id)
        {
            ViewBag.RelatedProducts = productModel.get4RelatedProducts(id);
            return View(productModel.getProductById(id));
        }

        private const string CartSession = "CartSession";
        [ChildActionOnly]
        public PartialViewResult NavCart()
        {
            var cartSession = Session[CartSession];
            var cartList = new List<CartModel>();
            if (cartSession != null)
            {
                cartList = (List<CartModel>)cartSession;
            }
            return PartialView(cartList);
        }
    }
}