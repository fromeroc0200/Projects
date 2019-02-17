using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public abstract class Figura
    {
        protected decimal x;
        protected decimal y;

        public abstract string Area(decimal baseIn, decimal heightIn);
        
    }
}
