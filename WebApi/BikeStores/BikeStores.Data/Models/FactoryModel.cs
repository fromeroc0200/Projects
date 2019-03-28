using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Data.Models
{
    public class FactoryModel
    {
        // se aplica => que es como hacer un return new ProductsModel() { ... }
        public ProductsModel Create(products products) => new ProductsModel()
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

        private StocksModel Create(stocks stocks) => new StocksModel()
        {
            store_id = stocks.store_id,
            quantity = stocks.quantity
        };

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
    }
}