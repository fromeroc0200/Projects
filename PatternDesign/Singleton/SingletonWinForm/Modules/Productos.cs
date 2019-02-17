using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingletonWinForm.Modules
{
    public partial class Productos : Form
    {
        private static Productos _instancia = null;
        public static Productos ObtenerIntancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
                _instancia = new Productos();
            _instancia.BringToFront();
            return _instancia;
        }
        private Productos()
        {
            InitializeComponent();
        }

        
    }
}
