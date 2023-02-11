﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.CustomerModel;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        OrderModel orderModel = new OrderModel();
        OrderDetailModel orderDetailModel = new OrderDetailModel();
        public ActionResult Index(int page = 1, int pageSize = 10, string nameSearch = null, string phoneSearch = null)
        {
            ViewBag.nameSearch = nameSearch;
            ViewBag.phoneSearch = phoneSearch;
            return View(orderModel.getOrderByPageList(page, pageSize, nameSearch, phoneSearch));
        }

        public ActionResult Details(int id)
        {
            var orderDetailList = orderDetailModel.getOrderDetailByOrderID(id);
            return View(orderDetailList);
        }
    }
}