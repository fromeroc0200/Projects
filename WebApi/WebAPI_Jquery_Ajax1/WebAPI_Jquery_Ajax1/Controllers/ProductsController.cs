using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Jquery_Ajax1.Models;

namespace WebAPI_Jquery_Ajax1.Controllers
{
    public class ProductsController : ApiController
    {
        ProductEntities db = new ProductEntities();
        [HttpGet]
        public IQueryable<Products> GetProducts()
        {
            return db.Products;
        }
        [HttpGet()]
        public IHttpActionResult GetProduct(int id)
        {
            Products product = db.Products.Find(id);
            if (product == null)
               return NotFound();
            return Ok(product);
        }

    }
}
