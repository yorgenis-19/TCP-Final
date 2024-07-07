﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="E_commerce.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvArtDetalle"></asp:GridView>
<div class="container mt-5">
    <div class="row">          
        <div class="col-md-6" style="display: flex; flex-direction: column; justify-content: space-around; color: #000000">
            <h2 style="text-align: center;">Detalle de producto</h2>
            <hr />
            <div style="display: flex; flex-direction: column;">
                <span class="texto-secundario">Nombre:</span>
                <asp:Label ID="lblNombreArticulo" runat="server" Text="" CssClass="font-weight-bold"></asp:Label><br />
                <span class="texto-secundario">Descripción:</span>
                <asp:Label ID="lblDescripcionArticulo" runat="server" Text=""></asp:Label><br />
                <span class="texto-secundario">Categoría: </span>
                <asp:Label ID="lblCategoriaArticulo" runat="server" Text=""></asp:Label><br />
                <span class="texto-secundario">Marca: </span>
                <asp:Label ID="lblMarcaArticulo" runat="server" Text=""></asp:Label><br />
                <span class="texto-secundario">Precio: </span>
                <asp:Label ID="lblPrecioArticulo" runat="server" Text="" CssClass="font-weight-bold"></asp:Label>
                <hr />
                <div>
                    <asp:HiddenField ID="hfArticuloID" runat="server" />
                    <asp:Button ID="btnCarrito" runat="server" OnClick="btnCarrito_Click" Text="Agregar al carrito" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
        <div class="col-md-6" style="height: 60vh;">
            <div id="carouselExample" class="carousel slide" style="height: 100%;" data-bs-ride="carousel">
                <div class="carousel-inner" style="height: 100%;">
                    <asp:Repeater ID="repeaterImagenes" runat="server">
                        <ItemTemplate>
                            <div class='carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>' style="height: 200px;">
                                <div class="imagen-carrusel">
                                    <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("UrlImagen") %>' CssClass="d-block w-100 artImagen" alt="No se pudo cargar la imagen" />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" style="background-color: #123261;" href="#carouselExample" role="button" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </a>
                <a class="carousel-control-next" style="background-color: #123261;" href="#carouselExample" role="button" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </a>
            </div>
        </div>
    </div>
</div>
</asp:Content>
