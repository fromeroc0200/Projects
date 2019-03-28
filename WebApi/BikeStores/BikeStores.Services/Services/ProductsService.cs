using BikeStores.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeStores.Services.Services
{
    public class ProductsService : IProductsService
    {
        BikeStoresEntities db = new BikeStoresEntities();

        public List<products> GetProducts()
        {
            try
            {
                return db.products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public products GetProduct(int id)
        {
            try
            {
                return db.products.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public void InsertProduct(products products)
        {
            try
            {
                db.products.Add(products);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateProduct(int id, products products)
        {
            try
            {
                db.Entry(products).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void DeleteProduct(int id)
        {
            try
            {
                products product = GetProduct(id);
                db.products.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}