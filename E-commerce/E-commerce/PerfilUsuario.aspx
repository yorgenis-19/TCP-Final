<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="E_commerce.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .contenedor {
        width: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
        position: relative;
    }

        .contenedor > h1 {
            align-content: center;
        }

    .form-contenedor {
        width: 100%;
        max-width: 950px;
        background: linear-gradient(to top, #30cfd0 0%, #330867 100%);
        border-radius: 15px;
        color: white;
        padding: 50px 60px 70px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contenedor">
    <div class="form-contenedor">
        <h1>Perfil</h1>
        <div class="row g-3">
            <div class="col-md-6">
                <label for="inputEmail4" class="form-label">Nombre</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtNombreUsuario" placeholder="Nombre" />
            </div>
            <div class="col-md-6">
                <label for="inputPassword4" class="form-label">Apellido</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtApellido" placeholder="Apellido" />
            </div>
            <div class="col-12">
                <label for="inputAddress" class="form-label">Email</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtEmail" placeholder="Email" />
            </div>
            <div class="col-12">
                <label for="inputAddress2" class="form-label">Telefono</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtTelefono" placeholder="Telefono" />
            </div>
            
            <div class="col-12">
                <button type="submit" class="btn btn-primary">Editar</button>
            </div>
        </div>
    </div>
</section>

</asp:Content>
