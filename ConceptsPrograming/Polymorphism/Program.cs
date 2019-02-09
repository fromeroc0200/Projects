using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal Base = 10;
            decimal Heigth = 10;
            Triangulo figura = new Triangulo();
            Console.WriteLine(figura.Area(Base , Heigth));
            Cuadrado figura2 = new Cuadrado();
            Console.WriteLine(figura2.Area(Base, Heigth));
            Console.ReadLine();
        }
    }
}
