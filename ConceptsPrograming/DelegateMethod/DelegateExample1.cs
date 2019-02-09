using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    public static class DelegateExample1
    {
        private delegate void SomeMethodPointer();

        public static void DelegateExam1()
        {
            SomeMethodPointer obj = new SomeMethodPointer(SomeMethod);
            //Invocacion de metodo referenciado por medio de un delegado
            obj.Invoke();
            //Invocacion metodo directo
            SomeMethod();
            
        }
        private static void SomeMethod()
        {
            Console.WriteLine("Delegado Metodo Ejemplo 1.");
        }
    }
}
