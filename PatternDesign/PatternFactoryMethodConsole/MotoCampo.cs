using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethodConsole
{
    public class MotoCampo : iMoto
    {
        private int _ruedas;

        public MotoCampo(int ruedas)
        {
            this._ruedas = ruedas;
        }
        public string GetRuedas()
        {
            return string.Format("Se a creado moto de campo con {0} ruedas",this._ruedas);
        }
    }
}
