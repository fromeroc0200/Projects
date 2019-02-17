using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            // lambda + func
            Func<double, double> cpointer = r => 3.1416 * r * r;
            double area = cpointer(20);
            Console.WriteLine(string.Format("El area del circulo es: {0}", area));
            Console.ReadLine();
        }
    }
}
