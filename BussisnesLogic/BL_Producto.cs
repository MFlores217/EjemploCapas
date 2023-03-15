using AccesoDatos;
using Entidades;
using System;

namespace BussisnesLogic
{
    public class BL_Producto
    {
        private string _cadenaConexion;

        public string CadenaConexion { 
            get => _cadenaConexion; 
            set => _cadenaConexion = value; 
        }

        public BL_Producto(){
            _cadenaConexion = string.Empty;
        }
        public BL_Producto(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public int Insertar(EntidadProducto Producto){
            int resultado = -1;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);
            try{
                resultado = AccesoDatos.Insertar(Producto);
            }
            catch (Exception e){

                throw e;
            }

            return resultado;
        }
    }
}
