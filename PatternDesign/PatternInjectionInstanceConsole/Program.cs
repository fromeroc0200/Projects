using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternInjectionInstanceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailNotification emailNotification = new EmailNotification();
            LogNotification logNotification = new LogNotification();
            FormatNotification formatNotification = null;

            formatNotification = new FormatNotification(emailNotification);
            Console.WriteLine(formatNotification.Notify("Metodo de inserción de instancias"));
            formatNotification = new FormatNotification(logNotification);
            Console.WriteLine(formatNotification.Notify("Metodo de inserción de instancias"));
            Console.ReadLine();
        }
    }
}
