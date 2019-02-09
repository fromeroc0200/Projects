using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    public class DelegatePredicate
    {
        public static void DelegateExample6()
        {
            Predicate<string> CheckGreaterThan = y => y.Length > 5;
            string val = "fernangorras";
            bool result = CheckGreaterThan(val);
            string msg = result ? string.Format("El texto '{0}' es mayor a 5 caracteres.", val) : string.Format("El texto '{0}' es menor a 5 caracteres.", val);
            Console.WriteLine(string.Format("Predicate: {0}",msg));
        }
        public static void DelegateExmaple7()
        {
            Predicate<string> CheckGreaterThan5 = y => y.Length > 5;
            List<string> lstNames = new List<string>();
            lstNames.Add("Hugo");
            lstNames.Add("Fernando");
            lstNames.Add("Francisco");
            string mayorName = lstNames.Find(CheckGreaterThan5);
            Console.WriteLine(string.Format("Predicate in list: El valor {0} es mayor a 5 caracteres.",mayorName));
        }
    }
}
