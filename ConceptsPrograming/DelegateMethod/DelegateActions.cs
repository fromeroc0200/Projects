using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    public static class DelegateActions
    {
        public static void DelegateExample5()
        {
            Action<string> cpoint = y => Console.WriteLine(y);
            cpoint("Ejemplo delegado action 5.");
            
        }
    }
}
