using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Debuggear para validar que se crea y despues se reutiliza la instancia ya creada
            //Se crea inicial mente la instancia
            Console.WriteLine(Singleton.Intance.message);

            Singleton.Intance.message = "Se modifico msg Singleton";
            //Se reutiliza la instancia que ya se ha creado
            Console.WriteLine(Singleton.Intance.message);

            //Se muestra el resultado de la instancia
            Console.ReadLine();
        }
    }
}
