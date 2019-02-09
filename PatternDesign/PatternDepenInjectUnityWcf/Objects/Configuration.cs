using PatternDepenInjectUnityWcf.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatternDepenInjectUnityWcf.Objects
{
    public class Configuration : IConfiguration
    {
        public bool EnableLogs { get; set; }
        public string Schema { get; set; }
        public string Xslt { get; set; }
    }
}