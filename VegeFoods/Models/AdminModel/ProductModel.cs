using PagedList;
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

        public IEnumerable<Product> getProductByPageList(int page = 1, int pageSize = 10)
        {
            return db.Products.OrderBy(m => m.ID).ToPagedList(page, pageSize);
        }

        //public List<Product> getProductListByCategory(int? filterCategoryById)
        //{
        //    var result = (from product in db.Products
        //                  where product.Category_ID == filterCategoryById || filterCategoryById == null
        //                  select product).ToList();
        //    return result;
        //}
        public IEnumerable<Product> getProductListByCategory(int? filterCategoryById, int page = 1, int pageSize = 8)
        {
            var result = (from product in db.Products
                          where product.Category_ID == filterCategoryById || filterCategoryById == null
                          select product);
            return result.OrderBy(m => m.ID).ToPagedList(page, pageSize);
        }

        public Product getProductById(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> get4RelatedProducts(int id)
        {
            var productFind = db.Products.Find(id);
            var result = (from product in db.Products
                         where product.Category_ID == productFind.Category_ID
                            && product.ID != id
                         orderby product.ID descending
                         select product).Take(4).ToList();
            return result;
        }

        public List<Product> get8FeaturedProducts()
        {
            var result = (from product in db.Products
                          orderby product.ID descending
                          select product).Take(8).ToList();
            return result;
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

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(m => m.Name.Contains(keyword)).Select(m => m.Name).ToList();
        }
        public IEnumerable<Product> Search(string keyword, int page = 1, int pageSize = 8)
        {
            var result = (from product in db.Products
                          where product.Name.Contains(keyword)
                          select product);
            return result.OrderBy(m => m.ID).ToPagedList(page, pageSize);
        }
    }
}