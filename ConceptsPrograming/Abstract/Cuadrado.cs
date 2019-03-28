using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public class Cuadrado : Figura
    {
        public override string Area(decimal baseIn, decimal heightIn)
        {
            return Message(string.Format("El area del cuadrado es: {0}", baseIn * heightIn));
        }

        
    }
}
