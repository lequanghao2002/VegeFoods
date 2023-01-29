using Microsoft.Ajax.Utilities;
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
        RoleModel roleModel = new RoleModel();
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            return View(roleModel.getRoleByPageList(page, pageSize));
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
                int id = roleModel.Insert(model);

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

        public ActionResult Edit(int id)
        {
            return View(roleModel.findID(id));
        }
        [HttpPost]
        public ActionResult Edit(Role model)
        {
            if (ModelState.IsValid)
            {
                var role = roleModel.findID(model.ID);
                if(role.Name == model.Name)
                {
                    return RedirectToAction("Index");
                }
                else if (roleModel.checkRoleName(model.Name))
                {
                    ModelState.AddModelError("", "Name already exists");
                }
                else
                {
                    var result = roleModel.Update(model);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Role update failed");
                    }
                }
                
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            roleModel.Delete(id);
            return RedirectToAction("Index");
        }
    }
}