using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

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

        public List<EntidadCliente> ListarClientes(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<EntidadCliente> clientes = new List<EntidadCliente>();
            string sentencia = "SELECT ID, NOMBRE, APELLIDO, TELEFONO FROM CLIENTES";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} WHERE {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "CLIENTES");
                //LINQ: Lenguaje de C# para manejo de consultas (Language Integrated Query)
                clientes = (from DataRow registro in datos.Tables[0].Rows
                             select new EntidadCliente()
                             {
                                 ID = Convert.ToInt32(registro[0]),
                                 Nombre = registro[1].ToString(),
                                 Apellido = registro[2].ToString(),
                                 Telefono = registro[3].ToString()
                             }
                             ).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }

            return clientes;
        }
    }
}
