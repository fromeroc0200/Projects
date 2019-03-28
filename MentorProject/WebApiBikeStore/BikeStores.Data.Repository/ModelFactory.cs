using BikeStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Data.Repository
{
    public class ModelFactory
    {

        public ModelFactory()
        {

        }

        #region Factory Model

        // se aplica => que es como hacer un return new ProductsModel() { ... }
        public ProductsModel Create(products products)
        {   
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
            
            return model;
        }

        public StocksModel Create(stocks stocks)
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

        public BrandsModel Create(brands model)
        {
            BrandsModel brand = null;
            if(model != null)
            {
                brand = new BrandsModel()
                {
                    brand_id = model.brand_id,
                    brand_name = model.brand_name
                };
            }
            return brand;
        }

        public CategoriesModel Create(categories model) 
        {
            CategoriesModel category = null;
            if(model != null)
            {
                category = new CategoriesModel()
                {
                    category_id = model.category_id,
                    category_name = model.category_name
                };
            }
            return category;
        }

        #endregion

        #region Factory Entities
        
        public ProcessResult<products> Parse(ProductsModel model)
        {
            products product = null;
            var result = new ProcessResult<products>();

            try
            {
                #region Validations Fields
                if (string.IsNullOrWhiteSpace(model?.product_name))
                {
                    result.AddFieldError(nameof(model.product_name));
                }
                #endregion


                if (model != null)
                    product = new products()
                    {
                        product_id = model.product_id,
                        product_name = model.product_name,
                        brand_id = model.brand_id,
                        category_id = model.category_id,
                        list_price = model.list_price,
                        model_year = model.model_year,
                        stocks = model.stocks != null ? model.stocks.Select(s => Create(s)).ToList() : null
                    };


                result.Message = "Successfully performed Parse";
                result.HasError = false;
            }
            catch (Exception ex)
            {
                result.Message = $"Failed to perform Parse. Details: {ex.Message}";
                result.HasError = true;
            }

            result.Content = product;
            return result;
        }

        public ProcessResult<categories> Parse(CategoriesModel model)
        {
            categories category = null;
            var result = new ProcessResult<categories>();

            try
            {
                #region Validations Fields
                if (string.IsNullOrWhiteSpace(model?.category_name))
                {
                    result.AddFieldError(nameof(model.category_name));
                }
                #endregion

                if (model != null)
                {
                    category = Create(model);
                }

                result.Message = "Successfully performed Parse";
                result.HasError = false;
            }
            catch (Exception ex)
            {
                result.Message = $"Failed to perform Parse. Details: {ex.Message}";
                result.HasError = true;
            }

            result.Content = category;
            return result;
        }


        public ProcessResult<user> Parse(UserModel model)
        {
            user user = null;
            var result = new ProcessResult<user>();
            try
            {
                if (model != null)
                    user = new user()
                    {
                        UserId = model.UserId,
                        UserName = model.UserName,
                        Password = model.Password
                    };

                result.Message = "Successfully performed Parse";
                result.HasError = false;
            }
            catch (Exception ex)
            {
                result.Message = $"Failed to perform Parse. Details: {ex.Message}";
                result.HasError = true;
            }
            result.Content = user;

            return result;
        }


        private brands Create(BrandsModel model)
        {
            brands brand = null;

            if (model != null)
                brand = new brands()
                {
                    brand_id = model.brand_id,
                    brand_name = model.brand_name
                };

            return brand;
        }
        
        private categories Create(CategoriesModel model)
        {
            categories category = null;
            if (model != null)
                category = new categories()
                {
                    category_id = model.category_id,
                    category_name = model.category_name
                };
            return category;
        }

        private stocks Create(StocksModel model)
        {
            stocks stock = null;
            if (model != null)
                stock = new stocks()
                {
                    store_id = model.store_id,
                    product_id = model.product_id,
                    quantity = model.quantity
                };
            return stock;
        }

        #endregion
    }
}