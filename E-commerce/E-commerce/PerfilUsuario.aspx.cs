using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Dominio.Usuario usuario = (Dominio.Usuario)Session["usuario"];
                UsuarioNegocio negociousuario = new UsuarioNegocio();
                usuario = negociousuario.Listar(usuario.idUsuario);
                txtNombreUsuario.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtEmail.Text = usuario.Mail;
                txtTelefono.Text = usuario.Telefono;
            }

        }
    }
}