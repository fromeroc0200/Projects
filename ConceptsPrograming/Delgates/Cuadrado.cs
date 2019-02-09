using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delgates
{
    public class Cuadrado
    {
        public static string CalculaPerimetro(decimal lado)
        {
            return string.Format("El perimetro del Cuadrado es: {0}", lado * 4);
        }
    }
}
