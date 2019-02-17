using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delgates
{
    public class Triangulo
    {
        public static string CalculaPerimetro(decimal lado)
        {
            return string.Format("El perimetro del triangulo es: {0}", lado * 3);
        }
    }
}
