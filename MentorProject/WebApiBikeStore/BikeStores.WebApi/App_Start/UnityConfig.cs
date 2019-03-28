using BikeStores.Data.Repository;
using BikeStores.Services.Contracts;
using BikeStores.Services.Services;
using BikeStores.Services.UnityOfWork;
using System;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace BikeStores.WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnityOfWork, UnityOfWork>();
            container.RegisterType<IBrandsService, BrandsService>();
            container.RegisterType<ICategoriesService, CategoriesService>();
            container.RegisterType<IProductsService, ProductsService>();
            container.RegisterType<ISecurityService, SecurityService>();
            container.RegisterType<ILoggerManager, LoggerManager>();
            


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
       
        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            
            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}