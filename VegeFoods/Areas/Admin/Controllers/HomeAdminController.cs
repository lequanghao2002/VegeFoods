using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Xml.Linq;
using VegeFoods.Models.AccountModel;
using VegeFoods.Models.AdminModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = new AccountModel().Login(model.Account, model.Password);
                
                if (result)
                {
                    var user = new AccountModel().getUser(model.Account);

                    Session["User"] = user.FullName;

                    return RedirectToAction("Index","Role");
                }
                else
                {
                    ViewBag.Error = "Incorrect account or password";
                }
            }
            return View();
        }

        public ActionResult Logout() 
        {
            Session.Remove("User");
            // Delete session form authent
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        public ActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var accountModel = new AccountModel();
                if (accountModel.CheckAccount(model.Account))
                {
                    ViewBag.Error = "Account name already exists";

                }
                else if (accountModel.CheckEmail(model.Email))
                {
                    ViewBag.Error = "Email already exists";
                }
                else
                {
                    var user = new User();
                    user.Account = model.Account;
                    user.Password = model.Password;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.FullName = model.FullName;

                    user.Role_ID = 2;
                    
                    var result = new UserModel().Insert(user);
                    if(result > 0)
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