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
            try{
                if (!string.IsNullOrEmpty(txtDescripcion.Text) && !string.IsNullOrEmpty(txtPrecio.Text)){
                    if (decimal.TryParse(txtPrecio.Text, out Precio)){
                        Producto = GenerarEntidad();
                        //TODO: Llamar a los métodos de insertar y modificar.
                        if (Producto.Existe){
                            //TODO: Modificar el producto
                        } else {
                            if (Logica.Insertar(Producto) > 0){
                                MessageBox.Show("El producto se registró satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpiar();
                                //TODO: Actualizar la tabla
                            } else {
                                MessageBox.Show("No fue posible insertar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
    }
}
