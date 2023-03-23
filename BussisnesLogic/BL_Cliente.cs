using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussisnesLogic
{
    public class BL_Cliente
    {
        private string _cadenaConexion;

        public BL_Cliente(string cadenaConexion){
            _cadenaConexion = cadenaConexion;
        }

        public EntidadCliente ObtenerCliente(string condicion){
            EntidadCliente resultado;
            AD_Cliente AccesoDatos = new AD_Cliente(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.ObtenerCliente(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

        public List<EntidadCliente> ListarCliente(string condicion = ""){
            List<EntidadCliente> resultado;
            AD_Cliente AccesoDatos = new AD_Cliente(_cadenaConexion);
            try
            {
                resultado = AccesoDatos.ListarClientes(condicion);
            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

    }
}
