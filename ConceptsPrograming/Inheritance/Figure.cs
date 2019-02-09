using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Figure
    {
        public double Base { get; set; }
        public double Height { get; set; }
        
        public double Area()
        {
            return Base * Height;
        }
    }
}
