using BussisnesLogic;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VentasWeb
{
    public partial class FrmListaProductos : System.Web.UI.Page
    {
        string script;
        private void CargarProductos(string condicion = "")
        {
            BL_Producto Logica = new BL_Producto(Configuracion.getConnectionString);
            List<EntidadProducto> Lista;
            try
            {
                Lista = Logica.ListarProducto(condicion);
                if (Lista.Count > 0)
                {
                    grdLista.DataSource = Lista;
                    grdLista.DataBind();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                if (!IsPostBack)
                {
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {

                script = $"javascript:MostrarMensaje('{ex.Message}');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", script, true);
            }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion;
                condicion = $"descripcion like '%{txtDescripcion.Text}%'";
                CargarProductos(condicion);
            }
            catch (Exception ex)
            {

                script = $"javascript:MostrarMensaje('{ex.Message}');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", script, true);
            }
        }

        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            BL_Producto logica = new BL_Producto(Configuracion.getConnectionString);
            EntidadProducto producto;
            int id = Convert.ToInt32(e.CommandArgument.ToString());//Con este comando se identifica el ID que es parte del CommandArgument para poder eliminarlo
            try{
                producto = logica.ObtenerProducto($"Id={id}");
                if (producto.Existe)
                {
                    logica.Eliminar(id);
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {

                script = $"javascript:MostrarMensaje('{ex.Message}');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", script, true);
            }
        }

        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try{
                grdLista.PageIndex = e.NewPageIndex;
                CargarProductos();
            }
            catch (Exception ex){

                script = $"javascript:MostrarMensaje('{ex.Message}');";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", script, true);
            }
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmProductos.aspx");
        }
    }
}