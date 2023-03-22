using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EntidadDetalle
    {
        private int id;
        private int ventaid;
        private int productoid;
        private int cantidad;
        private decimal precioVenta;
        private decimal subTotal;
        private string descripcion;
        private bool existe;

        public int ID {
            get => id; 
            set => id = value; 
        }
        public int VentaID { 
            get => ventaid; 
            set => ventaid = value; 
        }
        public int ProductoID { 
            get => productoid; 
            set => productoid = value; 
        }
        public int Cantidad { 
            get => cantidad; 
            set => cantidad = value; 
        }
        public decimal PrecioVenta { 
            get => precioVenta; 
            set => precioVenta = value; 
        }
        public decimal SubTotal { get => subTotal; set => subTotal = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Existe { get => existe; set => existe = value; }

        public EntidadDetalle() {
            ID = 0;
            VentaID = 0;
            ProductoID = 0;
            Cantidad = 0;
            PrecioVenta = 0;
            SubTotal = 0;
            Descripcion = string.Empty;
            Existe = false;
        }
    }
}
