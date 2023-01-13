using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AdminModel
{
    public class CategoryModel
    {
        DB_VegeFoodEntities db = null;
        public CategoryModel()
        {
            db = new DB_VegeFoodEntities();
        }
        public List<Category> getListAllCategory()
        {
            return db.Categories.ToList();
        }

        public int checkCategoryName(string name)
        {
            return db.Categories.Count(m => m.Name == name);
        }

        public Category findCategoryById(int id)
        {
            return db.Categories.Find(id);
        }

        public int Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }

        public bool Update(Category entity)
        {
            try
            {
                var updateModel = findCategoryById(entity.ID);
                updateModel.Name = entity.Name;
                db.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var deleteModel = findCategoryById(id);
                db.Categories.Remove(deleteModel);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}