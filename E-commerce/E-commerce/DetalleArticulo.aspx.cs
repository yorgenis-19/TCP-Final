﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        private ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string articuloID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(articuloID))
                {
                    CargarDetalleArticulo(articuloID);
                }
            }

        }
        private int ObtenerElIdDelArticuloDesdeLaURL()
        {
            int idArticulo = -1;
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                }
            }
            return idArticulo;
        }
        private void CargarDetalleArticulo(string articuloID)
        {
            ArticuloNegocio articuloService = new ArticuloNegocio();
            Dominio.Articulo articulo = articuloService.buscarPorID(int.Parse(articuloID));
            lblNombreArticulo.Text = articulo.nombreArticulo;
            lblDescripcionArticulo.Text = articulo.descripcion;
            lblCategoriaArticulo.Text = articulo.categoria.nombreCategoria;
            lblMarcaArticulo.Text = articulo.marca.nombreMarca;
            lblPrecioArticulo.Text = articulo.precio.ToString();

            repeaterImagenes.DataSource = articulo.listaImagenes.Select(i => new { UrlImagen = i.UrlImagen });
            repeaterImagenes.DataBind();
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CarritoCompras"] == null)
                {
                    List<Dominio.Articulo> Newcarrito = new List<Dominio.Articulo>();
                    Session["CarritoCompras"] = Newcarrito;
                }
            }
            int id = ObtenerElIdDelArticuloDesdeLaURL();
            if (id > 0)
            {
                Dominio.Articulo articulo = articuloNegocio.buscarPorID(id);
                articulo.Cantidad = 1;

                if (articulo != null)
                {
                    List<Dominio.Articulo> carrito = Session["CarritoCompras"] as List<Dominio.Articulo>;
                    if (carrito == null)
                    {
                        carrito = new List<Dominio.Articulo>();
                    }
                    carrito.Add(articulo);
                    Session["CarritoCompras"] = carrito;

                    List<Dominio.Articulo> carritoActual = (List<Dominio.Articulo>)Session["CarritoCompras"];
                    int cantArticulos = carritoActual.Count;

                    Master masterPage = (Master)this.Master;
                    masterPage.ActualizarContadorCarrito(cantArticulos);
                }
            }
        }
    }
}