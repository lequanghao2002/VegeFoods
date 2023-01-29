using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AccountModel
{
    public class RoleModel
    {
        DB_VegeFoodEntities db = null;
        public RoleModel() {
            db = new DB_VegeFoodEntities();
        }

        public List<Role> getAllRoleList()
        {
            return db.Roles.ToList();
        }

        public IEnumerable<Role> getRoleByPageList(int page = 1, int pageSize = 10)
        {
            return db.Roles.OrderBy(m => m.ID).ToPagedList(page, pageSize);
        }

        public Role findID(int id)
        {
            return db.Roles.Find(id);
        }

        public bool checkRoleName(string name)
        {
            return db.Roles.Count(m => m.Name == name) > 0;
        }

        public int Insert(Role entity)
        {
            db.Roles.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }

        public bool Update(Role entity)
        {
            try
            {
                var modelUpdate = db.Roles.Find(entity.ID);
                modelUpdate.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                // Handle error
                return false;
            }
        }

        public bool Delete(int id) {
            try
            {
                var modelDelete = db.Roles.Find(id);
                db.Roles.Remove(modelDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // Handle error
                return false;
            }
        }

        
    }
}