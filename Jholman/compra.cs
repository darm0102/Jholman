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
    public partial class compra : Form
    {
        public compra()
        {
            InitializeComponent();
        }       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            usuario user = new usuario();
            user.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proveedor pro = new proveedor();
            pro.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            materia_prima mat = new materia_prima();
            mat.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Generar orden de compra?", "Atencíón", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resultado == DialogResult.Yes)
            {
               
            }
           
        }



      

    } 
}
