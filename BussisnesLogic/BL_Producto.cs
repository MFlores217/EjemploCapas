using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;

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

        public int InsertarModificar(EntidadProducto Producto)
        {
            int resultado = -1;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.InsertarModificar(Producto);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public EntidadProducto ObtenerProducto(string condicion)
        {
            EntidadProducto resultado;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.ObtenerProducto(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public List<EntidadProducto> ListarProducto(string condicion="")
        {
            List<EntidadProducto> resultado;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.ListarProductos(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public bool Eliminar(int IDProducto){
            bool resultado = false;
            AD_Producto AccesoDatos = new AD_Producto(_cadenaConexion);
            AD_Detalle AccesoDetalle = new AD_Detalle(_cadenaConexion);

            try{
                string condicion = $"PRODUCTOID={IDProducto}";
                if (AccesoDetalle.ListarDetalles(condicion).Count > 0){
                    resultado = AccesoDatos.Eliminar(IDProducto, false);
                } else {
                    resultado = AccesoDatos.Eliminar(IDProducto, true);
                }
            }
            catch (Exception e){

                throw e;
            }

            return resultado;
        }
    }
}
