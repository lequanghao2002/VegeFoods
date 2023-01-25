using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.CustomerModel
{
    [Serializable]
    public class CartModel
    {
        public Product product { get; set; }
        public int quantity { get; set; }
    }

    
}