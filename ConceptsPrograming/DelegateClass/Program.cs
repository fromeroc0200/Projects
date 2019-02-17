using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.LongRunning(Callback);
        }
        static void Callback(int i)
        {
            Console.WriteLine(i);
        }
    }

    public class MyClass
    {
        public delegate void CallBack(int i);
        public void LongRunning(CallBack obj)
        {
            
            for (int i = 0; i < 100; i++)
            {
                obj(i);
            }
        }
    }

}
