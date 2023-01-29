using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegeFoods.Models.AdminModel;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        ProductModel productModel = new ProductModel();

        public void setViewBag(int? selectedID = null)
        {
            var categoryModel = new CategoryModel();
            ViewBag.Category_ID = new SelectList(categoryModel.getListAllCategory(), "ID", "Name", selectedID);
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {

            return View(productModel.getProductByPageList(page, pageSize));
        }

        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                if (productModel.Insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Product creation failed");
                }
            }
            setViewBag();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = productModel.getProductById(id);
            setViewBag(product.Category_ID);
            return View(product);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                var product = productModel.getProductById(model.ID);
                if (product.Name == model.Name && product.Category_ID == model.Category_ID
                    && product.Price == model.Price && product.Discount == model.Discount
                    && product.Image == model.Image && product.Describe == model.Describe)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (productModel.Update(model))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Product update failed");
                    }
                }
            }
            setViewBag();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            productModel.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(productModel.getProductById(id));
        }
    }
}