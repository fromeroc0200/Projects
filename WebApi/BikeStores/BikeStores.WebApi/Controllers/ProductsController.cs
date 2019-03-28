using BikeStores.Data.Models;
using BikeStores.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BikeStores.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductsService productsService = new ProductsService();

        FactoryModel _factoryModel;

        private ProductsController()
        {
            _factoryModel = new FactoryModel();
        }

        public IEnumerable<ProductsModel> Get()
        {
            try
            {
                return productsService.GetProducts().Select(p => _factoryModel.Create(p));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IHttpActionResult Get(int id)
        {
            var product = productsService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        
    }
}
