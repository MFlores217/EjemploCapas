using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AccesoDatos
{
    public class AD_Ventas
    {
        private string _cadenaConexion;

        public AD_Ventas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public EntidadVenta ObtenerVenta(string condicion = "")
        {
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            EntidadVenta venta = new EntidadVenta();
            string sentencia = "SELECT v.ID, CLIENTEID, CONCAT(NOMBRE, ' ', APELLIDO) AS NombreCliente, FECHA, TIPO, ESTADO FROM VENTAS v INNER JOIN CLIENTES c ON v.CLIENTEID=c.ID";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = $"{sentencia} where {condicion}";
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "VENTAS");
                //LINQ: Lenguaje de C# para manejo de consultas (Language Integrated Query)
                venta = (from DataRow registro in datos.Tables["VENTAS"].Rows
                           select new EntidadVenta()
                           {
                               ID = Convert.ToInt32(registro[0]),
                               ClienteID = Convert.ToInt32(registro[1]),
                               NombreCliente = registro[2].ToString(),
                               Fecha = Convert.ToDateTime(registro[3]),
                               Tipo = registro[4].ToString(),
                               Estado = registro[5].ToString(),
                               Existe = true
                           }).FirstOrDefault();
            }
            catch (Exception e)
            {

                throw e;
            }

            return venta;
        }

        public int Insertar(EntidadVenta venta, EntidadDetalle detalle){
            int resultado = 0;
            int IDVenta = 0;
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand cmd = new SqlCommand();
            string sentencia;
            EntidadVenta Busqueda;
            AD_Detalle AD_Detail = new AD_Detalle(_cadenaConexion);
            cmd.Connection= cnn;
            cnn.Open();
            SqlTransaction trans = cnn.BeginTransaction();
            try
            {
                cmd.Transaction = trans;
                Busqueda = ObtenerVenta($"ID={venta.ID}");
                if (!Busqueda.Existe){
                    sentencia = "INSERT INTO VENTAS(FECHA, TIPO, CLIENTEID, ESTADO) VALUES(@Fecha, @Tipo, @ClienteID, @Estado) SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@Tipo", venta.Tipo);
                    cmd.Parameters.AddWithValue("@ClienteID", venta.ClienteID);
                    cmd.Parameters.AddWithValue("@Estado", venta.Estado);
                    IDVenta = Convert.ToInt32(cmd.ExecuteScalar());
                    sentencia = "INSERT INTO DETALLE(VENTAID, PRODUCTOID, CANTIDAD, PRECIOVENTA) VALUES(@VENTAID, @PRODUCTOID, @CANTIDAD, @PRECIOVENTA)";
                    cmd.CommandText = sentencia;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@VENTAID", IDVenta);
                    cmd.Parameters.AddWithValue("@PRODUCTOID", detalle.ProductoID);
                    cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@PRECIOVENTA", detalle.PrecioVenta);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                } else {
                    if (Busqueda.Estado == "Pendiente"){
                        sentencia = "UPDATE VENTAS SET CLIENTEID=@CLIENTEID, TIPO=@TIPO WHERE ID=@ID";
                        cmd.CommandText = sentencia;
                        cmd.Parameters.AddWithValue("@ID", venta.ID);
                        cmd.Parameters.AddWithValue("@TIPO", venta.Tipo);
                        cmd.Parameters.AddWithValue("@CLIENTEID", venta.ClienteID);

                        cmd.ExecuteNonQuery();
                        if (AD_Detail.ObtenerDetalle($"ID={detalle.ID} AND VENTAID={venta.ID}").Existe){
                            sentencia = "UPDATE DETALLE SET PRODUCTOID=@PRODUCTOID, CANTIDAD=@CANTIDAD, PRECIOVENTA=@PRECIOVENTA WHERE ID=@ID";
                            cmd.CommandText = sentencia;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ID", detalle.ID);
                            cmd.Parameters.AddWithValue("@PRODUCTOID", detalle.ProductoID);
                            cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@PRECIOVENTA", detalle.PrecioVenta);
                            cmd.ExecuteNonQuery();
                        } else {
                            sentencia = "INSERT INTO DETALLE(VENTAID, PRODUCTOID, CANTIDAD, PRECIOVENTA) VALUES(@VENTAID, @PRODUCTOID, @CANTIDAD, @PRECIOVENTA)";
                            cmd.CommandText = sentencia;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@VENTAID", IDVenta);
                            cmd.Parameters.AddWithValue("@PRODUCTOID", detalle.ProductoID);
                            cmd.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@PRECIOVENTA", detalle.PrecioVenta);
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                }
                cnn.Close();
            }
            catch (Exception ex){
                trans.Rollback();
                throw ex;
            }
            

            return resultado;
        }
    }
}
