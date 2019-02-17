using PatternDepenInjectUnityWcf.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatternDepenInjectUnityWcf.Services
{
    public class Logger : ILogger
    {
        public string Log(string msg)
        {
            string result = $"This is the msg: '{msg}'";
            return result;
        }
    }
}