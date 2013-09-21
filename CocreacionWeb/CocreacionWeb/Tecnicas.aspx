<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicas.aspx.cs" Inherits="CocreacionWeb.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <title>Técnicas de cocreación</title>
</head>
<body>
    <header>
        <div class="navbar navbar navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container">
                    <a class="brand" href="#">Cocreación</a>
                    <div class="nav-collapse collapse">
                        <ul class="nav">
                            <li class="active"><a href="#">Técnicas</a></li>
                            <li><a href="#caracteristicas">Características</a></li>
                            <li><a href="#criterios">Criterios</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <form id="formTableTecnicas" runat="server">
        <div class="container">
            <div class="divisor">
                <div>
                    <img class="imagen" src="img/bnr.png" />
                </div>
            </div>
            <div class="page-header">
                <h1>Técnicas<small> de Cocreación</small></h1>
            </div>
            <asp:Panel ID="pnlTablaTecnicas" runat="server">
                <asp:GridView ID="tableTecnicas" runat="server" CssClass="table" DataKeyNames="id_tecnica" AutoGenerateColumns="False" OnRowCancelingEdit="tableTecnicas_RowCancelingEdit" OnRowDeleting="tableTecnicas_RowDeleting" OnRowEditing="tableTecnicas_RowEditing" OnRowUpdating="tableTecnicas_RowUpdating" OnSelectedIndexChanged="tableTecnicas_SelectedIndexChanged">
                    <FooterStyle BackColor="#666666" ForeColor="#ffffff" />
                    <EditRowStyle BackColor="#666666" ForeColor="#ffffff" />
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblIdTecnica" runat="server" Text='<%#Bind("id_tecnica") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="Tecnica">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreTecnica" runat="server" Text='<%#Bind("nombre_tecnica") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditNombreTecnica" runat="server" Text='<%#Bind("nombre_tecnica") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCreateNombreTecnica" runat="server" Text='<%#Bind("nombre_tecnica") %>'></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSeleccionar" runat="server" ToolTip="Ver características de la técnica" CommandName="Select"><i class="icon-search"></i></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEditar" runat="server" ToolTip="Editar técnica" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnAceptarEditar" runat="server" ToolTip="Aceptar" CommandName="Update"><i class="icon-ok icon-white"></i></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnAceptarAgregar" runat="server" ToolTip="Aceptar" CommandName="Update"><i class="icon-ok icon-white"></i></asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar la técnica seleccionada?');" ToolTip="Eliminar técnica"><i class="icon-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnCancelarEditar" runat="server" ToolTip="Cancelar" CommandName="Cancel"><i class="icon-remove icon-white"></i></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="btnCancelarAgregar" runat="server" ToolTip="Cancelar" OnClick="btnCancelarAgregar_Click"><i class="icon-remove icon-white"></i></asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<div style="float: right;">
                    <asp:LinkButton ID="btnAgregar" CssClass="btn span2" runat="server" OnClick="btnAgregar_Click">Agregar <i class="icon-plus-sign"></i></asp:LinkButton>
                </div>--%>
            </asp:Panel>
            <asp:Panel ID="pnlTecnicaDetalle" runat="server">
                <div class="divisor">
                    <div class="page-header">
                        <h1><small><asp:Label ID="lblNombreTecnicaDetalle" runat="server" Text="Titulo de la Tecnica"></asp:Label></small></h1>
                    </div>
                </div>
                <table class="cienPorciento">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDescripcionDetalle" runat="server" Text="Descripcion de la técnica"></asp:Label> 
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Pasos"></asp:Label></td>
                        <td>
                            <asp:Panel ID="pnlPasos" runat="server">
                            </asp:Panel>
                            <%--<asp:LinkButton ID="btnNuevoPaso" runat="server" ToolTip="Crear nuevo paso"><i class="icon-plus"></i></asp:LinkButton>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Links"></asp:Label></td>
                        <td>
                            <asp:Panel ID="PanelLinks" runat="server">
                            </asp:Panel>
                            <%--<asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Agregar nuevo link"><i class="icon-plus"></i></asp:LinkButton></td>--%>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
    <footer style="height: 100px;">
    </footer>
</body>
</html>
