﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VegeFoods.Models.AccountModel;
using VegeFoods.Models.AdminModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Controllers.Customer
{
    public class CustomerAccountController : Controller
    {
        public ActionResult LoginCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCustomer(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new AccountModel().Login(model.Account, model.Password);

                if (result == 2)
                {
                    var user = new AccountModel().getUser(model.Account);

                    Session["Customer"] = user.Account;

                    return RedirectToAction("Index", "Shop");
                }
                else
                {
                    ViewBag.Error = "Incorrect account or password";
                }
            }
            return View();
        }

        public ActionResult LogoutCustomer()
        {
            Session.Remove("Customer");
            // Delete session form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("Index","Shop");
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel();
                if (user.checkAccount(model.Account))
                {
                    ViewBag.Error = "Account name already exists";

                }
                else if (user.checkEmail(model.Email))
                {
                    ViewBag.Error = "Email already exists";
                }
                else
                {
                    var userNew = new User();
                    userNew.Account = model.Account;
                    userNew.Password = model.Password;
                    userNew.Email = model.Email;
                    userNew.PhoneNumber = model.PhoneNumber;
                    userNew.FullName = model.FullName;

                    userNew.Role_ID = 2;

                    var result = new UserModel().Insert(userNew);
                    if (result > 0)
                    {
                        ViewBag.Success = "Register success";
                        // Reset model
                        model = new RegisterModel();
                    }
                    else
                    {
                        ViewBag.Error = "Register failed";
                    }
                }
            }

            return View(model);
        }
    }
}