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
    public partial class FNVenta : Form
    {
        private bool isNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;
        private decimal TotalPagado = 0;
        private static FNVenta _Instancia;

        public static FNVenta GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FNVenta();
            }
            return _Instancia;
        }
        public void SetCliente(string pIdCliente, string pNombreCliente)
        {
            this.txtIdCliente.Text = pIdCliente;
            this.txtCliente.Text = pNombreCliente;

        }

        public void SetArticulo(string pIdDetalleIngreso,string pNombre, 
            decimal pPrecioCompra, decimal pPrecioVenta,int pStock, DateTime pFechaVencimiento)
        {
            this.txtIdArticulo.Text = pIdDetalleIngreso;
            this.txtArticulo.Text = pNombre;
            this.txtPrecioCompra.Text = pPrecioCompra.ToString();
            this.txtPrecioVenta.Text = pPrecioVenta.ToString();
            this.txtStockActual.Text = pStock.ToString();
            this.dtFechaVen.Value = pFechaVencimiento;
        }
        public FNVenta()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCliente, "Seleccione un Cliente");
            ttMensaje.SetToolTip(txtSerie, "Ingrese una Serie");
            ttMensaje.SetToolTip(textCorrelativo, "Ingrese un numero de Comprobante");
            ttMensaje.SetToolTip(txtCantidad, "Ingrese la Cantidad");
            ttMensaje.SetToolTip(txtArticulo, "Ingrese el nombre del Articulo");
            this.txtIdCliente.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFechaVen.Enabled = false;
            this.txtPrecioCompra.ReadOnly = true;
            this.txtStockActual.ReadOnly = true;
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
            this.txtIdVenta.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
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
            this.txtStockActual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;


        }

        private void Habilitar(bool pValor)
        {
            this.txtIdVenta.ReadOnly = !pValor;
            this.txtSerie.ReadOnly = !pValor;
            this.textCorrelativo.ReadOnly = !pValor;
            this.txtIGV.ReadOnly = !pValor;
            this.dtFecha.Enabled = pValor;
            this.cbComprobantes.Enabled = pValor;
            this.txtCantidad.ReadOnly = !pValor;
            this.txtPrecioCompra.ReadOnly = !pValor;
            this.txtPrecioVenta.ReadOnly = !pValor;
            this.dtFechaVen.Enabled = pValor;
            this.txtStockActual.ReadOnly = !pValor;
            this.txtDescuento.ReadOnly = !pValor;

            this.btnBuscarArticulo.Enabled = pValor;
            this.btnBuscarCliente.Enabled = pValor;
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
            this.dtgListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }

        private void BuscarFecha()
        {
            this.dtgListado.DataSource = NVenta.BuscarFechas(this.dtFechInicio.Value.ToString("dd/MM/yyyy"),
                                                            this.dtFechaFin.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros " + Convert.ToString(dtgListado.Rows.Count);
        }
        private void MostrarDetalle()
        {
            this.dtListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdVenta.Text);

        }
        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //relacionamos nuestro datagrid con el datatable detalle
            this.dtListadoDetalle.DataSource = this.dtDetalle;
        }

        private void FNVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();
            Habilitar(false);
            HabilitarBotones();
            CrearTabla();
        }

        private void FNVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FNVistaClienteVenta Vista = new FNVistaClienteVenta();
            Vista.ShowDialog();

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FNVistaArticuloVenta Articulo = new FNVistaArticuloVenta();
            Articulo.ShowDialog();

        }

        private void btnBuscarIngreso_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dtgListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente el Registro");
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

        private void dtgListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdVenta.Text = this.dtgListado.CurrentRow.Cells["idventa"].Value.ToString();
            this.txtCliente.Text = this.dtgListado.CurrentRow.Cells["cliente"].Value.ToString();
            this.dtFecha.Value = Convert.ToDateTime(this.dtgListado.CurrentRow.Cells["fecha"].Value);
            this.cbComprobantes.Text = this.dtgListado.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            this.txtSerie.Text = this.dtgListado.CurrentRow.Cells["serie"].Value.ToString();
            this.textCorrelativo.Text = this.dtgListado.CurrentRow.Cells["correlativo"].Value.ToString();
            this.lblTotalPagado.Text = this.dtgListado.CurrentRow.Cells["total"].Value.ToString();
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
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
            isNuevo = true;
            HabilitarBotones();
            Limpiar();
            LimpiarDetalle();
            Habilitar(true);
            txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            isNuevo = false;
            HabilitarBotones();
            Limpiar();
            LimpiarDetalle();
            Habilitar(false);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (txtIdCliente.Text == string.Empty || txtSerie.Text == string.Empty || textCorrelativo.Text == string.Empty || txtIGV.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar");
                    errorIcono.SetError(txtIdCliente, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(textCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIGV, "Ingrese un Valor");


                }
                else
                {

                    if (this.isNuevo)
                    {
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text),Idtrabajador, this.dtFecha.Value, this.cbComprobantes.Text,
                                                this.txtSerie.Text, this.textCorrelativo.Text, Convert.ToDecimal(this.txtIGV.Text),
                                                 this.dtDetalle);
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


                if (txtIdArticulo.Text == string.Empty || txtCantidad.Text == string.Empty
                    || txtDescuento.Text == string.Empty || txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar Ingresar");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un Valor");


                }
                else
                {

                    bool registrar = true;
                    foreach (DataRow Fila in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(Fila["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se Encuentra el Articulo");

                        }
                    }

                    if (registrar && Convert.ToInt32(this.txtCantidad.Text)<= Convert.ToInt32(this.txtStockActual.Text))
                    {
                        decimal SubTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text)-Convert.ToDecimal(this.txtDescuento.Text);
                        TotalPagado += SubTotal;
                        this.lblTotalPagado.Text = TotalPagado.ToString("#0.00##");

                        //agregar ese detalle al dtglistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = SubTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No tiene stock Suficiente");
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

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            FNReporteFac Reporte = new FNReporteFac();
            Reporte.Idventa = Convert.ToInt32(this.dtgListado.CurrentRow.Cells["idventa"].Value);
            Reporte.ShowDialog();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPagado_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void dtListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtIdArticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtFechaVen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtStockActual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cbComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCorrelativo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RPTVentas Form = new RPTVentas();
            Form.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFechInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
