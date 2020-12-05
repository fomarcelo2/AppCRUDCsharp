<%@ Page Title="" Language="C#" MasterPageFile="~/App/Main.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="AppCRUDCsharp.App.Datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <h1 class="textoH12">CRUD básico a una tabla HTML</h1>

    <main class="estiloMain">
        <div class="contenedorApp">
            <div class="menuApp">
                
                <div class="contenedorBtnApp">
                    <div>
                        <asp:Button ID="btnListarTodo" runat="server" Text="Listar empleados" OnClick="btnListarTodo_Click" class="btnApp" Visible="False" />
                    </div>
                    <div>   
                        <div class="contenedorText">   

                        <asp:TextBox ID="InCodigoaBuscar" runat="server" ></asp:TextBox>
                    </div>
                    </div>
                    
                    
                    <div>   

                        <asp:Button ID="BtnBuscarCodigo" runat="server" Text="Buscar empleado" class="btnApp" OnClick="BtnBuscarCodigo_Click"/>
                    </div>
                    
                    <div>
                        <asp:Label ID="LabelBuscar" Font-Bold="true" runat="server" />
                    </div>


                </div>
                    




            </div>
            <div class="contenedorDatos">
                
                <asp:GridView ID="gvEmpleados" CssClass="gridEmpleados" runat="server" AllowPaging="True" BackBorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="gvEmpleados_PageIndexChanging" DataKeyNames="Codigo" OnRowCommand="gvEmpleados_RowCommand">
                    <Columns>
                        <asp:ButtonField CommandName="Select" Text="Seleccionar" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                
            </div>

        </div>
    </main>
</asp:Content>
