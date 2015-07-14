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
    public partial class proveedor2 : Form
    {
        public proveedor2()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
        }

        private void proveedor2_Load(object sender, EventArgs e)
        {
            Deshabilitar();            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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
                CtrProveedor Proveedor = new CtrProveedor();

                if (Proveedor.ProveedorRegistrado(Convert.ToInt32(txtIdentificacion.Text)) == 0)
                {
                    int resultado = Proveedor.Guardar(txtTipoDocumento.Text.Trim(), Convert.ToInt32(txtIdentificacion.Text.Trim()), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), cbxSexo.Text.Trim(),
                    txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtNombreEmpresa.Text.Trim());

                    if (resultado > 0)
                    {
                        MessageBox.Show("¡Proveedor guardado correctamente!", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tipo_producto proveedor = new tipo_producto();
                        proveedor.Show();

                        Limpiar();
                        Deshabilitar();
                    }
                }
                else
                {
                    MessageBox.Show("¡El proveedor ya existe!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    Deshabilitar();
                }
            }
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
                CtrProveedor Proveedor = new CtrProveedor();


                int resultado = Proveedor.Actualizar(txtTipoDocumento.Text.Trim(), Convert.ToInt32(txtIdentificacion.Text.Trim()), txtNombres.Text.Trim(), txtApellidos.Text.Trim(), cbxSexo.Text.Trim(),
                txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtCelular.Text.Trim(), txtNombreEmpresa.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Proveedor actualizado correctamente!", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tipo_producto proveedor = new tipo_producto();
                    proveedor.Show();
                    this.Hide();
                    
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡No se pudo actualizar el proveedor!", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar proveedor?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrProveedor Proveedor = new CtrProveedor();

                int resultado = Proveedor.Eliminar(Convert.ToInt32(txtIdentificacion.Text.Trim()));

                if (resultado > 0)
                {
                    MessageBox.Show("¡Proveedor eliminado correctamente!", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tipo_producto proveedor = new tipo_producto();
                    proveedor.Show();
                    this.Hide();

                    Limpiar();
                    Deshabilitar();
                }
            }
            else
            {
                MessageBox.Show("¡No se pudo eliminar el proveedor!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
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

        private void txtNombreEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            materia_prima materia = new materia_prima();
            materia.ShowDialog();
        }
    }
}
