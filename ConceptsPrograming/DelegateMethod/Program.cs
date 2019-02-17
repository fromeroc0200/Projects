using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    class Program
    {
        /// <summary>
        /// Delegate is a pointer to a function
        /// </summary>
        public delegate void SomeMethodPointer();
        static void Main(string[] args)
        {
            DelegateExample1.DelegateExam1();
            DelegateExample2.DelegateExam2();
            DelegateLambda.DelegateExam3();
            DelegateFuncLambda.DelegateExample4();
            DelegateActions.DelegateExample5();
            DelegatePredicate.DelegateExample6();
            DelegatePredicate.DelegateExmaple7();
            //ExpressionTree not is delegate but in this example used a delegate
            DelegateExpressionTree.DelegateExample8();
            Console.ReadLine();
        }
        
    }
}
