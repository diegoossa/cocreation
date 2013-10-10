<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodasLasTecnicas.aspx.cs" Inherits="CocreacionWeb.TodasLasTecnicas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                            <li class="active"><a>Todas las Técnicas</a></li>
                            <li><a href="Tecnicas.aspx">Administrar Técnicas</a></li>
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
                <h1>Lista de Técnicas<small> de Cocreación</small></h1>
            </div>
                <div style="float: right;">
                    <asp:LinkButton ID="btnSiguiente" runat="server" ToolTip="Regresar" OnClick="btnSiguiente_Click"><img src="img/siguiente.png" /></asp:LinkButton>
                </div>
                <div style="float: left;">
                    <asp:LinkButton ID="btnAnterior" runat="server" ToolTip="Regresar" OnClick="btnAnterior_Click"><img src="img/anterior.png" /></asp:LinkButton>
                </div>

            <br />
            <div>
                <h3>
                    &nbsp;</h3>
                <h3>
                    <asp:Label ID="txtTitulo" runat="server" Text="Label"></asp:Label>
                </h3>
            </div>


            <asp:Label ID="txtDescripcion" runat="server" Text="Label"></asp:Label>
            <h3>
                <br />
            </h3>
            <asp:GridView ID="gvPasos" CssClass="table" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay pasos">
                <Columns>
                    <asp:TemplateField HeaderText="Paso">
                        <ItemTemplate>
                            <asp:Label ID="lblPaso" runat="server" Text='<%#Bind("paso")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <Columns>
                    <asp:TemplateField HeaderText="Responsable">
                        <ItemTemplate>
                            <asp:Label ID="lblResposable" runat="server" Text='<%#Bind("criterio")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:GridView ID="gvLinks" CssClass="table" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay Links">
                <Columns>
                    <asp:TemplateField HeaderText="Link">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" PostBackUrl='<%#Bind("link")%>' Text='<%#Bind("link")%>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <footer style="height: 100px;">
    </footer>
</body>
</html>
