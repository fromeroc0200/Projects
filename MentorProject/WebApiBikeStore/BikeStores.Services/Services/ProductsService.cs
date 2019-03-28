using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeStores.Services.Services
{
    public class ProductsService : Repository<products>, IProductsService
    {
        BikeStoresEntities db = new BikeStoresEntities();

        public ProductsService(BikeStoresEntities context) : base(context)
        {    
        }

        public ProcessResult UpdateProduct(int id, products products)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                var prod = db.products.Find(id);
                if (prod == null)
                {
                    result.Message = $"Product with ID: {id} is not found or not exist";
                    result.StatusCode = HttpStatusCode.NotFound;
                    result.HasError = true;
                    
                }
                else
                {
                    if (prod != null)
                    {
                        //Detached db entity
                        db.Entry(prod).State = EntityState.Detached;
                    }
                    db.products.Attach(products);
                    db.Entry(products).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    result.Message = "Product updated.";
                    result.StatusCode = HttpStatusCode.NoContent;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = $"Something went wrong: {ex}";
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;
        }

        
    }
}