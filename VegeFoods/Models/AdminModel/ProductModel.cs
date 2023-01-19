using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AdminModel
{
    public class ProductModel
    {
        DB_VegeFoodEntities db = null;

        public ProductModel()
        {
            db = new DB_VegeFoodEntities();
        }

        public List<Product> getAllProductList()
        {
            return db.Products.ToList();
        }

        public List<Product> getProductListByCategory(int? filterCategoryById)
        {
            var result = (from product in db.Products
                          where product.Category_ID == filterCategoryById || filterCategoryById == null
                          select product).ToList();
            return result;
        }

        public Product getProductById(int id)
        {
            return db.Products.Find(id);
        }

        public bool Insert(Product entity)
        {
            try
            {
                db.Products.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product entity)
        {
            try
            {
                var modelUpdate = db.Products.Find(entity.ID);
                modelUpdate.Name = entity.Name;
                modelUpdate.Category_ID = entity.Category_ID;
                modelUpdate.Describe = entity.Describe;
                modelUpdate.Price = entity.Price;
                modelUpdate.Discount = entity.Discount;
                modelUpdate.Image = entity.Image;

                db.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var modelDelete = getProductById(id);
                db.Products.Remove(modelDelete);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}