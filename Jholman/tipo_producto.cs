using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Entity;
using Model;
using MySql.Data.MySqlClient;

namespace Jholman
{
    public partial class tipo_producto : Form
    {
        public tipo_producto()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            proveedor proveedor = new proveedor();
            proveedor.ShowDialog();
            this.Hide();
        }

        

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        //private void dgvConsultar_MouseClick(object sender, MouseEventArgs e)
        //{
        //    dgvConsultar.SelectedRows[0].Cells[0].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[1].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[2].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[3].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[4].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[5].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[6].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[7].Value.ToString();
        //    dgvConsultar.SelectedRows[0].Cells[8].Value.ToString();
        //}

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_proveedores where identificacion like('" + txtBuscar.Text + "%') or nombres like('" + txtBuscar.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
            conexion.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
