using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethodConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string tipoMoto = "Campo";
            int numeroRuedas = 2;
            FabricaMoto fabricaMoto = new FabricaMoto();
            iMoto moto = fabricaMoto.CreaMoto(tipoMoto, numeroRuedas);
            Console.WriteLine(string.Format("Factory Method Result: {0}", moto.GetRuedas()));
            Console.ReadLine();
        }
    }
}
