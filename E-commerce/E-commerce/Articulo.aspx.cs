using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Articulo : System.Web.UI.Page
    {
        public List<Dominio.Articulo> ListArtculos = new List<Dominio.Articulo>();
        private ArticuloNegocio articulonegocio = new ArticuloNegocio();

        public List<Dominio.Marca> ListMarca = new List<Dominio.Marca>();
        private MarcaNegocio marcanegocio = new MarcaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nombreArticulo = Request.QueryString["nombre"];
                if (!string.IsNullOrEmpty(nombreArticulo))
                {
                                     
                    ListArtculos = articulonegocio.buscarPorCategoria(nombreArticulo);
                    repeaterArticulos.DataSource = ListArtculos;
                    repeaterArticulos.DataBind();

               
                }
                
            }

        }

        protected void repeaterArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                string articuloID = e.CommandArgument.ToString();
                Response.Redirect($"DetalleArticulo.aspx?id={articuloID}");
            }
            if (e.CommandName == "AgregarAlCarrito")
            {
                string idArticulo = e.CommandArgument.ToString();
                AgregarAlCarrito(idArticulo);
            }

        }
        private void AgregarAlCarrito(string idArticulo)
        {
            if (Session["CarritoCompras"] == null)
            {
                Session["CarritoCompras"] = new List<Dominio.Articulo>();
            }

            int id = Convert.ToInt32(idArticulo);
            Dominio.Articulo articulo = articulonegocio.buscarPorID(id);
            articulo.Cantidad = 1;

            if (articulo != null)
            {
                List<Dominio.Articulo> carrito = Session["CarritoCompras"] as List<Dominio.Articulo>;

                carrito.Add(articulo);
                Session["CarritoCompras"] = carrito;

                List<Dominio.Articulo> carritoActual = (List<Dominio.Articulo>)Session["CarritoCompras"];
                int cantArticulos = carritoActual.Count;

                Master masterPage = (Master)this.Master;
                masterPage.ActualizarContadorCarrito(cantArticulos);

                // Redirigir a la página del carrito de compras o mostrar un mensaje de éxito
                //Response.Redirect("CarritoCompras.aspx");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<int> marcasSeleccionadas = new List<int>();
            foreach (ListItem item in checkboxMarca.Items)
            {
                if (item.Selected)
                {
                    marcasSeleccionadas.Add(int.Parse(item.Value));
                }
            }

            List<int> tallasSeleccionadas = new List<int>();
            foreach (ListItem item in checkboxTalla.Items)
            {
                if (item.Selected)
                {
                    tallasSeleccionadas.Add(int.Parse(item.Value));
                }
            }

            ListArtculos = articulonegocio.FiltrarArticulos(lblArticulo.Text, marcasSeleccionadas, tallasSeleccionadas);
            repeaterArticulos.DataSource = ListArtculos;
            repeaterArticulos.DataBind();
        }
    }
}