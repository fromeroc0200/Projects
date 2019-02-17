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
    public partial class Module2 : Form
    {
        private static Module2 _instancie = null;

        private Module2()
        {
            InitializeComponent();
        }

        public static Module2 CreateInstance()
        {
            if (_instancie == null || _instancie.IsDisposed)
                _instancie = new Module2();
            _instancie.BringToFront();
            return _instancie;
        }
    }
}
