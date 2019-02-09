using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public class Triangulo : Figura
    {
        public override string Area(decimal baseIn, decimal heightIn)
        {
            return string.Format("El area del triangulo es: {0}", baseIn* heightIn/ 2);
        }
    }
}
