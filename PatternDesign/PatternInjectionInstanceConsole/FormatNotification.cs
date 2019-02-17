using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternInjectionInstanceConsole
{
    public class FormatNotification
    {
        private INotification notification = null;

        public FormatNotification(INotification instanceNotification)
        {
            this.notification = instanceNotification;
        }

        public string Notify(string message)
        {
            return notification.Format(message);
        }

    }
}
