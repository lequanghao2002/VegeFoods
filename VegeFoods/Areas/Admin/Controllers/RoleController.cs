using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AccountModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View(new RoleModel().getAllRoleList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Role model)
        {
            if (ModelState.IsValid)
            {
                int id = new RoleModel().Insert(model);

                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Role creation failed");
                }
            } 
            
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new RoleModel().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(new RoleModel().findID(id));
        }
        [HttpPost]
        public ActionResult Edit(Role model)
        {
            if (ModelState.IsValid)
            {
                var result = new RoleModel().Update(model);
                if(result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Role update failed");
                }
            }
            return View();
        }
    }
}