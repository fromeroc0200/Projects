using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delgates
{
    public delegate string delFunction(decimal val);
    class Program
    {
        static void Main(string[] args)
        {
            string msg = string.Empty;
            delFunction deleg = new delFunction(Triangulo.CalculaPerimetro);

            Console.WriteLine(deleg(10));

            deleg = new delFunction(Cuadrado.CalculaPerimetro);

            Console.WriteLine(deleg(10));
            Console.ReadLine();

        }
    }
}
