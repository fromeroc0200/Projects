using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethodConsole
{
    public interface iMotoFactory
    {
        iMoto CreaMoto(string tipo, int ruedas);
    }
}
