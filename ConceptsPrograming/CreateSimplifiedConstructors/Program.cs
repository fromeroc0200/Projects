using System;
using CreateSimplifiedConstructors.Entities;

namespace CreateSimplifiedConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            var objSchool = new School("Grand School", 25);
            Console.WriteLine(objSchool.ToString());
            Console.ReadLine();
        }
    }
}
