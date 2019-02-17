using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternInjectionInstanceConsole
{
    public class EmailNotification : INotification
    {
        public string Format(string message)
        {
            return string.Format("Email notification: {0}", message);
        }
    }
}
