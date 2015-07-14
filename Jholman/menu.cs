using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Jholman
{
    public partial class menu : Form
    {
        //private int childFormNumber = 0;

        public menu()
        {
            
            InitializeComponent();
        
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            //childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        
        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }                    

        //private void btnCliente_Click(object sender, EventArgs e)
        //{
        //    splitContainer1.Panel2.Controls.Clear();
        //    cliente cli = new cliente();
        //    cli.MdiParent = this;
        //    splitContainer1.Panel2.Controls.Add(cli);
        //    //cli.Dock = DockStyle.Fill;
        //    cli.Show();
        //}     
        
        cliente cliente;
        private void btnCliente_Click(object sender, EventArgs e)
        {                    
            if (!this.MdiChildren.Contains(cliente))
            {
                cliente = new cliente();
                cliente.MdiParent = this;
                cliente.Show();
            }                      
           else
            {
                cliente.Activate();
            }             
        }

        private void menu_Load(object sender, EventArgs e)
        {
            SetBackGroundColorOfMDIForm();           
        }

        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = System.Drawing.Color.White;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusHora.Text = DateTime.Now.ToString("HH:mm:ss") + " |";
            status.Text = DateTime.Now.ToString("dd/MM/yyyy");           
        }

        usuario usuario;
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(usuario))
            {                
                usuario = new usuario();
                usuario.MdiParent = this;
                usuario.Show();
            }
            else
            {
                usuario.Activate();
            }         
        }   

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro que desea salir?", "Atencíón", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        empleado empleado;
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(empleado))
            {
                empleado = new empleado();
                empleado.MdiParent = this;
                empleado.Show();
            }
            else
            {
                materia.Activate();
            }         
        }

        materia_prima materia;
        private void btnMateria_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(materia))
            {
                materia = new materia_prima();
                materia.MdiParent = this;
                materia.Show();
            }
            else
            {
                materia.Activate();
            }             
        }

        pedido pedido;
        private void btnPedido_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(pedido))
            {
                pedido = new pedido();
                pedido.MdiParent = this;
                pedido.Show();
            }
            else
            {
                pedido.Activate();
            }        
        }

        compra compra;
        private void btnCompra_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(compra))
            {
                compra = new compra();
                compra.MdiParent = this;
                compra.Show();
            }
            else
            {
                compra.Activate();
            }        
        }

        produccion produccion;
        private void btnProduccion_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(produccion))
            {
                produccion = new produccion();
                produccion.MdiParent = this;
                produccion.Show();
            }
            else
            {
                produccion.Activate();
            }        
        }

        productoterminado terminado;
        private void btnTerminado_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(terminado))
            {
                terminado = new productoterminado();
                terminado.MdiParent = this;
                terminado.Show();
            }
            else
            {
                terminado.Activate();
            }       
        }

        proveedor proveedor2;
        private void btnProveedor_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(proveedor2))
            {
                proveedor2 = new proveedor();
                proveedor2.MdiParent = this;
                proveedor2.Show();
            }
            else
            {
                proveedor2.Activate();
            }       
        }

        cotizacion2 cotizacion2;
        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(cotizacion2))
            {
                cotizacion2 = new cotizacion2();
                cotizacion2.MdiParent = this;
                cotizacion2.Show();
            }
            else
            {
                cotizacion2.Activate();
            }       
        }

        //private void btnCliente_MouseLeave(object sender, EventArgs e)
        //{
        //    btnCliente.Width = 63;
        //    btnCliente.Height = 62;
        //}

        //private void btnCliente_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnCliente.Width = 100;
        //    btnCliente.Height = 70;
        //}

        //private void btnCotizacion_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnCotizacion.Width = 100;
        //    btnCotizacion.Height = 70;
        //}

        //private void btnCotizacion_MouseLeave(object sender, EventArgs e)
        //{
        //    btnCotizacion.Width = 63;
        //    btnCotizacion.Height = 62;
        //}

        //private void btnPedido_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnPedido.Width = 100;
        //    btnPedido.Height = 70;
        //}

        //private void btnPedido_MouseLeave(object sender, EventArgs e)
        //{
        //    btnPedido.Width = 63;
        //    btnPedido.Height = 62;
        //}

        //private void btnMateria_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnMateria.Width = 100;
        //    btnMateria.Height = 70;
        //}

        //private void btnMateria_MouseLeave(object sender, EventArgs e)
        //{
        //    btnMateria.Width = 63;
        //    btnMateria.Height = 62;
        //}

        //private void btnCompra_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnCompra.Width = 100;
        //    btnCompra.Height = 70;
        //}

        //private void btnCompra_MouseLeave(object sender, EventArgs e)
        //{
        //    btnCompra.Width = 63;
        //    btnCompra.Height = 62;
        //}

        //private void btnProduccion_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnProduccion.Width = 100;
        //    btnProduccion.Height = 70;
        //}

        //private void btnProduccion_MouseLeave(object sender, EventArgs e)
        //{
        //    btnProduccion.Width = 63;
        //    btnProduccion.Height = 62;
        //}

        //private void btnEmpleado_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnEmpleado.Width = 100;
        //    btnEmpleado.Height = 70;
        //}

        //private void btnEmpleado_MouseLeave(object sender, EventArgs e)
        //{
        //    btnEmpleado.Width = 63;
        //    btnEmpleado.Height = 62;
        //}

        //private void btnTerminado_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnTerminado.Width = 100;
        //    btnTerminado.Height = 70;
        //}

        //private void btnTerminado_MouseLeave(object sender, EventArgs e)
        //{
        //    btnTerminado.Width = 63;
        //    btnTerminado.Height = 62;
        //}

        //private void btnProveedor_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnProveedor.Width = 100;
        //    btnProveedor.Height = 70;
        //}

        //private void btnProveedor_MouseLeave(object sender, EventArgs e)
        //{
        //    btnProveedor.Width = 63;
        //    btnProveedor.Height = 62;
        //}

        //private void btnUsuario_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnUsuario.Width = 100;
        //    btnUsuario.Height = 70;
        //}

        //private void btnUsuario_MouseLeave(object sender, EventArgs e)
        //{
        //    btnUsuario.Width = 63;
        //    btnUsuario.Height = 62;
        //}

        //private void btnReportes_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnReportes.Width = 100;
        //    btnReportes.Height = 70;
        //}

        //private void btnReportes_MouseLeave(object sender, EventArgs e)
        //{
        //    btnReportes.Width = 63;
        //    btnReportes.Height = 62;
        //}

        //private void btnSalir_MouseMove(object sender, MouseEventArgs e)
        //{
        //    btnSalir.Width = 100;
        //    btnSalir.Height = 70;
        //}

        //private void btnSalir_MouseLeave(object sender, EventArgs e)
        //{
        //    btnSalir.Width = 63;
        //    btnSalir.Height = 62;
        //}

     
    }
}
