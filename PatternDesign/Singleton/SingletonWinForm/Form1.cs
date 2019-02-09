using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingletonWinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Singleton se encarga de utilizar una instancia unica para una clase
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agergarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //-- Creamos la instancia del formulario y si ya fue creada,
            //-- utiliza la misma para no mostrar nuevas ventanas
            Modules.Productos prodForm = Modules.Productos.ObtenerIntancia();
            prodForm.MdiParent = this;  
            prodForm.Show();
        }

        private void agergarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modules.Usuarios userForm = Modules.Usuarios.ObtenerIntancia();
            userForm.MdiParent = this;
            userForm.Show();
        }
    }
}
