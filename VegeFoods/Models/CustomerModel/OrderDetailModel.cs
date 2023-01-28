using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.CustomerModel
{
    public class OrderDetailModel
    {
        DB_VegeFoodEntities db = null;
        public OrderDetailModel() { 
            db = new DB_VegeFoodEntities();
        }
        public bool Insert(OrderDetail entity)
        {
            try
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OrderDetail getOrderDetailByProductID(int id)
        {
            var result = (from orderDetail in db.OrderDetails
                          where orderDetail.Product_ID == id
                          select orderDetail).Take(1).SingleOrDefault();

            return result;
        }

        public List<OrderDetail> getOrderDetailByOrderID(int id)
        {
            var result = (from orderDetail in db.OrderDetails
                          where orderDetail.Order_ID == id
                          select orderDetail).ToList();

            return result;
        }
    }
}