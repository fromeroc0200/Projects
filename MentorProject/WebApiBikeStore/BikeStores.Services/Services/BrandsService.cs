using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BikeStores.Services.Services
{
    public class BrandsService : Repository<brands>, IBrandsService
    {
        BikeStoresEntities db = new BikeStoresEntities();

        public BrandsService(BikeStoresEntities context): base(context) { }

        public ProcessResult UpdateBrand(int id, brands brands)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                var brand = db.brands.Find(id);
                if (brand == null)
                {
                    result.Message = $"Brand with ID: {id} is not found or not exist";
                    result.StatusCode = HttpStatusCode.NotFound;
                    result.HasError = true;

                }
                else
                {
                    if (brand != null)
                    {
                        //Detached db entity
                        db.Entry(brand).State = System.Data.Entity.EntityState.Detached;
                    }
                    db.brands.Attach(brands);
                    db.Entry(brands).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    result.Message = "Brand updated.";
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