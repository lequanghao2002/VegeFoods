using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AccountModel
{
    public class AccountModel
    {
        DB_VegeFoodEntities db = null;
        public AccountModel() {
            db = new DB_VegeFoodEntities();
        }

        public User getID(string accountName)
        {
            return db.Users.SingleOrDefault(m => m.Account == accountName);
        }

        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Login(string account, string password)
        {
            var result = db.Users.Count(m => m.Account== account 
                                        && m.Password == password
                                        /*&& m.Role_ID == 1*/);
            if(result > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}