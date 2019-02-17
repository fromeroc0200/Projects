using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_WebForm
{
    public class ProductsController : ApiController
    {
        DBModel db = new DBModel();
        // GET api/<controller>
        public IQueryable<Products> Get()
        {
            return db.Products;
        }

        // GET api/<controller>/5
        public IHttpActionResult GetProducts(int id)
        {
            var prod = db.Products.Find(id);
            if (prod == null)
                return NotFound();

            return Ok(prod);
        }

        public IQueryable<Products> GetProductsByCategory(string category)
        {
            return db.Products.Where(x => string.Equals(x.Category, category, StringComparison.OrdinalIgnoreCase));
            
        }

        
    }
}