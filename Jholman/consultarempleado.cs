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
    public partial class consultarempleado : Form
    {
        public consultarempleado()
        {
            InitializeComponent();
        }

        public ClsEmpleado EmpleadoSeleccionado = null;

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvConsultar.SelectedRows.Count == 1)
            {
                int identificacion = Convert.ToInt32(dgvConsultar.CurrentRow.Cells[0].Value);
                EmpleadoSeleccionado = ClsEmpleadosDAL.ObtenerEmpleado(identificacion);

                this.Close();
            }
            else
            {
                MessageBox.Show("¡Debe de seleccionar una fila!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string consulta = txtIdentificacion.Text;

            if (consulta == "")
            {
                MessageBox.Show("¡Debe ingresar una identificación!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrEmpleado cEmpleado = new CtrEmpleado();
                dgvConsultar.DataSource = cEmpleado.Listar(txtIdentificacion.Text.Trim());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}
