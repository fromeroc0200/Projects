using System.Collections.Generic;
using HandleErrors.Data;
using HandleErrors.Data.Models;

namespace HandleErrors.Service.Services
{
    public interface IProductsService
    {
        ValidationResult<IEnumerable<products>> GetProducts();
    }
}