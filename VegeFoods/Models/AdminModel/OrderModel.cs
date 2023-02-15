using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.CustomerModel
{
    public class OrderModel
    {
        DB_VegeFoodEntities db = null;
        public OrderModel()
        {
            db = new DB_VegeFoodEntities();
        }

        public List<Order> getAllOrderList()
        {
            return db.Orders.ToList();
        }

        public IEnumerable<Order> getOrderByPageList(int page = 1, int pageSize = 10, string nameSearch = null, string phoneSearch = null)
        {
            var result = (from order in db.Orders
                          where ((order.FullName.Contains(nameSearch) || nameSearch == null) && (order.PhoneNumber.Contains(phoneSearch) || phoneSearch == null))
                          select order).ToList();
            return result.OrderBy(m => m.ID).ToPagedList(page, pageSize);
        }

        public List<Order> getOrderByUser(int id)
        {
            var result = (from order in db.Orders
                          where order.User_ID == id 
                          select order).ToList();

            return result;
        }

        public Order getOrder(int id)
        {
            return db.Orders.Find(id);
        }

        public int Insert(Order entity)
        {
            try
            {
                db.Orders.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch
            {
                return 0;
            }
        }

        public bool Cancel(Order entity)
        {
            try
            {
                entity.Status = 0;
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