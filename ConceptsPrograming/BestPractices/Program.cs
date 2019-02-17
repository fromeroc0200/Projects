using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace BestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Consiciones");

            var courses = new Course() {id= 1, Name = "Matematicas"};

            List<School> schools = new List<School>()
            {
                new School() {id =1,Name="Francisco" },
                new School() {id =2,Name="Alfonso", Courses = courses }
            };

            Conditions conditions = new Conditions();
            schools.ForEach(school => { conditions.BestValidations(school); });
            ReadLine();
        }
    }
}
