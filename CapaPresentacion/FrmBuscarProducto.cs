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
    public partial class FrmBuscarProducto : Form
    {
        //Declaro el evento
        public event EventHandler Aceptar;
        //Variables globales
        private int IDProducto=0;
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }

        private void CargarProductos(string condicion = "")
        {
            BL_Producto Logica = new BL_Producto(Config.getConnectionString);
            List<EntidadProducto> Lista;
            try
            {
                Lista = Logica.ListarProducto(condicion);
                if (Lista.Count > 0)
                {
                    grdListaBP.DataSource = Lista;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void SeleccionarProducto()
        {
            try{
                if(grdListaBP.SelectedRows.Count > 0){
                    IDProducto = Convert.ToInt32(grdListaBP.SelectedRows[0].Cells[0].Value);
                    Aceptar(IDProducto, null);
                    Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            try{
                CargarProductos(string.Empty);
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdListaBP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
                SeleccionarProducto();
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarProducto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IDProducto = -1;
            Aceptar(IDProducto,null);
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion;
            try{
                if (!string.IsNullOrEmpty(txtDescripcion.Text)){
                    condicion = $"ID = '{txtID.Text}' OR DESCRIPCION LIKE '%{txtDescripcion.Text.Trim()}%'";
                } else {
                    condicion = $"ID='{txtID.Text}'";
                }
                CargarProductos(condicion);
            }
            catch (Exception){

                throw;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
