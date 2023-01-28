using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using VegeFoods.Models.BD_VegeFoods;
using VegeFoods.Models.CustomerModel;

namespace VegeFoods.Controllers
{
    public class CheckOutController : Controller
    {
        OrderModel orderModel = new OrderModel();
        OrderDetailModel orderDetailModel = new OrderDetailModel();
        private const string CartSession = "CartSession";
        public ActionResult Order()
        {
            if (Session["Customer"] != null)
            {
                var cartSession = Session[CartSession];
                var cartList = new List<CartModel>();
                if (cartSession != null)
                {
                    cartList = (List<CartModel>)cartSession;
                }

                return View(cartList);
            }
            else
            {
                return RedirectToAction("LoginCustomer","CustomerAccount");
            }
        }

        [HttpPost]
        public ActionResult Order(CheckOutModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Address == null)
                {
                    ViewBag.errorAddress = "Address cannot be empty";
                }
                else if (model.PhoneNumber == null)
                {
                    ViewBag.errorPhoneNumber = "Phone number cannot be empty";
                }
                else if (model.FullName == null)
                {
                    ViewBag.errorFullName = "Full name cannot be empty";
                }
                else
                {
                    var order = new Order();
                    order.FullName = model.FullName;
                    order.Email = model.Email;
                    order.Address = model.Address;
                    order.OrderDate = DateTime.Now;
                    order.PhoneNumber = model.PhoneNumber;

                    order.Status = 1;
                    order.User_ID = model.User_ID;

                    var orderID = orderModel.Insert(order);
                    if (orderID > 0)
                    {
                        var cartList = (List<CartModel>)Session[CartSession];

                        foreach (var item in cartList)
                        {
                            var orderDetail = new OrderDetail();
                            orderDetail.Order_ID = orderID;
                            orderDetail.Product_ID = item.product.ID;

                            if(item.product.Discount > 0)
                            {
                                orderDetail.Price = item.product.Price * (100 - item.product.Discount) / 100;
                            }
                            else
                            {
                                orderDetail.Price = item.product.Price;
                            }

                            orderDetail.Quantity = item.quantity;

                            orderDetailModel.Insert(orderDetail);
                        }
                        
                        Session.Remove(CartSession);
                        return RedirectToAction("OrderSuccess");
                    }
                }
            }
            return View((List<CartModel>)Session[CartSession]);
        }
        
        public ActionResult OrderSuccess()
        {
            return View();
        }
    }
}