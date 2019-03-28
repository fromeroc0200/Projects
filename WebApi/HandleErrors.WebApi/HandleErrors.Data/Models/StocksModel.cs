using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandleErrors.Data.Models
{
    public class StocksModel
    {
        public int store_id { get; set; }
        public int product_id { get; set; }
        public Nullable<int> quantity { get; set; }
    }
}