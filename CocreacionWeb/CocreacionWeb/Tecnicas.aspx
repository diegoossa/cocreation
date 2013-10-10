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
                            <li><a href="TodasLasTecnicas.aspx">Lista Técnicas</a></li>
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
                <asp:GridView ID="gvTecnicas" runat="server" CssClass="table" DataKeyNames="id_tecnica" AutoGenerateColumns="False" OnSelectedIndexChanged="tableTecnicas_SelectedIndexChanged" OnRowDeleting="gvTecnicas_RowDeleting">
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
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEliminar" runat="server" ToolTip="Eliminar técnica" CommandName="Delete" OnClientClick="return confirm('¿Está seguro de eliminar la Tecnica?\nSe eliminará la técnica y todas sus características, pasos y links')"><i class="icon-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div style="float: right;">
                    <asp:LinkButton ID="btnAgregar" CssClass="btn span2" runat="server" OnClick="btnAgregar_Click">Nueva Técnica <i class="icon-plus-sign"></i></asp:LinkButton>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlTecnicaDetalle" runat="server" Visible="False">
                <div style="float: right;">
                    <asp:LinkButton ID="btnAtras" runat="server" ToolTip="Regresar" OnClick="btnAtras_Click"><img src="img/atras.png" /></asp:LinkButton>
                </div>
                <div>
                    <h3>
                        <asp:Label ID="lblNombreTecnicaDetalle" runat="server" Text="Titulo de la Tecnica"></asp:Label>
                        <asp:TextBox ID="txtNombreTecnicaDetalle" runat="server" Visible="False" TextMode="MultiLine" Width="600px"></asp:TextBox>
                        <asp:LinkButton ID="btnChangeTitle" runat="server" CssClass="btn" ToolTip="Cambiar nombre de la técnica" OnClick="btnChangeTitle_Click"><i class="icon-pencil"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnAceptarCambioTitulo" runat="server" CssClass="btn" ToolTip="Aceptar" OnClick="btnAceptarCambioTitulo_Click" Visible="false"><i class="icon-ok"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnCancelarCambioTitulo" runat="server" CssClass="btn" ToolTip="Cancelar" OnClick="btnCancelarCambioTitulo_Click" Visible="false"><i class="icon-remove"></i></asp:LinkButton>
                    </h3>
                    <br />
                </div>
                <div>
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
                        <asp:TextBox ID="txtDescripcionDetalle" runat="server" Height="100px" TextMode="MultiLine" Visible="False" Width="500px"></asp:TextBox>
                        <asp:LinkButton ID="btnChangeDescription" runat="server" CssClass="btn" ToolTip="Cambiar descripción de la técnica" OnClick="btnChangeDescription_Click"><i class="icon-pencil"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnAceptarCambioDescripcion" runat="server" CssClass="btn" ToolTip="Aceptar" Visible="false" OnClick="btnAceptarCambioDescripcion_Click"><i class="icon-ok"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnCancelarCambioDescripcion" runat="server" CssClass="btn" ToolTip="Cancelar" Visible="false" OnClick="btnCancelarCambioDescripcion_Click"><i class="icon-remove"></i></asp:LinkButton>
                    </h4>
                    <asp:Label ID="lblDescripcionDetalle" runat="server" Text="Descripcion de la técnica"></asp:Label>

                    <div>
                        <br />
                    </div>
                    <h4>
                        <asp:Label ID="Label4" runat="server" Text="Características"></asp:Label>
                        <asp:LinkButton ID="lbNuevaCaracteristica" runat="server" CssClass="btn" ToolTip="Agregar nueva característica" OnClick="lbNuevaCaracteristica_Click"><i class="icon-plus"></i></asp:LinkButton>
                    </h4>
                    <asp:Panel ID="pnlCaracteristica" runat="server">
                        <asp:GridView ID="gvCaracteristica" DataKeyNames="id_relacion" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvCaracteristica_RowCancelingEdit" OnRowDataBound="gvCaracteristica_RowDataBound" OnRowDeleting="gvCaracteristica_RowDeleting" OnRowEditing="gvCaracteristica_RowEditing" OnRowUpdating="gvCaracteristica_RowUpdating">
                            <FooterStyle BackColor="#666666" ForeColor="#ffffff" />
                            <EditRowStyle BackColor="#666666" ForeColor="#ffffff" />
                            <Columns>
                                <asp:TemplateField HeaderText="Caracteristica">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCaracteristica" runat="server" Text='<%#Bind("caracteristica") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCaracteristica" runat="server" Text='<%#Bind("caracteristica") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCaracteristicaEdit" OnSelectedIndexChanged="ddlCaracteristicaEdit_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:DropDownList ID="ddlCaracteristicaCreate" OnSelectedIndexChanged="ddlCaracteristicaCreate_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField HeaderText="Criterio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriterio" runat="server" Text='<%#Bind("criterio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblGrupo" runat="server" Visible="false" Text='<%#Bind("grupo") %>'></asp:Label>
                                        <asp:Label ID="lblCriterio" runat="server" Text='<%#Bind("criterio") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCriterioEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblGrupo" runat="server" Visible="false" Text='<%#Bind("grupo") %>'></asp:Label>
                                        <asp:DropDownList ID="ddlCriterioCreate" runat="server"></asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditarCaracteristica" runat="server" ToolTip="Editar Caracteristica" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnAceptarEdicionCaracteristica" runat="server" ToolTip="Aceptar Edición" CommandName="Update"><i class="icon-ok"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnAceptarCreacionCaracteristica" runat="server" ToolTip="Aceptar Creación" OnClick="btnAceptarCreacionCaracteristica_Click"><i class="icon-ok"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteCaracteristica" runat="server" ToolTip="Eliminar Caracteristica" CommandName="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar la Característica?')"><i class="icon-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnCancelEditarCaracteristica" runat="server" ToolTip="Cancelar Edición" CommandName="Cancel"><i class="icon-remove"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnCancelCreateCaracteristica" runat="server" ToolTip="Cancelar Creación" OnClick="btnCancelCreateCaracteristica_Click"><i class="icon-remove"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <div>
                        <br />
                    </div>
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="Pasos"></asp:Label>
                        <asp:LinkButton ID="btnNuevoPaso" runat="server" CssClass="btn" ToolTip="Agregar nuevo paso" OnClick="btnNuevoPaso_Click"><i class="icon-plus"></i></asp:LinkButton>
                    </h4>
                    <asp:Panel ID="pnlPasos" runat="server">
                        <asp:GridView ID="gvPasos" DataKeyNames="id_paso" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvPasos_RowCancelingEdit" OnRowDeleting="gvPasos_RowDeleting" OnRowEditing="gvPasos_RowEditing" OnRowDataBound="gvPasos_RowDataBound" OnRowUpdating="gvPasos_RowUpdating" EmptyDataText="No hay pasos especificados">
                            <FooterStyle BackColor="#666666" ForeColor="#ffffff" />
                            <EditRowStyle BackColor="#666666" ForeColor="#ffffff" />
                            <Columns>
                                <asp:TemplateField HeaderText="Paso">
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
                                <asp:TemplateField HeaderText="Resposable">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCriterio" runat="server" Text='<%#Bind("criterio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCriterio" runat="server" Text='<%#Bind("criterio") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCriteriosEdit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblCriterio" runat="server" Text='<%#Bind("criterio") %>' Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCriteriosCreate" runat="server"></asp:DropDownList>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditarPaso" runat="server" ToolTip="Editar paso" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnAceptarEdicionPaso" runat="server" ToolTip="Aceptar Edición" CommandName="Update"><i class="icon-ok"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnAceptarCreacionPaso" runat="server" ToolTip="Aceptar Creación" OnClick="btnAceptarCreacionPaso_Click"><i class="icon-ok"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeletePaso" runat="server" ToolTip="Eliminar paso" CommandName="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el paso?')"><i class="icon-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnCancelEditarPaso" runat="server" ToolTip="Cancelar Edición" CommandName="Cancel"><i class="icon-remove"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnCancelCreatePaso" runat="server" ToolTip="Cancelar Creación" OnClick="btnCancelCreatePaso_Click"><i class="icon-remove"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="Links"></asp:Label>
                        <asp:LinkButton ID="btnNuevoLink" runat="server" CssClass="btn" ToolTip="Agregar nuevo link" OnClick="btnNuevoLink_Click"><i class="icon-plus"></i></asp:LinkButton>
                    </h4>
                    <asp:Panel ID="pnlLinks" runat="server">
                        <asp:GridView ID="gvLinks" DataKeyNames="id_link" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvLinks_RowCancelingEdit" OnRowDeleting="gvLinks_RowDeleting" OnRowEditing="gvLinks_RowEditing" OnRowUpdating="gvLinks_RowUpdating" EmptyDataText="No hay links especificados">
                            <FooterStyle BackColor="#666666" ForeColor="#ffffff" />
                            <EditRowStyle BackColor="#666666" ForeColor="#ffffff" />
                            <Columns>
                                <asp:TemplateField HeaderText="Link">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLink" runat="server" Text='<%#Bind("link") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLinkEdit" runat="server" Text='<%#Bind("link") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtLinkCreate" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditarLink" runat="server" ToolTip="Editar link" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnAceptarEdicionLink" runat="server" ToolTip="Aceptar Edición" CommandName="Update"><i class="icon-ok"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnAceptarCreacionLink" runat="server" ToolTip="Aceptar Creación" OnClick="btnAceptarCreacionLink_Click"><i class="icon-ok"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDeleteLink" runat="server" ToolTip="Eliminar link" CommandName="Delete" OnClientClick="return confirm('¿Está seguro que desea eliminar el link?')"><i class="icon-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnCancelEditarLink" runat="server" ToolTip="Cancelar Edición" CommandName="Cancel"><i class="icon-remove"></i></asp:LinkButton>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="btnCancelCreateLink" runat="server" ToolTip="Cancelar Creación" OnClick="btnCancelCreateLink_Click"><i class="icon-remove"></i></asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlNuevaTecnica" runat="server" Visible="false">
                <div style="float: right;">
                    <asp:LinkButton ID="LinkButton1" runat="server" ToolTip="Regresar" OnClick="btnAtrasNueva_Click"><img src="img/atras.png" /></asp:LinkButton>
                </div>
                <div>
                    <h4>
                        <asp:Label ID="lblTituloNueva" runat="server" Text="Titulo de la Tecnica: "></asp:Label>
                        <asp:TextBox ID="txtTituloNueva" CausesValidation="true" runat="server" TextMode="MultiLine" Width="600px"></asp:TextBox>
                        <asp:Label ID="errorTitulo" runat="server" Text="*"></asp:Label>
                    </h4>
                    <br />
                </div>
                <div>
                    <h4>
                        <asp:Label ID="lblDescripcionNueva" runat="server" Text="Descripción: "></asp:Label>
                        <asp:TextBox ID="txtDescripcionNueva" CausesValidation="true" runat="server" Height="100px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                        <asp:Label ID="Error2" runat="server" Text="*"></asp:Label>
                    </h4>
                    <div>
                        <br />
                    </div>
                </div>
                <div>
                    <asp:LinkButton ID="lblAceptar" runat="server" Text="submit" CssClass="btn" Style="float: right;" OnClick="lblAceptar_Click">Aceptar <i class="icon-ok"></i></asp:LinkButton>
                </div>
            </asp:Panel>
        </div>
        <footer style="height: 100px;">
        </footer>
    </form>
</body>
</html>
