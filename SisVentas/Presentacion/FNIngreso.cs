using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class FNIngreso : Form
    {
        private static FNIngreso _Instancia;
        public int IdTrabajador;
        private bool isNuevo;
        private DataTable dtDetalle;
        private decimal TotalPagado = 0;


        public static FNIngreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FNIngreso();
            }
            return _Instancia;
        }
        public void SetProveedor(string pIdProveedor, string pNombreProveedor)
        {
            this.txtIdProveedor.Text = pIdProveedor;
            this.txtProveedor.Text = pNombreProveedor;
        }
        public void SetArticulo(string pIdArticulo, string pNombreArticulo)
        {
            this.txtIdArticulo.Text = pIdArticulo;
            this.txtArticulo.Text = pNombreArticulo;
        }



        public FNIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el Proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "La Serie");
            this.ttMensaje.SetToolTip(this.textCorrelativo, "Ingrese el Numero del Comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la Cantidad de Compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el Articulo de Compra");
            this.txtIdProveedor.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;


        }
        private void MensajeOk(string pMensaje)
        {
            MessageBox.Show(pMensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MensajeError(string pMensaje)
        {
            MessageBox.Show(pMensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void Limpiar()
        {
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.textCorrelativo.Text = string.Empty;
            this.txtIGV.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";
            this.CrearTabla();
            this.txtIGV.Text = "0";

        }
        private void LimpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;

        }

        private void Habilitar(bool pValor)
        {
            this.txtIdIngreso.ReadOnly = !pValor;
            this.txtSerie.ReadOnly = !pValor;
            this.textCorrelativo.ReadOnly = !pValor;
            this.txtIGV.ReadOnly = !pValor;
            this.dtFecha.Enabled = pValor;
            this.cbComprobantes.Enabled = pValor;
            this.txtStock.ReadOnly = !pValor;
            this.txtPrecioCompra.ReadOnly = !pValor;
            this.txtPrecioVenta.ReadOnly = !pValor;
            this.dtFechaProd.Enabled = pValor;
            this.dtFechaVen.Enabled = pValor;

            this.btnBuscarArticulo.Enabled = pValor;
            this.btnBuscarPro.Enabled = pValor;
            this.btnAgregar.Enabled = pValor;
            this.btnQuitar.Enabled = pValor;

            
        }

        private void HabilitarBotones()
        {
            if (this.isNuevo)
            {
                this.Habilitar(true);
                this.btbNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;


            }
            else
            {
                this.Habilitar(false);
                this.btbNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dtgListado.Columns[0].Visible = false;
            this.dtgListado.Columns[1].Visible = false;
         




        }
        
        private void Mostrar()
        {
            this.dtgListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarFecha()
        {
            this.dtgListado.DataSource = NIngreso.BuscarFechas(this.dtFechInicio.Value.ToString("dd/MM/yyyy"),
                                                            this.dtFechaFin.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        private void MostrarDetalle()
        {
            this.dtListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);
           
        }



        private void FNIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.CrearTabla();
            this.Mostrar();
            this.Habilitar(false);
            this.HabilitarBotones();
            

        }

        private void FNIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;

        }

        private void btnBuscarPro_Click(object sender, EventArgs e)
        {
            FNVistaProveedorI VistaPro = new FNVistaProveedorI();
            VistaPro.ShowDialog();

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FNVistaArticuloI VistaIngreso = new FNVistaArticuloI();
            VistaIngreso.ShowDialog();

        }

        private void btnBuscarIngreso_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();

        }
        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //relacionamos nuestro datagrid con el datatable detalle
            this.dtListadoDetalle.DataSource = this.dtDetalle;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea anular los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dtgListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anulo Correctamente el Registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chEliminar.Checked)
            {
                this.dtgListado.Columns[0].Visible = true;

            }
            else
            {
                this.dtgListado.Columns[0].Visible = false;
            }
        }

        private void dtgListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dtgListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btbNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.LimpiarDetalle();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.HabilitarBotones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (txtIdProveedor.Text == string.Empty || txtSerie.Text == string.Empty || textCorrelativo.Text == string.Empty ||txtIGV.Text==string.Empty)
                {
                    MensajeError("Falta Ingresar");
                    errorIcono.SetError(txtIdProveedor, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(textCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIGV, "Ingrese un Valor");


                }
                else
                {
                   
                    if (this.isNuevo)
                    {
                        rpta = NIngreso.Insertar(this.IdTrabajador,Convert.ToInt32(this.txtIdProveedor.Text),this.dtFecha.Value,this.cbComprobantes.Text,
                                                this.txtSerie.Text,this.textCorrelativo.Text,Convert.ToDecimal(this.txtIGV.Text),
                                                "EMITIDO", this.dtDetalle);
                    }
                    
                    if (rpta.Equals("OK"))
                    {
                        if (this.isNuevo)
                        {
                            this.MensajeOk("Se Inserto el Registro");
                        }
                       
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.isNuevo = false;
                    this.HabilitarBotones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (txtIdArticulo.Text == string.Empty || txtStock.Text == string.Empty 
                    || txtPrecioCompra.Text == string.Empty || txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar Ingresar");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un Valor");


                }
                else
                {

                    bool registrar = true;
                    foreach(DataRow Fila in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(Fila["idarticulo"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se Encuentra el Articulo");
                            
                        }
                    }

                    if (registrar)
                    {
                        decimal SubTotal = Convert.ToDecimal((this.txtStock.Text)) * Convert.ToDecimal((this.txtPrecioCompra.Text));
                        TotalPagado += SubTotal;
                        this.lblTotalPagado.Text = TotalPagado.ToString("#0.00##");

                        //agregar ese detalle al dtglistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fecha_produccion"] = this.dtFechaProd.Value;
                        row["fecha_vencimiento"] = this.dtFechaVen.Value;
                        row["subtotal"] = SubTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int IndiceFila = this.dtListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[IndiceFila];

                //restar el total pagado
                this.TotalPagado = TotalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotalPagado.Text = TotalPagado.ToString("#0.00##");

                //eliminamos la fila
                this.dtDetalle.Rows.Remove(row);

            }
            catch
            {
                MensajeError("No Hay Fila Para Remover");
            }
        }

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = this.dtgListado.CurrentRow.Cells["idingreso"].Value.ToString();
            this.txtProveedor.Text = this.dtgListado.CurrentRow.Cells["proveedor"].Value.ToString();
            this.dtFecha.Value = Convert.ToDateTime(this.dtgListado.CurrentRow.Cells["fecha"].Value);
            this.cbComprobantes.Text = this.dtgListado.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            this.txtSerie.Text = this.dtgListado.CurrentRow.Cells["serie"].Value.ToString();
            this.textCorrelativo.Text = this.dtgListado.CurrentRow.Cells["correlativo"].Value.ToString();
            this.lblTotalPagado.Text = this.dtgListado.CurrentRow.Cells["total"].Value.ToString();
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex=1;


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
