using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    public static class DelegateLambda
    {
        private delegate double CalclulaAreaPointer(int r);
        public static void DelegateExam3()
        {
            CalclulaAreaPointer obj = r => 3.1416 * r * r;
            double Area = obj(20);
            Console.WriteLine(string.Format("Ejemplo delegado con Lambda 3. el area del circulo es: {0}",Area));
        }
        
    }
}
