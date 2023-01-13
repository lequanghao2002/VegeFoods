using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AccountModel;
using VegeFoods.Models.AdminModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        UserModel user = new UserModel();
        public void setViewBag(int? selectedID = null)
        {
            var role = new RoleModel();
            // SelectList(List Role, selected Value - Trường làm id, Text - Hiển thị tên trường, selected - Giá trị chọn sẵn - dùng cho edit)
            ViewBag.Role_ID = new SelectList(role.getAllRoleList(), "ID", "Name", selectedID);
        }

        public ActionResult Index()
        {
            return View(user.getAllUserList());
        }

        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                var accountModel = new AccountModel();
                if (accountModel.CheckAccount(model.Account))
                {
                    ModelState.AddModelError("", "Account already exists");
                }
                else if (accountModel.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email already exists");
                    //ViewBag.Error = "Email already exists";
                }
                else
                {
                    int id = user.Insert(model);
                    if (id > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User creation failed");
                    }
                }
            }
            setViewBag();
            return View();
        }
    
        public ActionResult Edit(int id)
        {
            var result = user.findUserById(id);
            setViewBag(result.Role_ID);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                if (user.checkAccount(model.Account) > 1)
                {
                    ModelState.AddModelError("", "Account already exists");
                }
                else if (user.checkEmail(model.Email) > 1) 
                {
                    ModelState.AddModelError("", "Email already exists");
                    //ViewBag.Error = "Email already exists";
                }
                else
                {
                    if (user.Update(model))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User update failed");
                    }
                }
            }
            setViewBag();
            return View();
        }

        public ActionResult Delete(int id)
        {
            user.Delete(id);
            return RedirectToAction("Index");
        }
    }
}