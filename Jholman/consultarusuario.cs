using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Model;
using Controller;

namespace Jholman
{
    public partial class consultarusuario : Form
    {
        public consultarusuario()
        {
            InitializeComponent();
        }

        public ClsUsuario UsuarioSeleccionado = null;   

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvConsultar.SelectedRows.Count == 1)
            {
                string usuario = Convert.ToString(dgvConsultar.CurrentRow.Cells[0].Value);
                UsuarioSeleccionado = ClsUsuarioDAL.ObtenerUsuario(usuario);

                this.Close();
            }
            else
            {
                MessageBox.Show("¡Debe de seleccionar una fila!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string consulta = txtUsuario.Text;

            if (consulta == "")
            {
                MessageBox.Show("¡Debe ingresar un usuario!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrUsuario cUsuario = new CtrUsuario();
                dgvConsultar.DataSource = cUsuario.Listar(txtUsuario.Text.Trim());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
