using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AdminModel
{
    public class UserModel
    {
        DB_VegeFoodEntities db = null;
        public UserModel() {
            db = new DB_VegeFoodEntities();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }

    }
}