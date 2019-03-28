using HandleErrors.Service.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HandleErrors.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IProductsService, ProductsService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}