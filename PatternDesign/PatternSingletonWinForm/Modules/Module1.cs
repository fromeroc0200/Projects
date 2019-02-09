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
    public partial class Module1 : Form
    {
        public Module1()
        {
            InitializeComponent();
        }

        private static Module1 _instancie = null;

        public static Module1 CreateInstance()
        {
            if (_instancie == null || _instancie.IsDisposed)
                _instancie = new Module1();
            _instancie.BringToFront();
            return _instancie;
        }
    }
}
