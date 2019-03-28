using BikeStores.Data;
using BikeStores.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.IntegrationTest
{
    class TestCategoriesDbSet: TestDbSet<categories>
    {
        public override categories Find(params object[] keyValues)
        {
            return this.SingleOrDefault(category => category.category_id == (int)keyValues.Single());
        }
    }
}
