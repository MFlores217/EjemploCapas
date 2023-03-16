using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AccesoDatos
{
    public class AD_Producto
    {
        private string _cadenaConexion;
        private int id_producto;

        public AD_Producto(string cadenaConexion){
            _cadenaConexion = cadenaConexion;
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }

        /// <summary>
        /// Inserta un producto en la base de datos
        /// </summary>
        /// <param name="Producto">entidad a insertar</param>
        /// <returns>ID del producto insertado</returns>
        public int Insertar(EntidadProducto Producto){
            int resultado = -1;
            SqlConnection Conexion = new SqlConnection(_cadenaConexion);
            SqlCommand Comando = new SqlCommand();
            Comando.Connection = Conexion;
            string sentencia;
            try{
                sentencia = "INSERT INTO Productos(DESCRIPCION, CANTIDAD, PRECIO) VALUES(@Descripcion, @Cantidad, @Precio) SELECT SCOPE_IDENTITY()";
                //Agrega el valor de los parametros para añadirlos a la sentencia
                Comando.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                Comando.Parameters.AddWithValue("@Cantidad", Producto.Cantidad);
                Comando.Parameters.AddWithValue("@Precio", Producto.Precio);
                Comando.CommandText = sentencia;

                Conexion.Open();
                resultado = Convert.ToInt32(Comando.ExecuteScalar());
                Conexion.Close();
            }
            catch (Exception e){

                throw e;
            }
            finally{
                //Destruye las variables de memoria
                Conexion.Dispose();
                Comando.Dispose();
            }


            return resultado;
        }

        public int InsertarModificar(EntidadProducto Producto){
            int resultado = -1;
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            string sentencia;
            try{
                sentencia = "SP_INSERTAR_MODIFICAR";
                comando.CommandText = sentencia;
                comando.CommandType = CommandType.StoredProcedure;
                //Parametros de entrada:
                comando.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                comando.Parameters.AddWithValue("@Cantidad", Producto.Cantidad);
                comando.Parameters.AddWithValue("@Precio", Producto.Precio);
                //Parametros de salida:
                comando.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.InputOutput;
                comando.Parameters["@ID"].Value = Producto.Id;
                comando.Parameters.Add("@Resultado", SqlDbType.Int).Direction= ParameterDirection.Output;
                cnn.Open();
                comando.ExecuteNonQuery();
                id_producto = Convert.ToInt32(comando.Parameters["@ID"].Value);
                resultado = Convert.ToInt32(comando.Parameters["@RESULTADO"].Value);
                cnn.Close();
            }
            catch (Exception){

                throw;
            }

            return resultado;
        }

        public EntidadProducto ObtenerProducto(string condicion)
        {
            EntidadProducto Producto = new EntidadProducto();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            comando.Connection = cnn;
            SqlDataReader datos;
            string sentencia = "SELECT ID, DESCRIPCION, CANTIDAD, PRECIO FROM PRODUCTOS";
            if (!string.IsNullOrEmpty(condicion)){
                sentencia = $"{sentencia} where {condicion}";
            }
            comando.CommandText = sentencia;
            try{
                cnn.Open();
                datos = comando.ExecuteReader();
                if (datos.HasRows){
                    datos.Read();
                    Producto.Id = datos.GetInt32(0);
                    Producto.Descripcion = datos.GetString(1);
                    Producto.Cantidad = datos.GetInt32(2);
                    Producto.Precio = datos.GetDecimal(3);
                    Producto.Existe = true;
                }
                cnn.Close();
            }
            catch (Exception e){

                throw e;
            }

            return Producto;
        }

        public List<EntidadProducto> ListarProductos(string condicion=""){
            DataSet datos = new DataSet();
            SqlConnection cnn = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            List<EntidadProducto> productos= new List<EntidadProducto>();
            string sentencia = "SELECT ID, DESCRIPCION, CANTIDAD, PRECIO FROM PRODUCTOS";
            if (!string.IsNullOrEmpty(condicion)){
                sentencia = $"{sentencia} where {condicion}";
            }
            try{
                adapter = new SqlDataAdapter(sentencia, cnn);
                adapter.Fill(datos, "PRODUCTOS");
                //LINQ: Lenguaje de C# para manejo de consultas (Language Integrated Query)
                productos = (from DataRow registro in datos.Tables[0].Rows
                             select new EntidadProducto()
                             {
                                 Id = Convert.ToInt32(registro[0]),
                                 Descripcion = registro[1].ToString(),
                                 Cantidad = Convert.ToInt32(registro[2]),
                                 Precio = Convert.ToDecimal(registro[3])
                             }
                             ).ToList();
            }
            catch (Exception e){

                throw e;
            }
            
            return productos;
        }
    }
}
