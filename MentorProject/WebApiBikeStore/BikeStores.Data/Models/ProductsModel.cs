using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStores.Data.Models
{
    public class ProductsModel
    {
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public int brand_id { get; set; }
        [Required]
        public int category_id { get; set; }
        public short model_year { get; set; }
        public decimal list_price { get; set; }
        public BrandsModel brands { get; set; }
        public CategoriesModel categories { get; set; }
        public IEnumerable<StocksModel> stocks { get; set; }
    }
}