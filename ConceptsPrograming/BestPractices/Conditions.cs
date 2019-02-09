using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;

namespace BestPractices
{
    public class Conditions
    {        
        public void BestValidations(School school)
        {

            WriteLine($"Para la escula {school.Name} se encontro:");
            if (school != null && school.Courses != null)
            {
                WriteLine("Validación standar. El valor es diferente de Null");
            }

            //LA VALIDACION ANTERIOR SE PUEDE SUSTITUIR POR...

            if (school?.Courses != null)
            {
                WriteLine("Validación mejorada. El valor es diferente de Null");
                WriteLine($"Asignatura: {school.Courses.Name}, Id: {school.Courses.id}");
            }
            WriteLine("------------------------------------");
        }
        

    }
}
