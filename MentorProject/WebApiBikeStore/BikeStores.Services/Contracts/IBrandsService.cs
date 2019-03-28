using System.Collections.Generic;
using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;

namespace BikeStores.Services.Contracts
{
    public interface IBrandsService: IRepository<brands>
    {
        ProcessResult UpdateBrand(int id, brands brands);
    }
}