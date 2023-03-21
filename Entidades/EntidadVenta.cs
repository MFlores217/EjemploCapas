using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EntidadVenta
    {
        private int id;
        private string nombreCliente;
        private DateTime fecha;
        private string tipo;
        private int clienteID;
        private decimal total;
        private string estado;
        private bool existe;

        public int ID { 
            get => id; 
            set => id = value; 
        }
        public string NombreCliente { 
            get => nombreCliente; 
            set => nombreCliente = value; 
        }
        public DateTime Fecha { 
            get => fecha; 
            set => fecha = value; 
        }
        public string Tipo { 
            get => tipo; 
            set => tipo = value; 
        }
        public int ClienteID { 
            get => clienteID; 
            set => clienteID = value; 
        }
        public decimal Total { 
            get => total; 
            set => total = value; 
        }
        public string Estado { 
            get => estado; 
            set => estado = value; 
        }
        public bool Existe { get => existe; set => existe = value; }

        public EntidadVenta()
        {
            ID = 0;
            NombreCliente = string.Empty;
            Estado = string.Empty;
            Fecha = DateTime.Today;
            Tipo = string.Empty;
            ClienteID = 0;
            Total = 0;
            Existe = false;
        }

    }
}
