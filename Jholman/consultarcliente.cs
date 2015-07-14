using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Model;
using Controller;
using MySql.Data.MySqlClient;
using System.Data;


namespace Jholman
{
    public partial class consultarcliente : Form
    {
        public consultarcliente()
        {
            InitializeComponent();
        }

        public Clscliente ClienteSeleccionado = null;      

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvConsultar.SelectedRows.Count == 1)
            {
                int identificacion = Convert.ToInt32(dgvConsultar.CurrentRow.Cells[0].Value);
                ClienteSeleccionado = ClsClientesDAL.ObtenerCliente(identificacion);
              
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string consulta = txtIdentificacion.Text;
          
            if(consulta == "" )
            {
                MessageBox.Show("¡Debe ingresar una identificación!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            else
            {
                CtrCliente cCliente = new CtrCliente();
                dgvConsultar.DataSource = cCliente.Listar(Convert.ToInt32(txtIdentificacion.Text.Trim()));
            }      
       }     
 
        private void consultarcliente_Load(object sender, EventArgs e)
        {
            CtrCliente cCliente = new CtrCliente();
            dgvConsultar.DataSource = cCliente.cargarClientes();
        }

       
    }
}
