﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoCompras.aspx.cs" Inherits="E_commerce.CarritoCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .titulo-catalogo {
        text-align: center;
        font-size: 2rem;
        color: #000000;
        margin-top: 15px;
        margin-bottom: 15px;
        text-shadow: 2px 2px 2px rgba(0, 0, 0, 0.2);
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="titulo-catalogo">Carrito de compras</h1>

 <table class="table table-bordered">
     <thead>
         <tr>
             <th class="d-none">Id</th>
             <th>Nombre</th>
             <th>Descripción</th>
             <th>Marca</th>
             <th>Categoría</th>
             <th>Precio</th>
             <th>Talla</th>                
             <th>Cantidad</th>
             <th>Eliminar</th>
         </tr>
     </thead>
     <tbody>
         <asp:Repeater ID="repeaterCarrito" runat="server">
             <ItemTemplate>
                 <tr>
                     <td class="d-none" name="id"><%# Eval("idArticulo") %></td>                       
                     <td><%# Eval("NombreArticulo") %></td>
                     <td><%# Eval("Descripcion") %></td>
                     <td><%# Eval("Marca") %></td>
                     <td><%# Eval("Categoria") %></td>
                     <td><%# Eval("Precio") %></td>
                     <td><%# Eval("Talle") %></td>
                     <!--<td></td>-->
                     <td>
                         <asp:Button ID="btnDisminuirCantidad" CssClass="btn btn-info" runat="server" Text="-" OnClick="btnDisminuirCantidad_Click" CommandArgument='<%# Eval("idArticulo") %>' CommandName="disminuirCantidad" />
                         <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                         <asp:Button ID="btnAumentarCantidad" CssClass="btn btn-info" runat="server" Text="+" OnClick="btnAumentarCantidad_Click" CommandArgument='<%# Eval("idArticulo") %>' CommandName="aumentarCantidad" />
                     </td>
                     <td>
                         <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Quitar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("idArticulo") %>' CommandName="idArticulo" /></td>

                 </tr>
             </ItemTemplate>
         </asp:Repeater>
     </tbody>
     <tfoot>
         <tr>
             <td>Total</td>
             <td>
                 <asp:Label ID="lblPrecioTotal" runat="server" Text="0"></asp:Label></td>
             <td>    
                 <asp:Button ID="btnComprar" OnClick="btnComprar_Click" runat="server"  Text="Comprar" CssClass="btn btn-success" />
              </td>

         </tr>
     </tfoot>
 </table>
</asp:Content>
