using HandleErrors.Data;
using HandleErrors.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandleErrors.Service.Services
{
    public class ProductsService : IProductsService
    {
        BikeStoresEntities db = new BikeStoresEntities();

        public ValidationResult<IEnumerable<products>> GetProducts()
        {
            ValidationResult<IEnumerable<products>> result = new ValidationResult<IEnumerable<products>>();
            //result.Payload = db.products.ToList();
            var prods = db.products;

            if (prods == null)
            {
                result.Message = $"Products not found";
                var message = $"Products not found";
                result.IsError = true;
                result.Payload = null;
            }
            else
            {
                result.Payload = prods.ToList();
            }
            return result;         
        }
    }
}