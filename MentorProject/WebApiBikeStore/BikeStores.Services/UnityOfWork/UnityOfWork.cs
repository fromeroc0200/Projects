using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using BikeStores.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Services.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly BikeStoresEntities _context;

        public UnityOfWork(BikeStoresEntities context)
        {
            _context = context;
            Products = new ProductsService(_context);
            Security = new SecurityService(_context);
            Brands = new BrandsService(_context);
            Categories = new CategoriesService(_context);
        }

        public IProductsService Products { get; private set; }

        public ICategoriesService Categories { get; private set; }

        public IBrandsService Brands { get; private set; }

        public ISecurityService Security { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}