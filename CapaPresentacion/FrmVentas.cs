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
    }
}
