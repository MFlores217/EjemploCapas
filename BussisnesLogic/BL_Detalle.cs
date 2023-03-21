using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussisnesLogic
{
    public class BL_Detalle
    {
        private string _cadenaConexion;

        public BL_Detalle(string cadenaConexion) {
            _cadenaConexion= cadenaConexion;
        }

        public List<EntidadDetalle> ListarDetalles(string condicion = "")
        {
            List<EntidadDetalle> resultado;
            AD_Detalle AccesoDatos = new AD_Detalle(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.ListarDetalles(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public EntidadDetalle ObtenerDetalle(string condicion = "")
        {
            EntidadDetalle resultado;
            AD_Detalle AccesoDatos = new AD_Detalle(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.ObtenerDetalle(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public bool Eliminar(int ID)
        {
            bool resultado = false;
            AD_Detalle AccesoDatos = new AD_Detalle(_cadenaConexion);

            try
            {
                resultado = AccesoDatos.Eliminar(ID);
            }
            catch (Exception e)
            {
                throw e;
            }
            return resultado;
        }
    }
}
