using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternSingletonConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Singleton.CreateInstance().Message);
            Singleton.CreateInstance().Message = "Se modifico codigo singleton";
            Console.WriteLine(Singleton.CreateInstance().Message);
            Console.ReadLine();

            Console.WriteLine(SingletonProperty.Instance.Message);
            SingletonProperty.Instance.Message = "Modificacion singleton texto";
            Console.WriteLine(SingletonProperty.Instance.Message);
            Console.ReadLine();
        }
    }
}
