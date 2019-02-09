using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternInjectionInstanceConsole
{
    public interface INotification
    {
        string Format(string message);
    }
}
