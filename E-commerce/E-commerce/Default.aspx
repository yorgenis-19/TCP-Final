<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_commerce.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            min-height: 80vh;
            padding: 20px;
        }
        .row {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }
        .col {
            flex: 0 0 calc(33.333% - 20px);
            max-width: calc(33.333% - 20px);
            box-sizing: border-box;
            margin: 10px;
        }
        .card {
            height: 550px;
            width: 100%;
            overflow: hidden;
            border-radius: 15px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            transition: box-shadow 0.3s ease, transform 0.3s ease;
            position: relative;
        }
        .card:hover {
            box-shadow: 0 8px 16px rgba(0,0,0,0.2);
            transform: scale(1.05);
        }
        .card img {
            height: 550px;
            width: 100%;
            object-fit: cover;
            transition: transform 0.5s ease;
        }
        .card img:hover {
            transform: scale(1.1);
        }
        .lblNombre {
            color: white;
            font-size: 30px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            text-align: center;
            display: block;
            padding: 10px 0;
            font-weight: 700;
            text-shadow: 0 0 6px 0 rgb(0, 0, 0);
            animation: changeColor 1s infinite alternate;
        }
        @keyframes changeColor {
            0% {
                color: #fff;
            }
            100% {
                color: black;
            }
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col">
                <div class="card">
                    <a href="Articulo.aspx?nombre=Remeras">
                        <img src="Imagenes/remeras.jpg" class="card-img-top" alt="Imagen del artículo" />
                        <asp:Label ID="lblRemeras" CssClass="lblNombre" Text="REMERAS" runat="server" />
                    </a>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <a href="Articulo.aspx?nombre=Pantalones">
                        <img src="Imagenes/Pantalones.jpg" class="card-img-top" alt="Imagen del artículo" />
                        <asp:Label ID="lblPantalones" CssClass="lblNombre" Text="PANTALONES" runat="server" />
                    </a>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <a href="Articulo.aspx?nombre=Sweater">
                        <img src="Imagenes/sweater.jpg" class="card-img-top" alt="Imagen del artículo" />
                        <asp:Label ID="lblSweater" CssClass="lblNombre" Text="SWEATER" runat="server" />
                    </a>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <a href="Articulo.aspx?nombre=Buzos">
                        <img src="Imagenes/buzos.jpg" class="card-img-top" alt="Imagen del artículo" />
                        <asp:Label ID="lblBuzos" CssClass="lblNombre" Text="BUZOS" runat="server" />
                    </a>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <a href="Articulo.aspx?nombre=Camperas">
                        <img src="Imagenes/camperas.jpg" class="card-img-top" alt="Imagen del artículo" />
                        <asp:Label ID="lblCamperas" CssClass="lblNombre" Text="CAMPERAS" runat="server" />
                    </a>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <a href="Articulo.aspx?nombre=Gafas">
                        <img src="Imagenes/Gafas.jpg" class="card-img-top" alt="Imagen del artículo" />
                        <asp:Label ID="lblGafas" CssClass="lblNombre" Text="GAFAS" runat="server" />
                    </a>
                </div>
            </div>        
        </div>
    </div>
</asp:Content>
