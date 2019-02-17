using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternSingletonConsole
{

    public class Singleton
    {
        private static Singleton _instance = null;


        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private Singleton()
        {
            _message = "Este es un ejemplo singleton";
        }

        public static Singleton CreateInstance()
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }
    
}
