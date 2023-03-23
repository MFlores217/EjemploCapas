using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussisnesLogic
{
    public class BL_Ventas
    {
        private string _cadenaConexion;
        private string mensaje;
        private int _iDVenta;

        public string Mensaje { get => mensaje; set => mensaje = value; }

        public int IDVenta { get => _iDVenta; set => _iDVenta = value; }

        public BL_Ventas(string cadenaConexion) {
            _cadenaConexion = cadenaConexion;
            Mensaje = string.Empty;
            IDVenta = 0;
        }

        public EntidadVenta ObtenerVenta(string condicion = "")
        {
            EntidadVenta resultado;
            AD_Ventas AccesoDatos = new AD_Ventas(_cadenaConexion);
            try{
                resultado = AccesoDatos.ObtenerVenta(condicion);
            }
            catch (Exception e){

                throw e;
            }
            return resultado;
        }

        public int Insertar(EntidadVenta venta, EntidadDetalle detalle){
            int resultado = 0;
            AD_Ventas ADVenta = new AD_Ventas(_cadenaConexion);
            AD_Cliente ADCliente = new AD_Cliente(_cadenaConexion);
            AD_Producto ADProducto = new AD_Producto(_cadenaConexion);
            EntidadProducto Producto;
            try{
                if (ADCliente.ObtenerCliente($"ID={venta.ClienteID}").Existe){
                    Producto = ADProducto.ObtenerProducto($"ID={detalle.ProductoID}");
                    if (Producto.Existe){
                        detalle.PrecioVenta = Producto.Precio + (Producto.Precio * (decimal)0.35);
                        resultado = ADVenta.Insertar(venta, detalle);
                        _iDVenta = ADVenta.IDVenta;
                        switch (resultado){
                            case 1:
                                Mensaje = "Venta ingresada satisfactoriamente";
                                break;
                            case 2:
                                Mensaje = "Venta actualizada correctamente";
                                break;
                            case 3:
                                Mensaje = "Se agregó un nuevo producto satisfactoriamente";
                                break;
                            case 4:
                                Mensaje = "No se puede realizar cambios a la venta cancelada";
                                break;
                        }
                    } else {
                        resultado = 6;
                        Mensaje = "Imposible insertar la venta ya que el producto no existe";
                    }
                } else {
                    resultado = 5;//Cliente NO existe.
                    Mensaje = "Imposible insertar la venta ya que el cliente NO existe.";
                }
            }
            catch (Exception ex){

                throw ex;
            }

            return resultado;
        }

    }
}
