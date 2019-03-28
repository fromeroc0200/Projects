using BikeStores.Data;
using BikeStores.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.IntegrationTest
{
    public class TestBikeStoreContext : BikeStoresEntities
    {
        //Creating constructor for products
        public TestBikeStoreContext()
        {
            this.products = new TestProductDbSet();
            this.categories = new TestCategoriesDbSet();
        }
    }
}
