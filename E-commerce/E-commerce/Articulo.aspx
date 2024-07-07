<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="E_commerce.Articulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card img {
            height: 250px;
            width: 300px;
            margin: 0 auto;
        }
        .card-title, h1 {
            text-align: center;
        }
        .container {
            display: flex;
        }
        .titulo-catalogo {
            text-align: center;
            font-size: 2rem;
            color: #0000;
            margin-bottom: 30px;
            text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.2);
        }
        .filter-container {
            width: 25%;
            padding: 20px;
            border-right: 1px solid #ddd;
        }
        .content-container {
            width: 75%;
            padding: 20px;
        }
        .filter-group {
            margin-bottom: 20px;
        }
        .filter-group label {
            font-weight: bold;
        }
        .filter-group .checkbox-list {
            list-style: none;
            padding: 0;
        }
        .filter-group .checkbox-list li {
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" CssClass="lblArticulo" Text="" runat="server" />
    <asp:Label ID="lblArticulo" CssClass="lblArticulo" Text="" runat="server" />
    <div class="container">
        <div class="filter-container">
            <div class="filter-group">
                <label>Marcas</label>
                <asp:CheckBoxList ID="checkboxMarca" runat="server" CssClass="checkbox-list">
                </asp:CheckBoxList>
            </div>
            <div class="filter-group">
                <label>Tallas</label>
                <asp:CheckBoxList ID="checkboxTalla" runat="server" CssClass="checkbox-list">
                </asp:CheckBoxList>
            </div>
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
        </div>
        <div class="content-container">
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater runat="server" ID="repeaterArticulos" OnItemCommand="repeaterArticulos_ItemCommand">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card">
                                <img src="<%# ((List<Dominio.Imagen>)Eval("listaImagenes"))[0].UrlImagen %>" class="card-img-top" alt="Imagen del artículo">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                                    <p class="card-text">Descripción: <%# Eval("Descripcion") %></p>
                                    <p class="card-text">Precio: <%# Eval("Precio") %></p>
                                    <asp:Button ID="Button1" runat="server" CommandName="VerDetalle" CommandArgument='<%# Eval("idArticulo") %>' Text="Ver detalle" CssClass="btn btn-primary" />
                                    <asp:Button ID="Button2" runat="server" CommandName="AgregarAlCarrito" CommandArgument='<%# Eval("idArticulo") %>' Text="Agregar al carrito" CssClass="btn btn-success" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
