using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class DetallePedido : System.Web.UI.Page
    {
        public List<Dominio.DetallePedido> ListPedido = new List<Dominio.DetallePedido>();
        private PedidoNegocio pedidonegocio = new PedidoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListPedido = pedidonegocio.listarDetallePedido(int.Parse(Request.QueryString["id"]));
            repeaterDetallesPedido.DataSource = ListPedido;
            repeaterDetallesPedido.DataBind();

        }
    }
}