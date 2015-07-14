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
using Controller;
using Model;

namespace Jholman
{
    public partial class consultarcargo : Form
    {
        public consultarcargo()
        {
            InitializeComponent();
        }

        public ClsCargo CargoSeleccionado = null;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string consulta = txtCargo.Text;

            if (consulta == "")
            {
                MessageBox.Show("¡Debe ingresar un cargo!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrCargo cCargo = new CtrCargo();
                dgvConsultar.DataSource = cCargo.Listar(txtCargo.Text.Trim());
            }
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvConsultar.SelectedRows.Count == 1)
            {
                string nombre = Convert.ToString(dgvConsultar.CurrentRow.Cells[0].Value);
                CargoSeleccionado = ClsCargosDAL.ObtenerCargo(nombre);

                this.Close();
            }
            else
            {
                MessageBox.Show("¡Debe de seleccionar una fila!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void consultarcargo_Load(object sender, EventArgs e)
        {
            CtrCargo cCargo = new CtrCargo();
            dgvConsultar.DataSource = cCargo.cargarCargos();
        }
    }
}
