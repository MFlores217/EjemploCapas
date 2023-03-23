using BussisnesLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
            txtIDFactura.Tag = 0;
            txtIDProducto.Tag = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntidadVenta venta= new EntidadVenta();
            EntidadDetalle detalle = new EntidadDetalle();
            BL_Ventas Logica = new BL_Ventas(Config.getConnectionString);
            int resultado;
            venta.ID = 2;
            venta.Tipo = "Contado";
            venta.Estado = "Pendiente";
            venta.ClienteID = 1;
            detalle.ProductoID = 3;
            detalle.Cantidad = 1;
            detalle.ID = 5; 
            resultado = Logica.Insertar(venta, detalle);
            MessageBox.Show(Logica.Mensaje);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarClientes frm = new FrmBuscarClientes();
            frm.AceptarCliente += new EventHandler(AceptarCliente);
            frm.Show();
        }

        private void BuscarProducto(int ID)
        {
            EntidadProducto Producto;
            BL_Producto Logica = new BL_Producto();
            Logica.CadenaConexion = Config.getConnectionString;
            string condicion = $"Id={ID}";
            try
            {
                Producto = Logica.ObtenerProducto(condicion);
                if (Producto.Existe)
                {
                    txtIDProducto.Text = Producto.Id.ToString();
                    txtDescripcion.Tag = Producto.Id.ToString();
                    txtDescripcion.Text = Producto.Descripcion.ToString();
                    txtPrecio.Text = (Producto.Precio*(decimal)1.35).ToString("¢0,###.##");
                    numCantidad.Focus();
                }
                else
                {
                    txtIDProducto.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtDescripcion.Tag = string.Empty;
                    txtPrecio.Text = string.Empty;
                    numCantidad.Value = 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void BuscarCliente(int ID)
        {
            EntidadCliente Cliente;
            BL_Cliente Logica = new BL_Cliente(Config.getConnectionString);
            string condicion = $"Id={ID}";
            try{
                Cliente = Logica.ObtenerCliente(condicion);
                if (Cliente.Existe){
                    txtCliente.Tag = Cliente.ID.ToString();
                    txtCliente.Text = $"{Cliente.Nombre} {Cliente.Apellido}";
                }
                else{
                    MessageBox.Show("Imposible cargar los datos, ya que el cliente ha tenido cambios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void AceptarCliente(object ID, EventArgs e)
        {
            try{
                int IDCliente = (int)ID;
                if (IDCliente > -1 ){
                    BuscarCliente(IDCliente);
                }
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmBuscarProducto frm = new FrmBuscarProducto();
            frm.Aceptar += new EventHandler(Aceptar);
            frm.Show(this);
        }

        private void Aceptar(object IDProducto, EventArgs e)
        {
            try{
                int ID = (int)IDProducto;
                if (ID > -1){
                    BuscarProducto(ID);
                }
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            int codigo;
            try{
                if (e.KeyChar == 13)
                {
                    if (!string.IsNullOrEmpty(txtIDProducto.Text)){
                        if (int.TryParse(txtIDProducto.Text, out codigo)){
                            BuscarProducto(codigo);
                        }
                    }
                }
            }
            catch (Exception ex){
                throw ex;
            }
        }

        private void Insertar(){
            try{
                if (!string.IsNullOrEmpty(txtCliente.Text) && !string.IsNullOrEmpty(cboTipoVenta.Text)){
                    if(!string.IsNullOrEmpty(txtDescripcion.Tag.ToString()) && !string.IsNullOrEmpty(numCantidad.Value.ToString())){
                        EntidadVenta venta = new EntidadVenta();
                        EntidadDetalle detalle = new EntidadDetalle();
                        BL_Ventas Logica = new BL_Ventas(Config.getConnectionString);
                        detalle.VentaID = venta.ID;
                        txtIDFactura.Text = Logica.IDVenta.ToString();
                        CargarDetalles(Logica.IDVenta);
                        MessageBox.Show(Logica.Mensaje);
                    } else {
                        MessageBox.Show("Debe seleccionar un artículo y establecer una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {
                    MessageBox.Show("Faltan datos en el encabezado de la factura", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex){

                throw ex;
            }
        }

        private EntidadVenta GenerarVenta(){
            EntidadVenta venta = new EntidadVenta();
            if (!string.IsNullOrEmpty(txtIDFactura.Text)){
                venta.ID = Convert.ToInt32(txtIDFactura.Text);
            }
            venta.ClienteID = Convert.ToInt32(txtCliente.Tag);
            venta.Tipo = cboTipoVenta.Text;
            venta.Estado = "Pendiente";
            return venta;
        }

        private EntidadDetalle GenerarDetalle()
        {
            EntidadDetalle detalle = new EntidadDetalle();
            if (!string.IsNullOrEmpty(txtIDProducto.Tag.ToString())){
                detalle.ID = Convert.ToInt32(txtIDProducto.Tag);
            }
            detalle.ProductoID = Convert.ToInt32(txtDescripcion.Tag);
            detalle.Cantidad = Convert.ToInt32(numCantidad.Value);
            return  detalle;
        }

        private void CargarDetalles(int idventa){
            BL_Detalle logica = new BL_Detalle(Config.getConnectionString);
            List<EntidadDetalle> lista;
            try{
                lista = logica.ListarDetalles($"VENTAID={idventa}");
                grdListaVenta.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try{
                Insertar();
            }
            catch (Exception ex){

                throw ex;
            }
        }
    }
}
