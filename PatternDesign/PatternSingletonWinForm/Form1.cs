using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternSingletonWinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void abrirModulo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modules.Module1 mod1 = Modules.Module1.CreateInstance();
            mod1.MdiParent = this;
            mod1.Show();
        }

        private void abrirModulo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modules.Module2 mod2 = Modules.Module2.CreateInstance();
            mod2.MdiParent = this;
            mod2.Show();
        }
    }
}
