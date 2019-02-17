using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    public static class DelegateExample2
    {
        private delegate double CalculaAreaPointer(int r);
        public static void DelegateExam2()
        {
            CalculaAreaPointer obj = new CalculaAreaPointer(CalculaArea);
            var result = obj.Invoke(20);
            Console.WriteLine(string.Format("Ejemplo delegado 2. el calculo del area del circule es: {0}", result));
        }

        private static double CalculaArea(int r)
        {
            return (3.1416 * r * r);
        }
    }
}
