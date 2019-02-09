using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMethod
{
    public class DelegateExpressionTree
    {
        public static void DelegateExample8()
        {
            //(20 + 10)
            BinaryExpression b1 = Expression.MakeBinary(ExpressionType.Add,
                                                    Expression.Constant(10),
                                                    Expression.Constant(20));
            //(5+3)
            BinaryExpression b2 = Expression.MakeBinary(ExpressionType.Add,
                                                        Expression.Constant(5),
                                                        Expression.Constant(3));

            //(20+10)-(5+3)
            BinaryExpression b3 = Expression.MakeBinary(ExpressionType.Subtract,
                                                        b1,
                                                        b2);

            //--this statement will create a delegate by parsing de ExpressionTree
            int result = Expression.Lambda<Func<int>>(b3).Compile()();

            Console.WriteLine(string.Format("ExpressionTree: El resultado de (20+10) - (5+3) es: {0}", result));
        }
        
    }
}
