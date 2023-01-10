using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VegeFoods.Models.AccountModel;
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
        public ActionResult Login(User model)
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
    }
}