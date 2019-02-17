using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Cuadrado : Figura
    {
        public new string Area(decimal baseIn, decimal heigthIn)
        {
            return string.Format("El area del cuadrado es: {0}", baseIn * heigthIn);
        }


    }
}