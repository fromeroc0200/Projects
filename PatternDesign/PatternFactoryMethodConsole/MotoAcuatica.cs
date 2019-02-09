using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethodConsole
{
    public class MotoAcuatica : iMoto
    {
        private int _ruedas;

        public MotoAcuatica(int ruedas)
        {
            this._ruedas = ruedas;
        }
        public string GetRuedas()
        {
            return string.Format("Se a creado moto de acuatica con {0} ruedas", this._ruedas);
        }
    }
}
