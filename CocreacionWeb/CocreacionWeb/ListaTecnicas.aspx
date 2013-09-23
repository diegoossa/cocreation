<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaTecnicas.aspx.cs" Inherits="CocreacionWeb.ListaTecnicas" %>

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
                            <li class="active"><a>Lista de Técnicas</a></li>
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

        </div>
    </form>
    <footer style="height: 100px;">
    </footer>
</body>
</html>
