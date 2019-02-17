using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuadrado cuadrado = new Cuadrado();
            Triangulo triangulo = new Triangulo();
            decimal bases = 20;
            decimal heigth = 10;
            Console.WriteLine("Motodos abtractos");
            Console.WriteLine(cuadrado.Area(bases, heigth));
            Console.WriteLine(triangulo.Area(bases, heigth));
            Console.ReadLine();
        }
    }
}
