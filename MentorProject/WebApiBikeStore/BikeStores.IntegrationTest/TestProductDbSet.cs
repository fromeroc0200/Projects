using BikeStores.Data;
using BikeStores.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.IntegrationTest
{
    class TestProductDbSet: TestDbSet<products>
    {
        public override products Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.product_id == (int)keyValues.Single());
        }
        
    }
}
