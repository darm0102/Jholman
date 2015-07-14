using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jholman
{
    public partial class cotizacion2 : Form
    {
        public cotizacion2()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cotizacion cotizacion = new cotizacion();
            cotizacion.ShowDialog();
        }
    }
}
