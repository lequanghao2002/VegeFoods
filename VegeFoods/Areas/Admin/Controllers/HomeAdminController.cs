using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
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
                    //var userSession = new Session();
                    //userSession.UserID = user.ID;
                    //userSession.UserName = user.FullName;
                    //Session.Add("User", userSession);

                    Session["User"] = user.FullName;

                    return RedirectToAction("Index","Role");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect account or password");
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
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var result = new AccountModel().Register(model);

                if (result == 1)
                {
                    ModelState.AddModelError("", "Account name already exists");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Password must contain at least 6 characters");
                }
                else if (result == 3)
                {
                    ModelState.AddModelError("", "Re-entered password is incorrect");
                }
                else if (result == 4)
                {
                    ModelState.AddModelError("", "Email already exists");
                }
                else if (result == 5)
                {
                    ModelState.AddModelError("", "Phone number already in use");
                }
            }
            
            return View(model);
        }
    }
}