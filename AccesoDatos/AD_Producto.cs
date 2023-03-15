using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AD_Producto
    {
        private string _cadenaConexion;

        public AD_Producto(string cadenaConexion){
            _cadenaConexion = cadenaConexion;
        }

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
    }
}
