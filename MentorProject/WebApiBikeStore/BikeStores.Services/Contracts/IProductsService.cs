using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BikeStores.Services.Contracts
{
    public interface IProductsService: IRepository<products>
    {
        ProcessResult UpdateProduct(int id, products products);
    }
}
