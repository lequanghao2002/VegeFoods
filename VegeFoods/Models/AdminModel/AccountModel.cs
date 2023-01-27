using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.AdminModel;
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

        public int Login(string account, string password)
        {
            var resultAdmin = db.Users.Count(m => m.Account== account 
                                        && m.Password == password
                                        && m.Role_ID == 1);

            var resultCustomer = db.Users.Count(m => m.Account == account
                                        && m.Password == password
                                        && m.Role_ID == 2);

            if (resultAdmin > 0 )
            {
                return 1;
            }
            else if (resultCustomer > 0)
            {
                return 2;
            }
            else 
            {
                return 0;
            }
        }
    
    }
}