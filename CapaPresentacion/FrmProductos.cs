using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Windows.Forms;
using BussisnesLogic;

namespace CapaPresentacion
{
    public partial class FrmProductos : Form
    {
        //Variable global que crea la instancia de la entidad que se desea buscar
        private EntidadProducto EntidadBuscada = new EntidadProducto();
        private static FrmBuscarProducto buscarProducto;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtID.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Value = 0;
            txtPrecio.Text = string.Empty;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8){
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8 || (int)e.KeyChar == 44){
                e.Handled = false;
            }
            else {
                e.Handled = true;
            }
        }

        private void CargarProductos(string condicion=""){
            BL_Producto Logica = new BL_Producto(Config.getConnectionString);
            List<EntidadProducto> Lista;
            try{
                Lista = Logica.ListarProducto(condicion);
                if (Lista.Count > 0){
                    grdLista.DataSource = Lista;
                }
            }
            catch (Exception e){

                throw e;
            }
        }

        private EntidadProducto GenerarEntidad()
        {
            EntidadProducto entidad;
            if (!string.IsNullOrEmpty(txtID.Text)){
                entidad = EntidadBuscada;
            } else {
                entidad = new EntidadProducto();
            }
            entidad.Descripcion = txtDescripcion.Text;
            entidad.Cantidad = (int)txtCantidad.Value;
            entidad.Precio = Convert.ToDecimal(txtPrecio.Text);
            return entidad;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadProducto Producto;
            BL_Producto Logica = new BL_Producto(Config.getConnectionString);
            decimal Precio;
            int retorno;
            try{
                if (!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtPrecio.Text)){
                    if (decimal.TryParse(txtPrecio.Text, out Precio)){
                        Producto = GenerarEntidad();
                        //TODO: Llamar a los métodos de insertar y modificar.
                        retorno = Logica.Insertar(Producto);
                        if (retorno > 0){
                            if (retorno == 1) {
                                MessageBox.Show("El producto se registró satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } else if (retorno == 2){
                                MessageBox.Show("El producto se modificó satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            Limpiar();
                            CargarProductos();
                            //TODO: Actualizar la tabla
                        }
                        else{
                            MessageBox.Show("No fue posible realizar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (Producto.Existe){
                            //TODO: Modificar el producto
                        } else {
                            
                        }
                    } else {
                        MessageBox.Show("El precio requiere un valor númerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("La descripción y el precio son datos requeridos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            try{
                CargarProductos("");
            }
            catch (Exception ex){

                throw ex;
            }
        }

        private void grdLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e){
            int id = 0;
            try{
                id = Convert.ToInt32(grdLista.SelectedRows[0].Cells[0].Value);
                BuscarProducto(id);
            }
            catch (Exception){

                throw;
            }
        }

        private void BuscarProducto(int ID){
            EntidadProducto Producto = new EntidadProducto();
            BL_Producto Logica = new BL_Producto();
            Logica.CadenaConexion = Config.getConnectionString;
            string condicion = $"Id={ID}";
            try{
                Producto = Logica.ObtenerProducto(condicion);
                if (Producto.Existe) {
                    txtID.Text = Producto.Id.ToString();
                    txtDescripcion.Text = Producto.Descripcion.ToString();
                    txtCantidad.Value = Producto.Cantidad;
                    txtPrecio.Text = Producto.Precio.ToString();
                    EntidadBuscada = Producto;
                } else {
                    MessageBox.Show("Imposible cargar los datos, ya que el producto ha tenido cambios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarProductos();
                }
            }
            catch (Exception){

                throw;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarProducto = new FrmBuscarProducto();
            buscarProducto.Aceptar += new EventHandler(Aceptar);
            buscarProducto.Show();
        }

        private void Aceptar(object ID, EventArgs e){
            try{
                int IDProducto = (int)ID;
                if (IDProducto > -1){
                    BuscarProducto(IDProducto);
                }
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BL_Producto LogicaProducto = new BL_Producto(Config.getConnectionString);
            try{
                if (!string.IsNullOrEmpty(txtID.Text)){
                    LogicaProducto.Eliminar(Convert.ToInt32(txtID.Text));
                    MessageBox.Show("Operación realizada satisfactoriamente", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    CargarProductos();
                }
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
