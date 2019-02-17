using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Triangulo : Figura
    {
        public new string Area(decimal baseIn, decimal heigthIn)
        {
            return string.Format("El area del triangulo: {0}", baseIn * heigthIn / 2);
        }
    }
}
