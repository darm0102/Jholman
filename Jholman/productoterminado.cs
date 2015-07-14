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
    public partial class productoterminado : Form
    {
        public productoterminado()
        {
            InitializeComponent();
        }              
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            produccion prod = new produccion();
            prod.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void productoterminado_Load(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
