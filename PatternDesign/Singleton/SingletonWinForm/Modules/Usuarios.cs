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
    public partial class Usuarios : Form
    {
        private static Usuarios _instancia = null;

        public static Usuarios ObtenerIntancia()
        {
            if (_instancia == null || _instancia.IsDisposed)
                _instancia = new Usuarios();
            _instancia.BringToFront();
            return _instancia;
        }

        public Usuarios()
        {
            InitializeComponent();
        }
    }
}
