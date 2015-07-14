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
    public partial class materia_prima : Form
    {
        public materia_prima()
        {
            InitializeComponent();
        }
        public ClsMateriasPrimas materiaActual { get; set; }    

        public ClsMateriasPrimas MateriaSeleccionada = null;   
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtStockMinimo.Text) ||
                string.IsNullOrWhiteSpace(txtStockMaximo.Text) || string.IsNullOrWhiteSpace(txtDisponibilidad.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrMateriaPrima pMateriaPrima = new CtrMateriaPrima();

                if (pMateriaPrima.MateriaRegistrada(Convert.ToString(txtNombre.Text)) == 0)
                {
                    int resultado = pMateriaPrima.Guardar(txtNombre.Text.Trim(), Convert.ToInt32(txtStockMinimo.Text.Trim()), Convert.ToInt32(txtStockMaximo.Text.Trim()), txtDisponibilidad.Text.Trim());

                    if (resultado > 0)
                    {
                        MessageBox.Show("¡Insumo guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CtrMateriaPrima cMateria = new CtrMateriaPrima();
                        dgvConsultar.DataSource = cMateria.cargarMaterias();
                        dgvConsultar.Columns[0].HeaderText = "Codigo";
                        dgvConsultar.Columns[1].HeaderText = "Nombre";
                        dgvConsultar.Columns[2].HeaderText = "Stock mínimo";
                        dgvConsultar.Columns[3].HeaderText = "Stock máximo";
                        dgvConsultar.Columns[4].HeaderText = "Existencias";
                        dgvConsultar.Columns[5].HeaderText = "Disponibilidad";  

                        Limpiar();
                        Deshabilitar();
                    }
                }
                else
                {
                    MessageBox.Show("¡El insumo ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Limpiar();
                    Deshabilitar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtStockMinimo.Text) ||
               string.IsNullOrWhiteSpace(txtStockMaximo.Text) || string.IsNullOrWhiteSpace(txtDisponibilidad.Text))
            {
                MessageBox.Show("¡Hay uno o más campos vacios!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                CtrMateriaPrima pMateriaPrima = new CtrMateriaPrima();

                int resultado = pMateriaPrima.Actualizar(txtNombre.Text.Trim(), Convert.ToInt32(txtStockMinimo.Text.Trim()), Convert.ToInt32(txtStockMaximo.Text.Trim()), txtDisponibilidad.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Insumo actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CtrMateriaPrima cMateria = new CtrMateriaPrima();
                    dgvConsultar.DataSource = cMateria.cargarMaterias();
                    dgvConsultar.Columns[0].HeaderText = "Codigo";
                    dgvConsultar.Columns[1].HeaderText = "Nombre";
                    dgvConsultar.Columns[2].HeaderText = "Stock mínimo";
                    dgvConsultar.Columns[3].HeaderText = "Stock máximo";
                    dgvConsultar.Columns[4].HeaderText = "Existencias";
                    dgvConsultar.Columns[5].HeaderText = "Disponibilidad"; 
 
                    Limpiar();
                    Deshabilitar();
                }
                else
                {
                    MessageBox.Show("¡No se pudo actualizar el insumo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar insumo?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CtrMateriaPrima pMateriaPrima = new CtrMateriaPrima();

                int resultado = pMateriaPrima.Eliminar(txtNombre.Text.Trim());

                if (resultado > 0)
                {
                    MessageBox.Show("¡Insumo eliminado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CtrMateriaPrima cMateria = new CtrMateriaPrima();
                    dgvConsultar.DataSource = cMateria.cargarMaterias();
                    dgvConsultar.Columns[0].HeaderText = "Codigo";
                    dgvConsultar.Columns[1].HeaderText = "Nombre";
                    dgvConsultar.Columns[2].HeaderText = "Stock mínimo";
                    dgvConsultar.Columns[3].HeaderText = "Stock máximo";
                    dgvConsultar.Columns[4].HeaderText = "Existencias";
                    dgvConsultar.Columns[5].HeaderText = "Disponibilidad"; 

                    Limpiar();
                    Deshabilitar();
                }                
            }
            else
            {
                MessageBox.Show("¡No se pudo eliminar el insumo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
        }
        private void materia_prima_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            CtrMateriaPrima cMateria = new CtrMateriaPrima();
            dgvConsultar.DataSource = cMateria.cargarMaterias();
            dgvConsultar.Columns[0].HeaderText = "Codigo";
            dgvConsultar.Columns[1].HeaderText = "Nombre";
            dgvConsultar.Columns[2].HeaderText = "Stock mínimo";
            dgvConsultar.Columns[3].HeaderText = "Stock máximo";
            dgvConsultar.Columns[4].HeaderText = "Existencias";
            dgvConsultar.Columns[5].HeaderText = "Disponibilidad";    
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
            txtStockMinimo.Text = dgvConsultar.SelectedRows[0].Cells[2].Value.ToString();
            txtStockMaximo.Text = dgvConsultar.SelectedRows[0].Cells[3].Value.ToString();
            txtDisponibilidad.Text = dgvConsultar.SelectedRows[0].Cells[4].Value.ToString();

            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            Habilitar();
            btnGuardar.Enabled = false;
            //txtBuscar.Text = "";    
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection conexion = BdConexion.ObtenerConexion();
            MySqlCommand cmd = conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from tb_materias_primas where codigo like('" + txtBuscar.Text + "%') or nombre like('" + txtBuscar.Text + "%')";
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
            txtStockMinimo.Clear();
            txtStockMaximo.Clear();
            txtDisponibilidad.ResetText();
        }
        void Habilitar()
        {            
            txtNombre.Enabled = true;
            txtStockMinimo.Enabled = true;
            txtStockMaximo.Enabled = true;
            txtDisponibilidad.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
        }
        void Deshabilitar()
        {
            txtNombre.Enabled = false;
            txtStockMinimo.Enabled = false;
            txtStockMaximo.Enabled = false;
            txtDisponibilidad.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = true;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void txtStockMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtStockMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }
    }
}
