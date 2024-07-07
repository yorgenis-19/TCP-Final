using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace E_commerce
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Dominio.Articulo> carritoActual = (List<Dominio.Articulo>)Session["CarritoCompras"];
                int cantArticulos = carritoActual != null ? carritoActual.Count : 0;
                Dominio.Usuario usuario = (Dominio.Usuario)Session["usuario"];
                if (usuario != null && usuario.RolUsuario == Dominio.RolUsuario.admin)
                {
                    adminMenu.Visible = true;
                    UsuarioMenu.Visible = false;
                }
                else
                {
                    adminMenu.Visible = false;
                    UsuarioMenu.Visible = true;
                }
                ActualizarContadorCarrito(cantArticulos);

            }

        }
        public void ActualizarContadorCarrito(int contador)
        {
            Label1.Text = contador.ToString();
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}