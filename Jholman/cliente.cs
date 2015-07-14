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
    public partial class cliente : Form
    {
        public cliente()
        {
            InitializeComponent();
        }
        public Clscliente clienteActual { get; set; }

        public Clscliente ClienteSeleccionado = null;         
          
        private void cliente_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            CtrCliente pCliente = new CtrCliente();
            dgvConsultar.DataSource = pCliente.cargarClienteHabilitado();
            dgvConsultar.Columns[0].HeaderText = "Tipo documento";
            dgvConsultar.Columns[1].HeaderText = "Número documento";
            dgvConsultar.Columns[2].HeaderText = "Nombres";
            dgvConsultar.Columns[3].HeaderText = "Apellidos";
            dgvConsultar.Columns[4].HeaderText = "Género";
            dgvConsultar.Columns[5].HeaderText = "Dirección";
            dgvConsultar.Columns[6].HeaderText = "Teléfono fijo";
            dgvConsultar.Columns[7].HeaderText = "Teléfono celular";
            dgvConsultar.Columns[8].HeaderText = "Nombre empresa";

            dgvConsultar2.DataSource = pCliente.cargarClienteInhabilitado();
            dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
            dgvConsultar2.Columns[1].HeaderText = "Número documento";
            dgvConsultar2.Columns[2].HeaderText = "Nombres";
            dgvConsultar2.Columns[3].HeaderText = "Apellidos";
            dgvConsultar2.Columns[4].HeaderText = "Género";
            dgvConsultar2.Columns[5].HeaderText = "Dirección";
            dgvConsultar2.Columns[6].HeaderText = "Teléfono fijo";
            dgvConsultar2.Columns[7].HeaderText = "Teléfono celular";
            dgvConsultar2.Columns[8].HeaderText = "Nombre empresa";

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoDocumento.Text) ||string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtNombres.Text) ||
              string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(cbxSexo.Text) ||
              string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) ||
              string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrCliente cCliente = new CtrCliente();

                if (cCliente.ClienteRegistrado(Convert.ToInt32(txtIdentificacion.Text)) == 0)
                {
                    int resultado = cCliente.Guardar(txtTipoDocumento.Text.Trim(), txtIdentificacion.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), cbxSexo.Text.Trim(),
                    txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtNombreEmpresa.Text.Trim());

                    if(resultado > 0)                    
                    {
                        MessageBox.Show("¡Cliente guardado correctamente!", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CtrCliente pCliente = new CtrCliente();
                        dgvConsultar.DataSource = pCliente.cargarClienteHabilitado();
                        dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                        dgvConsultar.Columns[1].HeaderText = "Número documento";
                        dgvConsultar.Columns[2].HeaderText = "Nombres";
                        dgvConsultar.Columns[3].HeaderText = "Apellidos";
                        dgvConsultar.Columns[4].HeaderText = "Género";
                        dgvConsultar.Columns[5].HeaderText = "Dirección";
                        dgvConsultar.Columns[6].HeaderText = "Teléfono fijo";
                        dgvConsultar.Columns[7].HeaderText = "Teléfono celular";
                        dgvConsultar.Columns[8].HeaderText = "Nombre empresa";

                        dgvConsultar2.DataSource = pCliente.cargarClienteInhabilitado();
                        dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                        dgvConsultar2.Columns[1].HeaderText = "Número documento";
                        dgvConsultar2.Columns[2].HeaderText = "Nombres";
                        dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                        dgvConsultar2.Columns[4].HeaderText = "Género";
                        dgvConsultar2.Columns[5].HeaderText = "Dirección";
                        dgvConsultar2.Columns[6].HeaderText = "Teléfono fijo";
                        dgvConsultar2.Columns[7].HeaderText = "Teléfono celular";
                        dgvConsultar2.Columns[8].HeaderText = "Nombre empresa";

                        Limpiar();
                        Deshabilitar();
                    }                   
                }
                else
                {
                    MessageBox.Show("¡El cliente ya existe!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    Deshabilitar();
                }
            }
        }        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que quiere cerrar la ventana?", "Atencíón", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }      

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoDocumento.Text) || string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtNombres.Text) ||
              string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(cbxSexo.Text) ||
              string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) ||
              string.IsNullOrWhiteSpace(txtCelular.Text) || string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {                
                CtrCliente cCliente = new CtrCliente();
                
                
                int resultado = cCliente.Actualizar(txtTipoDocumento.Text.Trim(), txtIdentificacion.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), cbxSexo.Text.Trim(),
                txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtNombreEmpresa.Text.Trim());
                
                if (resultado > 0)
                {
                    MessageBox.Show("¡Cliente actualizado correctamente!", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CtrCliente pCliente = new CtrCliente();
                    dgvConsultar.DataSource = pCliente.cargarClienteHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar.Columns[1].HeaderText = "Número documento";
                    dgvConsultar.Columns[2].HeaderText = "Nombres";
                    dgvConsultar.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar.Columns[4].HeaderText = "Género";
                    dgvConsultar.Columns[5].HeaderText = "Dirección";
                    dgvConsultar.Columns[6].HeaderText = "Teléfono fijo";
                    dgvConsultar.Columns[7].HeaderText = "Teléfono celular";
                    dgvConsultar.Columns[8].HeaderText = "Nombre empresa";

                    dgvConsultar2.DataSource = pCliente.cargarClienteInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar2.Columns[1].HeaderText = "Número documento";
                    dgvConsultar2.Columns[2].HeaderText = "Nombres";
                    dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar2.Columns[4].HeaderText = "Género";
                    dgvConsultar2.Columns[5].HeaderText = "Dirección";
                    dgvConsultar2.Columns[6].HeaderText = "Teléfono fijo";
                    dgvConsultar2.Columns[7].HeaderText = "Teléfono celular";
                    dgvConsultar2.Columns[8].HeaderText = "Nombre empresa";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡No se pudo actualizar el cliente!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Habilitar cliente?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrCliente cCliente = new CtrCliente();

                int resultado = cCliente.Habilitar(txtIdentificacion.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Cliente habilitado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CtrCliente pCliente = new CtrCliente();
                    dgvConsultar.DataSource = pCliente.cargarClienteHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar.Columns[1].HeaderText = "Número documento";
                    dgvConsultar.Columns[2].HeaderText = "Nombres";
                    dgvConsultar.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar.Columns[4].HeaderText = "Género";
                    dgvConsultar.Columns[5].HeaderText = "Dirección";
                    dgvConsultar.Columns[6].HeaderText = "Teléfono fijo";
                    dgvConsultar.Columns[7].HeaderText = "Teléfono celular";
                    dgvConsultar.Columns[8].HeaderText = "Nombre empresa";

                    dgvConsultar2.DataSource = pCliente.cargarClienteInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar2.Columns[1].HeaderText = "Número documento";
                    dgvConsultar2.Columns[2].HeaderText = "Nombres";
                    dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar2.Columns[4].HeaderText = "Género";
                    dgvConsultar2.Columns[5].HeaderText = "Dirección";
                    dgvConsultar2.Columns[6].HeaderText = "Teléfono fijo";
                    dgvConsultar2.Columns[7].HeaderText = "Teléfono celular";
                    dgvConsultar2.Columns[8].HeaderText = "Nombre empresa";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡El cliente no se pudo habilitar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnInhabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Inhabilitar cliente?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrCliente cCliente = new CtrCliente();

                int resultado = cCliente.Inhabilitar(txtIdentificacion.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Cliente inhabilitado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CtrCliente pCliente = new CtrCliente();
                    dgvConsultar.DataSource = pCliente.cargarClienteHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar.Columns[1].HeaderText = "Número documento";
                    dgvConsultar.Columns[2].HeaderText = "Nombres";
                    dgvConsultar.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar.Columns[4].HeaderText = "Género";
                    dgvConsultar.Columns[5].HeaderText = "Dirección";
                    dgvConsultar.Columns[6].HeaderText = "Teléfono fijo";
                    dgvConsultar.Columns[7].HeaderText = "Teléfono celular";
                    dgvConsultar.Columns[8].HeaderText = "Nombre empresa";

                    dgvConsultar2.DataSource = pCliente.cargarClienteInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar2.Columns[1].HeaderText = "Número documento";
                    dgvConsultar2.Columns[2].HeaderText = "Nombres";
                    dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar2.Columns[4].HeaderText = "Género";
                    dgvConsultar2.Columns[5].HeaderText = "Dirección";
                    dgvConsultar2.Columns[6].HeaderText = "Teléfono fijo";
                    dgvConsultar2.Columns[7].HeaderText = "Teléfono celular";
                    dgvConsultar2.Columns[8].HeaderText = "Nombre empresa";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡El cliente no se pudo inhabilitar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private void dgvConsultar_MouseClick(object sender, MouseEventArgs e)
        {
            txtTipoDocumento.Text = dgvConsultar.SelectedRows[0].Cells[0].Value.ToString();
            txtIdentificacion.Text = dgvConsultar.SelectedRows[0].Cells[1].Value.ToString();
            txtNombres.Text = dgvConsultar.SelectedRows[0].Cells[2].Value.ToString();
            txtApellidos.Text = dgvConsultar.SelectedRows[0].Cells[3].Value.ToString();
            cbxSexo.Text = dgvConsultar.SelectedRows[0].Cells[4].Value.ToString();
            txtDireccion.Text = dgvConsultar.SelectedRows[0].Cells[5].Value.ToString();
            txtTelefono.Text = dgvConsultar.SelectedRows[0].Cells[6].Value.ToString();
            txtCelular.Text = dgvConsultar.SelectedRows[0].Cells[7].Value.ToString();
            txtNombreEmpresa.Text = dgvConsultar.SelectedRows[0].Cells[8].Value.ToString();

            Habilitar2();
            btnInhabilitar.Enabled = true;
            btnHabilitar.Enabled = false;
            //txtBuscar.Text = "";
        }
        private void dgvConsultar2_MouseClick(object sender, MouseEventArgs e)
        {
            txtTipoDocumento.Text = dgvConsultar2.SelectedRows[0].Cells[0].Value.ToString();
            txtIdentificacion.Text = dgvConsultar2.SelectedRows[0].Cells[1].Value.ToString();
            txtNombres.Text = dgvConsultar2.SelectedRows[0].Cells[2].Value.ToString();
            txtApellidos.Text = dgvConsultar2.SelectedRows[0].Cells[3].Value.ToString();
            cbxSexo.Text = dgvConsultar2.SelectedRows[0].Cells[4].Value.ToString();
            txtDireccion.Text = dgvConsultar2.SelectedRows[0].Cells[5].Value.ToString();
            txtTelefono.Text = dgvConsultar2.SelectedRows[0].Cells[6].Value.ToString();
            txtCelular.Text = dgvConsultar2.SelectedRows[0].Cells[7].Value.ToString();
            txtNombreEmpresa.Text = dgvConsultar2.SelectedRows[0].Cells[8].Value.ToString();

            Habilitar2();
            btnInhabilitar.Enabled = false;
            btnHabilitar.Enabled = true;
            //txtBuscar2.Text = "";
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_clientes where identificacion like('" + txtBuscar.Text + "%') or nombres like('" + txtBuscar.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
            conexion.Close();

            Deshabilitar();
            Limpiar();
        }
        private void txtBuscar2_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_clientes where identificacion like('" + txtBuscar2.Text + "%') or nombres like('" + txtBuscar2.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
            conexion.Close();

            Deshabilitar();
            Limpiar();
        }
        void Limpiar()
        {
            txtTipoDocumento.ResetText();
            txtIdentificacion.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            cbxSexo.ResetText();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtNombreEmpresa.Clear();
        }

        void Habilitar()
        {
            txtTipoDocumento.Enabled = true;
            txtIdentificacion.Enabled = true;
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            cbxSexo.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtCelular.Enabled = true;
            txtNombreEmpresa.Enabled = true;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
        }
        void Habilitar2()
        {
            txtTipoDocumento.Enabled = true;
            txtIdentificacion.Enabled = true;
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            cbxSexo.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtCelular.Enabled = true;
            txtNombreEmpresa.Enabled = true;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        void Deshabilitar()
        {
            txtTipoDocumento.Enabled = false;
            txtIdentificacion.Enabled = false;
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            cbxSexo.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtCelular.Enabled = false;
            txtNombreEmpresa.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnHabilitar.Enabled = false;
            btnInhabilitar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
        }            

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtNombreEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

       


       

   
    }
}
