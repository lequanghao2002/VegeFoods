﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AccountModel
{
    public class RoleModel
    {
        static DB_VegeFoodEntities db = null;
        public RoleModel() {
            db = new DB_VegeFoodEntities();
        }

        public List<Role> getAllRoleList()
        {
            return db.Roles.ToList();
        }

        public Role findID(int id)
        {
            return db.Roles.Find(id);
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