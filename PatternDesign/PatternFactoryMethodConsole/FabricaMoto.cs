using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethodConsole
{
    public class FabricaMoto : iMotoFactory
    {
        public iMoto CreaMoto(string tipo, int ruedas)
        {
            switch (tipo)
            {
                case "Acuatica":
                    return new MotoAcuatica(ruedas);
                case "Campo":
                    return new MotoCampo(ruedas);
                default:
                    return null;
            }
        }
    }
}
