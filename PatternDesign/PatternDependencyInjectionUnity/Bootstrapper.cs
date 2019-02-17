using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PatternDependencyInjectionUnity.Models;
//--Se instalo de nuget Unity.MVC4 que descarga este archivo
using Unity.Mvc4;

namespace PatternDependencyInjectionUnity
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    //--Implememntamos nuestra configuración
    public static void RegisterTypes(IUnityContainer container)
    {
            //--Creamos nuestro container
            container.RegisterType<ILog, LogFile>();
    }
  }
}