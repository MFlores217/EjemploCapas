﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Linq;

namespace AccesoDatos
{
    public class AD_Detalle
    {
        private string _cadenaConexion;
        public AD_Detalle(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public List<EntidadDetalle> ListarDetalles(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<EntidadDetalle> detalles = new List<EntidadDetalle>();
            string sentencia = "SELECT ID, VENTAID, PRODUCTOID, DESCRIPCION, CANTIDAD, PRECIOVENTA, SUBTOTAL FROM VW_DETALLES";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "DETALLE");
                //LINQ: Lenguaje de C# para manejo de consultas (Language Integrated Query)
                detalles = (from DataRow registro in datos.Tables["Detalle"].Rows
                             select new EntidadDetalle()
                             {
                                 ID = Convert.ToInt32(registro[0]),
                                 VentaID = Convert.ToInt32(registro[1]),
                                 ProductoID = Convert.ToInt32(registro[2]),
                                 Descripcion = registro[3].ToString(),
                                 Cantidad = Convert.ToInt32(registro[4]),
                                 PrecioVenta = Convert.ToDecimal(registro[5]),
                                 SubTotal = Convert.ToDecimal(registro[6])
                             }
                             ).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }

            return detalles;
        }
    }
}