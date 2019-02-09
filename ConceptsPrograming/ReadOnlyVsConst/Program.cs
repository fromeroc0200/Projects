using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyVsConst
{
    public class Program
    {
        //--La const no puede ser modificada y necesita inicializarse su valor

        const int valorNum = 10;
        readonly string text;
        readonly static string stText;
        //public Program()
        //{
        //    //--Read only solo puede ser modificado en la incializacion de un constructor
        //    text = "Solo lectura modificado";
            
        //}

        static Program()
        {
            stText = "Static ReadOnly";
        }
        static void Main(string[] args)
        {
            Program r = new Program();
            string newText = r.text;
            int newValNum = valorNum;
            Console.Write($"ReadOnly value: {newText}, Const: {newValNum}");
            string m = string.Empty;
            Console.ReadLine();
        }
    }
}
