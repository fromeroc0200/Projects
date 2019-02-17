using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternInjectionInstanceConsole
{
    public class LogNotification : INotification
    {
        public string Format(string message)
        {
            return string.Format("LogNotification: {0}", message);
        }
    }
}
