using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandleErrors.Data.Models
{
    public class ModelFactory
    {

        public ModelFactory()
        {

        }

        #region Factory Model
        
        // se aplica => que es como hacer un return new ProductsModel() { ... }
        public ValidationResult Create(products products)
        {
            var ret = new ValidationResult();
            ProductsModel model = null;
            if (products != null)
                model = new ProductsModel()
                {
                    product_id = products.product_id,
                    product_name = products.product_name,
                    brand_id = products.brand_id,
                    category_id = products.category_id,
                    model_year = products.model_year,
                    list_price = products.list_price,
                    stocks = products.stocks.Select(s => Create(s)),
                    brands = Create(products.brands),
                    categories = Create(products.categories)
                };
            if (ret.IsError)
            {
                ret.Message = "Failed to perform DoSomeAction";
                return ret;
            }

            ret.Message = "Successfully performed DoSomeAction";
            ret.Payload = model;
            return ret;
            //return model;
        }

        private StocksModel Create(stocks stocks)
        {
            StocksModel model = null;
            if (stocks != null)
                model = new StocksModel()
                {
                    store_id = stocks.store_id,
                    quantity = stocks.quantity,
                    product_id = stocks.product_id
                };
            return model;
        }

        private BrandsModel Create(brands brands) => new BrandsModel()
        {
            brand_id = brands.brand_id,
            brand_name = brands.brand_name
        };

        private CategoriesModel Create(categories categories) => new CategoriesModel()
        {
            category_id = categories.category_id,
            category_name = categories.category_name
        };

        #endregion

        
    }
}