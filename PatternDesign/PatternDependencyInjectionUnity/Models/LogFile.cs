using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PatternDependencyInjectionUnity.Models
{
    public class LogFile : ILog
    {
        public void Log(string log)
        {
            Debug.Write(log);
        }
    }
}