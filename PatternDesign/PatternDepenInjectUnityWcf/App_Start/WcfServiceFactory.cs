using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PatternDepenInjectUnityWcf.Contract;
using PatternDepenInjectUnityWcf.Objects;
using PatternDepenInjectUnityWcf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Unity.Wcf;

namespace PatternDepenInjectUnityWcf {
    public class WcfServiceFactory : UnityServiceHostFactory {

        protected override void ConfigureContainer(IUnityContainer container) {
            //container.LoadConfiguration();
            
            container.RegisterType<IService1, Service1>();
            container.RegisterType<ICFDI, CFDI>();
            container.RegisterType<IConfiguration, Configuration>();
            container.RegisterType<ILogger, Logger>();
           
           
        }
    }
}
