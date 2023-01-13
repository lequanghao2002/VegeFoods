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
        public List<User> getAllUserList()
        {
            return db.Users.ToList();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();

            return entity.ID;
        }

        public User findUserById(int id)
        {
            return db.Users.Find(id);
        }

        public bool checkAccount(string account)
        {
            return db.Users.Count(m => m.Account == account) > 0;
        }
        public bool checkEmail(string email)
        {
            return db.Users.Count(m => m.Email == email) > 0;
        }

        public bool Update(User entity)
        {
            try
            {
                var modelUpdate = db.Users.Find(entity.ID);
                modelUpdate.Account = entity.Account;
                modelUpdate.Password = entity.Password;
                modelUpdate.FullName = entity.FullName;
                modelUpdate.Email = entity.Email;
                modelUpdate.PhoneNumber = entity.PhoneNumber;
                modelUpdate.Address = entity.Address;
                modelUpdate.Role_ID = entity.Role_ID;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // Handle error
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var modelDelete = db.Users.Find(id);
                db.Users.Remove(modelDelete);
                db.SaveChanges() ;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}