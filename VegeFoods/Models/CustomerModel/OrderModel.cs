using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}