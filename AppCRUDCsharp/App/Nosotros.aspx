<%@ Page Title="" Language="C#" MasterPageFile="~/App/Main.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="AppCRUDCsharp.App.Nosotros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="textoH1">Nuestro equipo de trabajo</h1>

    <main class="estiloMain">
        <div class="contenedorCards">
            <div class="cards">
                <div>
                    <img class="picProgramador" src="img/programador1.jpg" alt="" srcset="">
                </div>
                <div>
                    <p class="textoResaltado">Nombre </p>
                    <p class="textoNormal">Gal Galot</p>
                    <p class="textoResaltado">Correo </p>
                    <p class="textoNormal">Gal@email.com</p>
                </div>
            </div>

        </div>
</asp:Content>
