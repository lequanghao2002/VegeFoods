using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VegeFoods.Models.BD_VegeFoods;

namespace VegeFoods.Models.AccountModel
{
    [Serializable]
    public class Session
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
    }
}