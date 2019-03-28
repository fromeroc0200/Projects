using System.Collections.Generic;
using BikeStores.Data;
using BikeStores.Data.Models;
using BikeStores.Data.Repository;

namespace BikeStores.Services.Contracts
{
    public interface ICategoriesService: IRepository<categories>
    {
        ProcessResult UpdateCategory(int id, categories categories);
    }
}