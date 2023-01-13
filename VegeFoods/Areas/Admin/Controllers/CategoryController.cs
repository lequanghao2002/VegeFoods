using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AdminModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryModel categoryModel = new CategoryModel();
        public ActionResult Index()
        {
            return View(categoryModel.getListAllCategory());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                if(categoryModel.checkCategoryName(model.Name) > 0)
                {
                    ModelState.AddModelError("", "Name already exists");
                }
                else
                {
                    var result = categoryModel.Insert(model);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Category create failed");
                    }
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View(categoryModel.findCategoryById(id));
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                if (categoryModel.checkCategoryName(model.Name) > 1)
                {
                    ModelState.AddModelError("", "Name already exists");
                }
                else
                {
                    if (categoryModel.Update(model))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Category update failed");
                    }
                }
            }
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            categoryModel.Delete(id);
            return RedirectToAction("Index");
        }
    }
}