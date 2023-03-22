using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            FrmProductos productos = new FrmProductos();
            productos.Show(this);
        }

        private void mnuVentas_Click(object sender, EventArgs e)
        {
            FrmVentas venta = new FrmVentas();
            venta.Show(this);
        }
    }
}
