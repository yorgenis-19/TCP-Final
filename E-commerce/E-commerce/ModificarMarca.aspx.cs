using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class ModificarMarca : System.Web.UI.Page
    {
        public List<Dominio.Marca> ListMarcas = new List<Dominio.Marca>();
        private MarcaNegocio articulonegocio = new MarcaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListMarcas = articulonegocio.listarMarcas();
                repeaterMarca.DataSource = ListMarcas;
                repeaterMarca.DataBind();
            }

        }

        protected void repeaterMarca_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "idModificar")
            {
                string articuloID = e.CommandArgument.ToString();
                Response.Redirect($"NuevaMarca.aspx?id={articuloID}");
            }
        }
    }
}