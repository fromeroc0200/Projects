using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    class DelegateFuncLambda
    {
        public static void DelegateExample4()
        {
            Func<double, double> cpointer = r => 3.1415 * r * r;
            double area = cpointer(20);
            Console.WriteLine(string.Format("Ejemplo delegado lambda + func. El area del circulo es: {0}", area));
        }


    }
}
