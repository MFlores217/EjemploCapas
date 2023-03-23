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
    public partial class FrmBuscarClientes : Form
    {
        //Declaro el evento
        public event EventHandler AceptarCliente;
        //Variables globales
        private int IDCliente = 0;
        public FrmBuscarClientes()
        {
            InitializeComponent();
        }

        private void CargarClientes(string condicion = "")
        {
            BL_Cliente Logica = new BL_Cliente(Config.getConnectionString);
            List<EntidadCliente> Lista;
            try
            {
                Lista = Logica.ListarCliente(condicion);
                if (Lista.Count > 0)
                {
                    grdListaC.DataSource = Lista;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void SeleccionarClientes()
        {
            try
            {
                if (grdListaC.SelectedRows.Count > 0)
                {
                    IDCliente = Convert.ToInt32(grdListaC.SelectedRows[0].Cells[0].Value);
                    AceptarCliente(IDCliente, null);
                    Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try{
                if (!string.IsNullOrEmpty(txtNombreCliente.Text)){
                    condicion = $"CONCAT(NOMBRE,' ',APELLIDO) LIKE '%{txtNombreCliente.Text}%'";
                }
                CargarClientes(condicion);
            }
            catch (Exception){

                throw;
            }
        }

        private void FrmBuscarClientes_Load(object sender, EventArgs e)
        {
            try{
                CargarClientes("");
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdListaC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
                SeleccionarClientes();
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IDCliente = -1;
            AceptarCliente(IDCliente, null);
            Close();
        }
    }
}
