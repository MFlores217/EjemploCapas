using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos
{
    public class AD_Cliente
    {
        private string _cadenaConexion;

        public AD_Cliente(string cadenaConexion) {
            _cadenaConexion= cadenaConexion;
        }
        public EntidadCliente ObtenerCliente(string condicion)
        {
            EntidadCliente Cliente = new EntidadCliente();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            SqlDataReader datos;
            string sentencia = "SELECT ID, NOMBRE, APELLIDO, TELEFONO FROM CLIENTES";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }
            comando.CommandText = sentencia;
            try
            {
                cnn.Open();
                datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    datos.Read();
                    Cliente.ID = datos.GetInt32(0);
                    Cliente.Nombre = datos.GetString(1);
                    Cliente.Apellido = datos.GetString(2);
                    Cliente.Telefono = datos.GetString(3);
                    Cliente.Existe = true;
                }
                cnn.Close();
            }
            catch (Exception e)
            {

                throw e;
            }

            return Cliente;
        }
    }
}
