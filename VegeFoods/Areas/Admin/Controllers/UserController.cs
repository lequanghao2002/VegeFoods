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
        UserModel userModel = new UserModel();
        public void setViewBag(int? selectedID = null)
        {
            var roleModel = new RoleModel();
            // SelectList(List Role, selected Value - Trường làm id, Text - Hiển thị tên trường, selected - Giá trị chọn sẵn - dùng cho edit)
            ViewBag.Role_ID = new SelectList(roleModel.getAllRoleList(), "ID", "Name", selectedID);
        }

        public ActionResult Index()
        {
            return View(userModel.getAllUserList());
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
                if (userModel.checkAccount(model.Account))
                {
                    ModelState.AddModelError("", "Account already exists");
                }
                else if (userModel.checkEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email already exists");
                    //ViewBag.Error = "Email already exists";
                }
                else
                {
                    int id = userModel.Insert(model);
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
            var result = userModel.findUserById(id);
            setViewBag(result.Role_ID);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                var user = userModel.findUserById(model.ID);
                if (user.Account == model.Account && user.Password == model.Password
                    && user.FullName == model.FullName && user.Email == model.Email
                    && user.Address == model.Address && user.PhoneNumber == model.PhoneNumber
                    && user.Role_ID == model.Role_ID)
                {
                    return RedirectToAction("Index");
                }
                else if (userModel.checkAccount(model.Account))
                {
                    ModelState.AddModelError("", "Account already exists");
                }
                else if (userModel.checkEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email already exists");
                    //ViewBag.Error = "Email already exists";
                }
                else
                {
                    if (userModel.Update(model))
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
            userModel.Delete(id);
            return RedirectToAction("Index");
        }
    }
}