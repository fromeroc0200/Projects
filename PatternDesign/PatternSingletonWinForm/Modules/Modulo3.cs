using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternSingletonWinForm.Modules
{
    public partial class Modulo3 : Form
    {
        public static Modulo3 _instace;
        public Modulo3()
        {
            InitializeComponent();
        }

        public static Modulo3 CreaInstancia()
        {
            if (_instace == null || _instace.IsDisposed) { _instace = new Modulo3(); }
            
            return _instace;
            
        }
    }
}
