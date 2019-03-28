using BikeStores.Data;
using System.Collections.Generic;
using System.Linq;

namespace BikeStores.Services.Services
{
    public interface IProductsService
    {
        List<products> GetProducts();
        products GetProduct(int id);
        void InsertProduct(products products);
        void UpdateProduct(int id, products products);
        void DeleteProduct(int id);
    }
}
