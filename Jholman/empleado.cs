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
    public partial class empleado : Form
    {
        public empleado()
        {
            InitializeComponent();
        }

        public ClsEmpleado EmpleadoSeleccionado = null;
        public ClsEmpleado empleadoActual { get; set; }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();

            txtCargo.DataSource = ClsEmpleadosDAL.cargarCargos();
            txtCargo.DisplayMember = "NombreCargo";
            txtCargo.ValueMember = "IdCargo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoDocumento.Text) || string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(cbxSexo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrEmpleado cEmpleado = new CtrEmpleado();

                if (cEmpleado.EmpleadoRegistrado(Convert.ToInt32(txtIdentificacion.Text)) == 0)
                {
                    int resultado = cEmpleado.Guardar(txtTipoDocumento.Text.Trim(), txtIdentificacion.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), cbxSexo.Text.Trim(),
                    txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtCargo.SelectedValue.ToString());

                    if (resultado > 0)
                    {
                        MessageBox.Show("¡Empleado guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvConsultar.DataSource = cEmpleado.cargarEmpleadoHabilitado();
                        dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                        dgvConsultar.Columns[1].HeaderText = "Número documento";
                        dgvConsultar.Columns[2].HeaderText = "Nombres";
                        dgvConsultar.Columns[3].HeaderText = "Apellidos";
                        dgvConsultar.Columns[4].HeaderText = "Género";
                        dgvConsultar.Columns[5].HeaderText = "Teléfono fijo";
                        dgvConsultar.Columns[6].HeaderText = "Teléfono celular";
                        dgvConsultar.Columns[7].HeaderText = "Cargo";

                        dgvConsultar2.DataSource = cEmpleado.cargarEmpleadoInhabilitado();
                        dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                        dgvConsultar2.Columns[1].HeaderText = "Número documento";
                        dgvConsultar2.Columns[2].HeaderText = "Nombres";
                        dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                        dgvConsultar2.Columns[4].HeaderText = "Género";
                        dgvConsultar2.Columns[5].HeaderText = "Teléfono fijo";
                        dgvConsultar2.Columns[6].HeaderText = "Teléfono celular";
                        dgvConsultar2.Columns[7].HeaderText = "Cargo";

                        Limpiar();
                        Deshabilitar();
                    }
                }
                else
                {
                    MessageBox.Show("¡El empleado ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    Deshabilitar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoDocumento.Text) || string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(cbxSexo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrEmpleado cEmpleado = new CtrEmpleado();

                int resultado = cEmpleado.Actualizar(txtTipoDocumento.Text.Trim(), txtIdentificacion.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), cbxSexo.Text.Trim(),
                txtTelefono.Text.Trim(), txtCelular.Text.Trim(),txtCargo.SelectedValue.ToString());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Empleado actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvConsultar.DataSource = cEmpleado.cargarEmpleadoHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar.Columns[1].HeaderText = "Número documento";
                    dgvConsultar.Columns[2].HeaderText = "Nombres";
                    dgvConsultar.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar.Columns[4].HeaderText = "Género";
                    dgvConsultar.Columns[5].HeaderText = "Teléfono fijo";
                    dgvConsultar.Columns[6].HeaderText = "Teléfono celular";
                    dgvConsultar.Columns[7].HeaderText = "Cargo";

                    dgvConsultar2.DataSource = cEmpleado.cargarEmpleadoInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar2.Columns[1].HeaderText = "Número documento";
                    dgvConsultar2.Columns[2].HeaderText = "Nombres";
                    dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar2.Columns[4].HeaderText = "Género";
                    dgvConsultar2.Columns[5].HeaderText = "Teléfono fijo";
                    dgvConsultar2.Columns[6].HeaderText = "Teléfono celular";
                    dgvConsultar2.Columns[7].HeaderText = "Cargo";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡No se pudo actualizar el empleado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Habilitar empleado?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrEmpleado cEmpleado = new CtrEmpleado();

                int resultado = cEmpleado.Habilitar(txtIdentificacion.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Empleado habilitado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvConsultar.DataSource = cEmpleado.cargarEmpleadoHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar.Columns[1].HeaderText = "Número documento";
                    dgvConsultar.Columns[2].HeaderText = "Nombres";
                    dgvConsultar.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar.Columns[4].HeaderText = "Género";
                    dgvConsultar.Columns[5].HeaderText = "Teléfono fijo";
                    dgvConsultar.Columns[6].HeaderText = "Teléfono celular";
                    dgvConsultar.Columns[7].HeaderText = "Cargo";

                    dgvConsultar2.DataSource = cEmpleado.cargarEmpleadoInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar2.Columns[1].HeaderText = "Número documento";
                    dgvConsultar2.Columns[2].HeaderText = "Nombres";
                    dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar2.Columns[4].HeaderText = "Género";
                    dgvConsultar2.Columns[5].HeaderText = "Teléfono fijo";
                    dgvConsultar2.Columns[6].HeaderText = "Teléfono celular";
                    dgvConsultar2.Columns[7].HeaderText = "Cargo";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡El empleado no se pudo habilitar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnInhabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Inhabilitar empleado?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrEmpleado cEmpleado = new CtrEmpleado();

                int resultado = cEmpleado.Inhabilitar(txtIdentificacion.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Empleado inhabilitado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvConsultar.DataSource = cEmpleado.cargarEmpleadoHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar.Columns[1].HeaderText = "Número documento";
                    dgvConsultar.Columns[2].HeaderText = "Nombres";
                    dgvConsultar.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar.Columns[4].HeaderText = "Género";
                    dgvConsultar.Columns[5].HeaderText = "Teléfono fijo";
                    dgvConsultar.Columns[6].HeaderText = "Teléfono celular";
                    dgvConsultar.Columns[7].HeaderText = "Cargo";

                    dgvConsultar2.DataSource = cEmpleado.cargarEmpleadoInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
                    dgvConsultar2.Columns[1].HeaderText = "Número documento";
                    dgvConsultar2.Columns[2].HeaderText = "Nombres";
                    dgvConsultar2.Columns[3].HeaderText = "Apellidos";
                    dgvConsultar2.Columns[4].HeaderText = "Género";
                    dgvConsultar2.Columns[5].HeaderText = "Teléfono fijo";
                    dgvConsultar2.Columns[6].HeaderText = "Teléfono celular";
                    dgvConsultar2.Columns[7].HeaderText = "Cargo";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡El empleado no se pudo inhabilitar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void empleado_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            CtrEmpleado cEmpleado = new CtrEmpleado();
            dgvConsultar.DataSource = cEmpleado.cargarEmpleadoHabilitado();
            dgvConsultar.Columns[0].HeaderText = "Tipo documento";
            dgvConsultar.Columns[1].HeaderText = "Número documento";
            dgvConsultar.Columns[2].HeaderText = "Nombres";
            dgvConsultar.Columns[3].HeaderText = "Apellidos";
            dgvConsultar.Columns[4].HeaderText = "Género";
            dgvConsultar.Columns[5].HeaderText = "Teléfono fijo";
            dgvConsultar.Columns[6].HeaderText = "Teléfono celular";
            dgvConsultar.Columns[7].HeaderText = "Cargo";

            dgvConsultar2.DataSource = cEmpleado.cargarEmpleadoInhabilitado();
            dgvConsultar2.Columns[0].HeaderText = "Tipo documento";
            dgvConsultar2.Columns[1].HeaderText = "Número documento";
            dgvConsultar2.Columns[2].HeaderText = "Nombres";
            dgvConsultar2.Columns[3].HeaderText = "Apellidos";
            dgvConsultar2.Columns[4].HeaderText = "Género";
            dgvConsultar2.Columns[5].HeaderText = "Teléfono fijo";
            dgvConsultar2.Columns[6].HeaderText = "Teléfono celular";
            dgvConsultar2.Columns[7].HeaderText = "Cargo";         
        }            
        private void dgvConsultar_MouseClick(object sender, MouseEventArgs e)
        {
            txtTipoDocumento.Text = dgvConsultar.SelectedRows[0].Cells[0].Value.ToString();
            txtIdentificacion.Text = dgvConsultar.SelectedRows[0].Cells[1].Value.ToString();
            txtNombres.Text = dgvConsultar.SelectedRows[0].Cells[2].Value.ToString();
            txtApellidos.Text = dgvConsultar.SelectedRows[0].Cells[3].Value.ToString();
            cbxSexo.Text = dgvConsultar.SelectedRows[0].Cells[4].Value.ToString();
            txtTelefono.Text = dgvConsultar.SelectedRows[0].Cells[5].Value.ToString();
            txtCelular.Text = dgvConsultar.SelectedRows[0].Cells[6].Value.ToString();
            txtCargo.Text = dgvConsultar.SelectedRows[0].Cells[7].Value.ToString();

            Habilitar2();
            btnInhabilitar.Enabled = true;
            btnHabilitar.Enabled = false;
            //txtBuscar.Text = "";

            txtCargo.DataSource = ClsEmpleadosDAL.cargarCargos();
            txtCargo.DisplayMember = "NombreCargo";
            txtCargo.ValueMember = "IdCargo";
        }
        private void dgvConsultar2_MouseClick(object sender, MouseEventArgs e)
        {
            txtTipoDocumento.Text = dgvConsultar2.SelectedRows[0].Cells[0].Value.ToString();
            txtIdentificacion.Text = dgvConsultar2.SelectedRows[0].Cells[1].Value.ToString();
            txtNombres.Text = dgvConsultar2.SelectedRows[0].Cells[2].Value.ToString();
            txtApellidos.Text = dgvConsultar2.SelectedRows[0].Cells[3].Value.ToString();
            cbxSexo.Text = dgvConsultar2.SelectedRows[0].Cells[4].Value.ToString();
            txtTelefono.Text = dgvConsultar2.SelectedRows[0].Cells[5].Value.ToString();
            txtCelular.Text = dgvConsultar2.SelectedRows[0].Cells[6].Value.ToString();
            txtCargo.Text = dgvConsultar2.SelectedRows[0].Cells[7].Value.ToString();

            Habilitar2();
            btnInhabilitar.Enabled = false;
            btnHabilitar.Enabled = true;
            //txtBuscar2.Text = "";

            txtCargo.DataSource = ClsEmpleadosDAL.cargarCargos();
            txtCargo.DisplayMember = "NombreCargo";
            txtCargo.ValueMember = "IdCargo";
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_empleados where identificacion like('" + txtBuscar.Text + "%') or nombres like('" + txtBuscar.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
            conexion.Close();

            Limpiar();
            Deshabilitar();
        }
        private void txtBuscar2_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_empleados where identificacion like('" + txtBuscar2.Text + "%') or nombres like('" + txtBuscar2.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dgvConsultar.DataSource = dt;
            conexion.Close();

            Limpiar();
            Deshabilitar();
        }
        void Limpiar()
        {
            txtTipoDocumento.ResetText();
            txtIdentificacion.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            cbxSexo.ResetText();
            txtTelefono.Clear();
            txtCelular.Clear();
            txtCargo.ResetText();
        }        
        void Habilitar()
        {
            txtTipoDocumento.Enabled = true;
            txtIdentificacion.Enabled = true;
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            cbxSexo.Enabled = true;
            txtTelefono.Enabled = true;
            txtCelular.Enabled = true;
            txtCargo.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        void Habilitar2()
        {
            txtTipoDocumento.Enabled = true;
            txtIdentificacion.Enabled = true;
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            cbxSexo.Enabled = true;
            txtTelefono.Enabled = true;
            txtCelular.Enabled = true;
            txtCargo.Enabled = true;
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
            txtTelefono.Enabled = false;
            txtCelular.Enabled = false;
            txtCargo.Enabled = false;
            btnGuardar.Enabled = false;
            btnHabilitar.Enabled = false;
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = true;
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

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            cargos cargo = new cargos();
            cargo.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }          
    }
}
