using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternSingletonConsole
{
    public class SingletonProperty
    {
        private static SingletonProperty _instance = null;
        public string Message = string.Empty;
        private SingletonProperty()
        {
            Message = "Singleton instanciado";
        }

        public static SingletonProperty Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new SingletonProperty();
                }
                return _instance;
            }
        }

    }
}
