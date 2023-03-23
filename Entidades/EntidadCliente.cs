using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EntidadCliente
    {
        private int iD;
        private string nombre;
        private string apellido;
        private string telefono;
        private string nombreCompleto;
        private bool existe;

        public int ID { 
            get => iD; 
            set => iD = value; 
        }
        public string Nombre { 
            get => nombre; 
            set => nombre = value; 
        }
        public string Apellido { 
            get => apellido; 
            set => apellido = value; 
        }
        public string Telefono { 
            get => telefono; 
            set => telefono = value; 
        }
        public bool Existe { 
            get => existe; 
            set => existe = value; 
        }
        public string NombreCompleto { 
            get => $"{nombre} {apellido}"; 
            set => nombreCompleto = value; 
        }

        public EntidadCliente(){
            ID = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Existe = false;
        }
    }
}
