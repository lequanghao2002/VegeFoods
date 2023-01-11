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

        public User getUser(string accountName)
        {
            return db.Users.SingleOrDefault(m => m.Account == accountName);
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

        public int Register(User entity)
        {
            if (db.Users.Count(m => m.Account == entity.Account) > 0)
            {
                return 1;
            } 
            else if (entity.Password.Length < 6)
            {
                return 2;
            }
            else if (entity.rePassword != entity.Password)
            {
                return 3;
            }
            else if (db.Users.Count(m => m.Email == entity.Email) > 0)
            {
                return 4;
            }
            else if (db.Users.Count(m => m.PhoneNumber == entity.PhoneNumber) > 0)
            {
                return 5;
            }
            else
            {
                entity.Role_ID = 2;
                db.Users.Add(entity);
                db.SaveChanges();
                return 0;
            }
            
        }
    }
}