using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BikeStores.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //--Excecute nuget console
            //Install-Package Microsoft.AspNet.WebApi.Cors 
            //# NuGet Command : Fix Version Compactability of Cors and Http
            //Update - Package Microsoft.AspNet.WebApi - reinstall
            //Install - Package Microsoft.AspNet.WebApi.Core

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors); // Se agrega Cors para compatibilidad con angular



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
