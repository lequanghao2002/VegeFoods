using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AccountModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User model)
        {
            if(ModelState.IsValid)
            {
                var result = new AccountModel().Login(model.Account, model.Password);
                
                if (result)
                {
                    var user = new AccountModel().getID(model.Account);
                    var userSession = new Session();
                    userSession.UserID = user.ID;
                    userSession.UserName = user.FullName;

                    Session.Add("User", userSession);

                    return RedirectToAction("List","Role");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect account or password");
                }
            }
            return View("Index");
        }
    }
}