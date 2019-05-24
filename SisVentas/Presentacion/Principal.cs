using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";


        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

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

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNCategoria FCategoria = new FNCategoria();
            FCategoria.MdiParent = this;
            FCategoria.WindowState = FormWindowState.Maximized;
            FCategoria.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNPresentacion FPresentacion = new FNPresentacion();
            FPresentacion.MdiParent = this;
            FPresentacion.WindowState = FormWindowState.Maximized;
            FPresentacion.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNArticulo FArticulo = FNArticulo.GetInstancia();
            FArticulo.MdiParent = this;
            FArticulo.WindowState = FormWindowState.Maximized;
            FArticulo.Show();


        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNProveedor FProveedor = new FNProveedor();
            FProveedor.MdiParent = this;
            FProveedor.WindowState = FormWindowState.Maximized;
            FProveedor.Show();

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNcliente FCliente = new FNcliente();
            FCliente.MdiParent = this;
            FCliente.WindowState = FormWindowState.Maximized;
            FCliente.Show();

        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNTrabajador FTrabajador = new FNTrabajador();
            FTrabajador.MdiParent = this;
            FTrabajador.WindowState = FormWindowState.Maximized;
            FTrabajador.Show();

        }

        private void GUsuario()
        {
            //Controla los accesos
            if (Acceso == "Administrador")
            {
               this. mnuAlmacen.Enabled = true;
                this.mnuCompras.Enabled = true;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = true;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsCompras.Enabled = true;
                this.tsVentas.Enabled = true;
                
            }
            else if (Acceso == "Mostrador")
            {
                this.mnuAlmacen.Enabled = false;
                this.mnuCompras.Enabled = false;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsCompras.Enabled = false;
                this.tsVentas.Enabled = true;
            }
            else if (Acceso == "Almacen")
            {
                this.mnuAlmacen.Enabled = true;
                this.mnuCompras.Enabled = true;
                this.mnuVentas.Enabled = false;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsCompras.Enabled = true;
                this.tsVentas.Enabled = false;
            }
            else
            {
                this.mnuAlmacen.Enabled = false;
                this.mnuCompras.Enabled = false;
                this.mnuVentas.Enabled = false;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = false;
                this.mnuHerramientas.Enabled = false;
                this.tsCompras.Enabled = false;
                this.tsVentas.Enabled = false;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            GUsuario();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNIngreso Form = FNIngreso.GetInstancia();
            Form.MdiParent = this;
            Form.WindowState = FormWindowState.Maximized;
            Form.Show();
            Form.IdTrabajador = Convert.ToInt32(this.Idtrabajador);

        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FNVenta Form = FNVenta.GetInstancia();
            Form.MdiParent = this;
            Form.WindowState = FormWindowState.Maximized;
            Form.Show();
            Form.Idtrabajador = Convert.ToInt32(this.Idtrabajador);

        }

        private void ventasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
