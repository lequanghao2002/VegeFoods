using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AdminModel;

namespace VegeFoods.Controllers
{
    public class ShopController : Controller
    {
        ProductModel productModel = new ProductModel();
        public ActionResult Index(string categoryFilter)
        {

            return View();
        }
    }
}