using HandleErrors.Data.Models;
using HandleErrors.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HandleErrors.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        IProductsService _productsService;
        ModelFactory _modelFactory;
        public ProductsController(IProductsService productsService)
        {
            this._productsService = productsService;
            _modelFactory = new ModelFactory();
        }
        
        [HttpGet]
        public HttpResponseMessage Get()
        {

            var result = _productsService.GetProducts();
            if(result.IsError)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            var products = result.Payload.Select(p => _modelFactory.Create(p));
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }
    }
}
