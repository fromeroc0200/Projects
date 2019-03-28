using BikeStores.Services.Contracts;
using BikeStores.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Services.UnityOfWork
{
    /// <summary>
    /// This interface is for unity test becuase this interface expose the repositories as mock interface
    /// This interface is for unity test becuase this interface expose the repositories as mock interface
    /// </summary>
    public interface IUnityOfWork: IDisposable
    {
        IProductsService Products { get; }
        ICategoriesService Categories { get; }
        IBrandsService Brands { get; }
        ISecurityService Security { get; }
        int Complete();
    }
}
