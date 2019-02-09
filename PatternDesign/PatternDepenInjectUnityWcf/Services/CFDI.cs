using PatternDepenInjectUnityWcf.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatternDepenInjectUnityWcf.Services
{
    public class CFDI : ICFDI
    {
        ILogger logger;
        IConfiguration configuration;


        public CFDI(ILogger logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public string Stamp(string comprobante)
        {
            
            configuration.Schema = "This is the schema";
            return logger.Log($"{comprobante}, HAAAAAAA!!! It's work, Schema: {configuration.Schema}");
        }
    }
}