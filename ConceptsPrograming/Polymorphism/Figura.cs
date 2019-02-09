using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Figura
    {
        public string Area(decimal baseIn, decimal heigthIn)
        {
            return string.Format("El area de la figura general es: {0}", baseIn * heigthIn);
        }
    }
}
