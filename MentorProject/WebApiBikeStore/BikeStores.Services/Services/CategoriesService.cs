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
    public class CategoriesService : Repository<categories>, ICategoriesService
    {
        BikeStoresEntities db = new BikeStoresEntities();

        public CategoriesService(BikeStoresEntities context): base (context){ }

        public ProcessResult UpdateCategory(int id, categories categories)
        {
            ProcessResult result = new ProcessResult();
            try
            {
                var cat = db.categories.Find(id);
                if (cat == null)
                {
                    result.Message = $"Category with ID: {id} is not found or not exist";
                    result.StatusCode = HttpStatusCode.NotFound;
                    result.HasError = true;

                }
                else
                {
                    if (cat != null)
                    {
                        //Detached db entity
                        db.Entry(cat).State = System.Data.Entity.EntityState.Detached;
                    }
                    
                    db.categories.Attach(categories);
                    db.Entry(categories).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    result.Message = "Category updated.";
                    result.StatusCode = HttpStatusCode.NoContent;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = $"Something went wrong: {ex}";
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            finally
            {
                db.Dispose();
            }
            return result;
        }
    }
}