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
        <div class="navbar navbar-fixed-top">
            <div class="navbar-inner">
                <div class="container">
                    <a class="brand">Cocreación</a>
                    <div class="nav-collapse collapse">
                        <ul class="nav">
                            <li class="active"><a>Administrar Técnicas</a></li>
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
                <asp:GridView ID="gvTecnicas" runat="server" CssClass="table" DataKeyNames="id_tecnica" AutoGenerateColumns="False" OnSelectedIndexChanged="tableTecnicas_SelectedIndexChanged">
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
                        </asp:TemplateField>
                    </Columns>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnSeleccionar" runat="server" ToolTip="Ver características de la técnica" CommandName="Select"><i class="icon-pencil"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<div style="float: right;">
                    <asp:LinkButton ID="btnAgregar" CssClass="btn span2" runat="server" OnClick="btnAgregar_Click">Agregar <i class="icon-plus-sign"></i></asp:LinkButton>
                </div>--%>
            </asp:Panel>
            <asp:Panel ID="pnlTecnicaDetalle" runat="server" Visible="False">
                <div style="float: right;">
                    <asp:LinkButton ID="btnAtras" runat="server" ToolTip="Regresar" OnClick="btnAtras_Click"><img src="img/atras.png" /></asp:LinkButton>
                </div>
                <div class="offset1">
                    <h3>
                        <asp:Label ID="lblNombreTecnicaDetalle" runat="server" Text="Titulo de la Tecnica"></asp:Label>
                        <asp:TextBox ID="txtNombreTecnicaDetalle" runat="server" Visible="False" TextMode="MultiLine" Width="600px"></asp:TextBox>
                        <asp:LinkButton ID="btnChangeTitle" runat="server" CssClass="btn" ToolTip="Cambiar nombre de la técnica" OnClick="btnChangeTitle_Click"><i class="icon-pencil"></i></asp:LinkButton></h3>
                    <br />
                </div>
                <div class="offset1">
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
                        <asp:TextBox ID="txtDescripcionDetalle" runat="server" Height="100px" TextMode="MultiLine" Visible="False" Width="500px"></asp:TextBox>
                        <asp:LinkButton ID="btnChangeDescription" runat="server" CssClass="btn" ToolTip="Cambiar descripción de la técnica" OnClick="btnChangeDescription_Click"><i class="icon-pencil"></i></asp:LinkButton>
                    </h4>

                    <asp:Label ID="lblDescripcionDetalle" runat="server" Text="Descripcion de la técnica"></asp:Label>
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="Pasos"></asp:Label>
                        <asp:LinkButton ID="btnNuevoPaso" runat="server" CssClass="btn" ToolTip="Agregar nuevo paso" OnClick="btnNuevoPaso_Click"><i class="icon-plus"></i></asp:LinkButton>
                    </h4>
                    <asp:Panel ID="pnlPasos" runat="server">
                        <asp:GridView ID="gvPasos" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvPasos_RowCancelingEdit" OnRowDeleting="gvPasos_RowDeleting" OnRowEditing="gvPasos_RowEditing">
                            <FooterStyle BackColor="#666666" ForeColor="#ffffff" />
                            <EditRowStyle BackColor="#666666" ForeColor="#ffffff" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaso" runat="server" Text='<%#Bind("paso") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPasoEdit" runat="server" Text='<%#Bind("paso") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtPasoCreate" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriterio" runat="server" Text='<%#Bind("criterio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlCriteriosEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlCriteriosCreate" runat="server"></asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditar" runat="server" ToolTip="Editar paso" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="Links"></asp:Label>
                        <asp:LinkButton ID="btnNuevoLink" runat="server" CssClass="btn" ToolTip="Agregar nuevo link" OnClick="btnNuevoLink_Click"><i class="icon-plus"></i></asp:LinkButton>
                    </h4>
                    <asp:Panel ID="pnlLinks" runat="server">
                        <asp:GridView ID="gvLinks" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvLinks_RowCancelingEdit" OnRowDeleting="gvLinks_RowDeleting" OnRowEditing="gvLinks_RowEditing">
                            <FooterStyle BackColor="#666666" ForeColor="#ffffff" />
                            <EditRowStyle BackColor="#666666" ForeColor="#ffffff" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLink" runat="server" Text='<%#Bind("link") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLinkEdit" runat="server" Text='<%#Bind("link") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtLinkEdit" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditar" runat="server" ToolTip="Editar paso" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div>
                    <asp:LinkButton ID="lblAceptar" runat="server" CssClass="btn" Style="float: right;" ToolTip="Agregar nuevo link" OnClick="lblAceptar_Click">Aceptar <i class="icon-ok"></i></asp:LinkButton>
                </div>
            </asp:Panel>
        </div>
    </form>
    <footer style="height: 100px;">
    </footer>
</body>
</html>
