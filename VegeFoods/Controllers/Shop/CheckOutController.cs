using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.CustomerModel;

namespace VegeFoods.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cartSession = Session[CartSession];
            var cartList = new List<CartModel>();
            if (cartSession != null)
            {
                cartList = (List<CartModel>)cartSession;
            }
            return View(cartList);
        }
    }
}