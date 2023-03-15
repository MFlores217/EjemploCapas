using System;

namespace Entidades
{
    public class EntidadProducto
    {
        //Atributos
        private int id;
        private string descripcion;
        private int cantidad;
        private decimal precio;
        private bool existe;

        //Constructores
        public EntidadProducto()
        {
            Id = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Existe = false;
        }

        public EntidadProducto(int _id, string _descripcion, int _cantidad, decimal _precio)
        {
            Id = _id;
            Descripcion = _descripcion;
            Cantidad = _cantidad;
            Precio = _precio;
            Existe = true;
        }

        //Propiedades
        public int Id { 
            get => id; 
            set => id = value; 
        }
        public string Descripcion { 
            get => descripcion; 
            set => descripcion = value; 
        }
        public int Cantidad { 
            get => cantidad; 
            set => cantidad = value; 
        }
        public decimal Precio { 
            get => precio; 
            set => precio = value; 
        }
        public bool Existe { 
            get => existe; 
            set => existe = value; 
        }

        public override string ToString()
        {
            return $"ID: {id}, Descripción: {descripcion}, Cantidad: {cantidad}, Precio: {precio}";
        }
    }
}
