using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using BikeStores.WebApi;

namespace BikeStores.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
       

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            HttpConfiguration config = GlobalConfiguration.Configuration;
            UnityConfig.RegisterComponents();
            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            
        }
    }
}
