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
    }
}