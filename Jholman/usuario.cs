using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Controller;
using Entity;
using Model;
using MySql.Data.MySqlClient;

namespace Jholman
{
    public partial class usuario : Form
    {
        public usuario()
        {
            InitializeComponent();
        }
        public ClsUsuario usuarioActual { get; set; 
        }
        public ClsUsuario UsuarioSeleccionado = null;
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) ||
              string.IsNullOrWhiteSpace(txtPregunta.Text) || string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrUsuario cUsuario = new CtrUsuario();

                if (cUsuario.UsuarioRegistrado(txtUsuario.Text) == 0)
                {
                    if (txtContraseña.Text == txtVerificar.Text)
                    {
                        int resultado = cUsuario.Crear(txtNombre.Text.Trim(), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), txtPregunta.SelectedValue.ToString(), txtRespuesta.Text.Trim());

                        if (resultado > 0)
                        {
                            MessageBox.Show("¡Usuario guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvConsultar.DataSource = cUsuario.cargarUsuarioHabilitado();
                            dgvConsultar.Columns[0].HeaderText = "Codigo";
                            dgvConsultar.Columns[1].HeaderText = "Nombre";
                            dgvConsultar.Columns[2].HeaderText = "Usuario";
                            dgvConsultar.Columns[3].HeaderText = "Contraseña";
                            dgvConsultar.Columns[4].HeaderText = "Pregunta";
                            dgvConsultar.Columns[5].HeaderText = "Respuesta";
                            dgvConsultar.Columns[6].HeaderText = "Rol";

                            dgvConsultar2.DataSource = cUsuario.cargarUsuarioInhabilitado();
                            dgvConsultar2.Columns[0].HeaderText = "Codigo";
                            dgvConsultar2.Columns[1].HeaderText = "Nombre";
                            dgvConsultar2.Columns[2].HeaderText = "Usuario";
                            dgvConsultar2.Columns[3].HeaderText = "Contraseña";
                            dgvConsultar2.Columns[4].HeaderText = "Pregunta";
                            dgvConsultar2.Columns[5].HeaderText = "Respuesta";
                            dgvConsultar2.Columns[6].HeaderText = "Rol";

                            Limpiar();
                            Deshabilitar();
                        }                       
                    }
                    else
                    {
                        MessageBox.Show("¡Verifique! ¡Las contraseñas no coinciden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }   
                else
                {
                    MessageBox.Show("¡El usuario ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    Deshabilitar();
                }
            }
        }  
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            
            txtPregunta.DataSource = ClsUsuarioDAL.cargarPreguntas();
            txtPregunta.DisplayMember = "NombrePregunta";
            txtPregunta.ValueMember = "IdPregunta";
        }

        private void usuario_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            CtrUsuario cUsuario = new CtrUsuario();
            dgvConsultar.DataSource = cUsuario.cargarUsuarioHabilitado();
            dgvConsultar.Columns[0].HeaderText = "Codigo";
            dgvConsultar.Columns[1].HeaderText = "Nombre";
            dgvConsultar.Columns[2].HeaderText = "Usuario";
            dgvConsultar.Columns[3].HeaderText = "Contraseña";
            dgvConsultar.Columns[4].HeaderText = "Pregunta";
            dgvConsultar.Columns[5].HeaderText = "Respuesta";
            dgvConsultar.Columns[6].HeaderText = "Rol";

            dgvConsultar2.DataSource = cUsuario.cargarUsuarioInhabilitado();
            dgvConsultar2.Columns[0].HeaderText = "Codigo";
            dgvConsultar2.Columns[1].HeaderText = "Nombre";
            dgvConsultar2.Columns[2].HeaderText = "Usuario";
            dgvConsultar2.Columns[3].HeaderText = "Contraseña";
            dgvConsultar2.Columns[4].HeaderText = "Pregunta";
            dgvConsultar2.Columns[5].HeaderText = "Respuesta";
            dgvConsultar2.Columns[6].HeaderText = "Rol";           
        }        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text) ||
             string.IsNullOrWhiteSpace(txtPregunta.Text) || string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrUsuario cUsuario = new CtrUsuario();

                if (txtContraseña.Text == txtVerificar.Text)
                {
                    int resultado = cUsuario.Actualizar(txtNombre.Text.Trim(), txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), "1", txtRespuesta.Text.Trim());

                    if (resultado > 0)
                    {
                        MessageBox.Show("¡Usuario actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvConsultar.DataSource = cUsuario.cargarUsuarioHabilitado();
                        dgvConsultar.Columns[0].HeaderText = "Codigo";
                        dgvConsultar.Columns[1].HeaderText = "Nombre";
                        dgvConsultar.Columns[2].HeaderText = "Usuario";
                        dgvConsultar.Columns[3].HeaderText = "Contraseña";
                        dgvConsultar.Columns[4].HeaderText = "Pregunta";
                        dgvConsultar.Columns[5].HeaderText = "Respuesta";
                        dgvConsultar.Columns[6].HeaderText = "Rol";

                        dgvConsultar2.DataSource = cUsuario.cargarUsuarioInhabilitado();
                        dgvConsultar2.Columns[0].HeaderText = "Codigo";
                        dgvConsultar2.Columns[1].HeaderText = "Nombre";
                        dgvConsultar2.Columns[2].HeaderText = "Usuario";
                        dgvConsultar2.Columns[3].HeaderText = "Contraseña";
                        dgvConsultar2.Columns[4].HeaderText = "Pregunta";
                        dgvConsultar2.Columns[5].HeaderText = "Respuesta";
                        dgvConsultar2.Columns[6].HeaderText = "Rol";

                        Limpiar();
                        Deshabilitar();
                    }
                    else
                    {
                        MessageBox.Show("¡El usuario no se pudo actualizar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("¡Verifique! ¡Las contraseñas no coinciden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Habilitar usuario?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrUsuario cUsuario = new CtrUsuario();

                int resultado = cUsuario.Habilitar(txtUsuario.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Usuario habilitado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvConsultar.DataSource = cUsuario.cargarUsuarioHabilitado();
                    dgvConsultar.Columns[0].HeaderText = "Codigo";
                    dgvConsultar.Columns[1].HeaderText = "Nombre";
                    dgvConsultar.Columns[2].HeaderText = "Usuario";
                    dgvConsultar.Columns[3].HeaderText = "Contraseña";
                    dgvConsultar.Columns[4].HeaderText = "Pregunta";
                    dgvConsultar.Columns[5].HeaderText = "Respuesta";
                    dgvConsultar.Columns[6].HeaderText = "Rol";

                    dgvConsultar2.DataSource = cUsuario.cargarUsuarioInhabilitado();
                    dgvConsultar2.Columns[0].HeaderText = "Codigo";
                    dgvConsultar2.Columns[1].HeaderText = "Nombre";
                    dgvConsultar2.Columns[2].HeaderText = "Usuario";
                    dgvConsultar2.Columns[3].HeaderText = "Contraseña";
                    dgvConsultar2.Columns[4].HeaderText = "Pregunta";
                    dgvConsultar2.Columns[5].HeaderText = "Respuesta";
                    dgvConsultar2.Columns[6].HeaderText = "Rol";

                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡El usuario no se pudo habilitar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnInhabilitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Inhabilitar usuario?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrUsuario cUsuario = new CtrUsuario();

                    int resultado = cUsuario.Inhabilitar(txtUsuario.Text.Trim());

                    if (resultado > 0)
                    {
                        MessageBox.Show("¡Usuario inhabilitado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvConsultar.DataSource = cUsuario.cargarUsuarioHabilitado();
                        dgvConsultar.Columns[0].HeaderText = "Codigo";
                        dgvConsultar.Columns[1].HeaderText = "Nombre";
                        dgvConsultar.Columns[2].HeaderText = "Usuario";
                        dgvConsultar.Columns[3].HeaderText = "Contraseña";
                        dgvConsultar.Columns[4].HeaderText = "Pregunta";
                        dgvConsultar.Columns[5].HeaderText = "Respuesta";
                        dgvConsultar.Columns[6].HeaderText = "Rol";

                        dgvConsultar2.DataSource = cUsuario.cargarUsuarioInhabilitado();
                        dgvConsultar2.Columns[0].HeaderText = "Codigo";
                        dgvConsultar2.Columns[1].HeaderText = "Nombre";
                        dgvConsultar2.Columns[2].HeaderText = "Usuario";
                        dgvConsultar2.Columns[3].HeaderText = "Contraseña";
                        dgvConsultar2.Columns[4].HeaderText = "Pregunta";
                        dgvConsultar2.Columns[5].HeaderText = "Respuesta";
                        dgvConsultar2.Columns[6].HeaderText = "Rol";

                        Limpiar();
                        Deshabilitar();
                    }
                    else
                    {
                        MessageBox.Show("¡El usuario no se pudo inhabilitar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que quiere cerrar la ventana?", "Atencíón", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        } 
        private void dgvConsultar_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Text = dgvConsultar.SelectedRows[0].Cells[1].Value.ToString();
            txtUsuario.Text = dgvConsultar.SelectedRows[0].Cells[2].Value.ToString();
            txtContraseña.Text = dgvConsultar.SelectedRows[0].Cells[3].Value.ToString();
            txtPregunta.Text = dgvConsultar.SelectedRows[0].Cells[4].Value.ToString();
            txtRespuesta.Text = dgvConsultar.SelectedRows[0].Cells[5].Value.ToString();

            Habilitar2();
            btnInhabilitar.Enabled = true;
            btnHabilitar.Enabled = false;
            //txtBuscar.Text = "";  

            txtPregunta.DataSource = ClsUsuarioDAL.cargarPreguntas();
            txtPregunta.DisplayMember = "NombrePregunta";
            txtPregunta.ValueMember = "IdPregunta";
        }
        private void dgvConsultar2_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Text = dgvConsultar2.SelectedRows[0].Cells[1].Value.ToString();
            txtUsuario.Text = dgvConsultar2.SelectedRows[0].Cells[2].Value.ToString();
            txtContraseña.Text = dgvConsultar2.SelectedRows[0].Cells[3].Value.ToString();
            txtPregunta.Text = dgvConsultar2.SelectedRows[0].Cells[4].Value.ToString();
            txtRespuesta.Text = dgvConsultar2.SelectedRows[0].Cells[5].Value.ToString();

            Habilitar2();
            btnHabilitar.Enabled = true;
            btnInhabilitar.Enabled = false;
            //txtBuscar.Text = "";  

            txtPregunta.DataSource = ClsUsuarioDAL.cargarPreguntas();
            txtPregunta.DisplayMember = "NombrePregunta";
            txtPregunta.ValueMember = "IdPregunta";
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_usuarios where nombre like('" + txtBuscar.Text + "%') or usuario like('" + txtBuscar.Text + "%')";
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
            cmd.CommandText = "Select * from tb_usuarios where nombre like('" + txtBuscar2.Text + "%') or usuario like('" + txtBuscar2.Text + "%')";
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
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtVerificar.Clear();
            txtPregunta.ResetText();
            txtRespuesta.ResetText();
        }
        void Habilitar()
        {
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            txtPregunta.Enabled = true;
            txtRespuesta.Enabled = true;
            txtVerificar.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
            btnInhabilitar.Enabled = false;
            btnHabilitar.Enabled = false;
        }
        void Habilitar2()
        {
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;
            txtPregunta.Enabled = true;
            txtRespuesta.Enabled = true;
            txtVerificar.Enabled = true;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnCancelar.Enabled = true;
        }
        void Deshabilitar()
        {
            txtNombre.Enabled = false;
            txtUsuario.Enabled = false;
            txtContraseña.Enabled = false;
            txtPregunta.Enabled = false;
            txtRespuesta.Enabled = false;
            txtVerificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnInhabilitar.Enabled = false;
            btnHabilitar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = true;
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }
    }
}
