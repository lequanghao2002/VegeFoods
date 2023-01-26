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
    public class CartController : Controller
    {
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
        public ActionResult AddItem(int productId, int quantity)
        {
            var cartSession = Session[CartSession];
            var product = new ProductModel().getProductById(productId);

            if (cartSession != null)
            {
                var cartList = (List<CartModel>)cartSession;
                if (cartList.Exists(x => x.product.ID == productId))
                {
                    foreach (var item in cartList)
                    {
                        if (item.product.ID == productId)
                        {
                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartModel();
                    item.product = product;
                    item.quantity = quantity;

                    cartList.Add(item);

                }

                Session[CartSession] = cartList;
            }
            else
            {
                var item = new CartModel();
                item.product = product;
                item.quantity = quantity;

                var cartList = new List<CartModel>();
                //*****************
                cartList.Add(item);

                Session[CartSession] = cartList;
            }
            return RedirectToAction("Index","Shop");
        }
    
        public ActionResult DeleteItem(int productId)
        {
            var cartSession = Session[CartSession];
            var cartList = (List<CartModel>)cartSession;
            cartList.RemoveAll(m => m.product.ID == productId);

            Session[CartSession] = cartList;

            return RedirectToAction("Index");
        }
    }
}