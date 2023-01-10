using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VegeFoods.Models.AccountModel;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var session = Session["User"];
            //if (session == null)
            //{
            //    filterContext.Result = new RedirectToRouteResult(
            //        new RouteValueDictionary(
            //            new { controller = "HomeAdmin", action = "Login", Area = "Admin" }
            //        ));
            //}

            base.OnActionExecuting(filterContext);
        }
    }
}