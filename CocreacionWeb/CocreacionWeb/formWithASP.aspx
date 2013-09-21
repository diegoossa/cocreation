<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formWithASP.aspx.cs" Inherits="CocreacionWeb.form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Elección de una técnica de cocreacion</title>
    <meta name="description" content="Gracias a este software web podemos elegir la técnica de cocreación más apta para su proyecto o problema específico, basándonos en algoritmos de lógica difusa" />
    <meta name="author" content="Diego Ossa" />
    <link href="css/impress.css" rel="stylesheet" />
    <script src="js/script.js"></script>
    
</head>
<body class="impress-not-supported">
    <form runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="fallback-message">
            <p>Su navegador <b>no soporta las animaciones</b>, la interfaz será mostrada de forma secuencial.</p>
            <p>Para una mejor experiencia puede usar las últimas versiones de los navegadores: <a href="https://www.google.com/intl/es/chrome/browser/?hl=es"><b>Chrome</b></a>, <a href="http://www.apple.com/es/safari/"><b>Safari</b></a> o <a href="http://www.mozilla.org/es-ES/firefox/new/"><b>Firefox</b></a></p>
        </div>
        <div id="impress">
            <div class="step centered" data-x="0" data-y="0" data-z="0">
                <img src="img/logo_cocreacion.png" width="300" height="414" />
                <p class="content">Software para la elección de técnicas de cocreación usando algoritmos de lógica difusa</p>
                <a class="next" href="javascript:impress().next();">
                    <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
            </div>

            <div class="step centered" data-x="0" data-y="0" data-z="0" data-rotate-y="90">
                <img src="img/udem.png" width="300" height="181" />
                <p>Por: Diego Alejandro Ossa</p>
                <p>Docente: Liliana González Palacio</p>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev" /></a>
                </div>
            </div>

            <div class="step" data-x="5000" data-y="0" data-z="-5000" data-rotate-y="180">
                <h1 style="color: #09C;">Objetivos:</h1>
                <p class="content">¿Porqué busca implementar una técnica de cocreación?</p>
                <asp:Panel ID="pnl_problema" runat="server"></asp:Panel>
                <div runat="server" class="error" id="error_problema">
                    <p>Debe seleccionar mínimo una opción.</p>
                </div>
                <div class="footer-options">                                         
                    <a id="A1" class="next" runat="server" onserverclick="checkProblem">
                        <img src="img/siguiente.png" width="99" height="40" alt="next"></a>
                    
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev"></a>
                </div>
            </div>


            <div class="step" data-x="10000" data-y="0" data-z="-10000" data-rotate-y="0">
                <h1 style="color: #C30;">Fase donde se aplica la técnica:</h1>
                <p class="content">¿Qué tan avanzado se encuentra su proyecto?</p>
                <asp:Panel ID="pnl_fase" runat="server"></asp:Panel>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="check_fase()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next"></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev"></a>
                </div>
            </div>

            <div class="step" data-x="15000" data-y="0" data-z="-15000" data-rotate-y="180">
                <h1 style="color: #693;">Número de participantes:</h1>
                <p class="content">¿Cuántas personas participan en la técnica?</p>
                <asp:Panel ID="pnl_no_participantes" CssClass="centered" runat="server">
                    <input runat="server" type="number" name="no_participantes" id="no_participantes" placeholder="Ingrese un número" min="1" required />
                </asp:Panel>

                <div class="error" id="error_no_participantes">
                    <p>Debe ingresar un número mínimo de participantes</p>
                </div>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="return check_no_participantes()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next"></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev"></a>
                </div>
            </div>

            <div class="step" data-x="20000" data-y="0" data-z="-20000" data-rotate-y="0">
                <h1 style="color: #693;">Nivel de conocimiento de los participantes:</h1>
                <p class="content">¿Qué grado de conocimiento necesitan los participantes?</p>
                <asp:Panel ID="pnl_nivel_conocimiento" runat="server"></asp:Panel>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="return check_nivel_conocimiento()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev" /></a>
                </div>
            </div>

            <div class="step" data-x="25000" data-y="0" data-z="-25000" data-rotate-y="180">
                <h1 style="color: #63F;">Ubicación:</h1>
                <p class="content">¿De que forma se encuentran los participantes?</p>
                <asp:Panel ID="pnl_ubicacion" runat="server"></asp:Panel>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="check_ubicacion()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next"></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev"></a>
                </div>
            </div>

            <div class="step" data-x="30000" data-y="0" data-z="-30000" data-rotate-y="0">
                <h1 style="color: #F36;">Participantes:</h1>
                <p class="content">¿Quienes participan en la técnica?</p>
                <asp:Panel ID="pnl_participantes" runat="server"></asp:Panel>
                <div class="error" id="error_participantes">
                    <p>Debe seleccionar mínimo una opción</p>
                </div>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="return check_participantes()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev" /></a>
                </div>
            </div>

            <div class="step" data-x="35000" data-y="0" data-z="-35000" data-rotate-y="180">
                <h1 style="color: #C90;">Duración:</h1>
                <p class="content">¿Qué tiempo puede emplear en el desarrollo de la técnica?</p>
                <asp:Panel ID="pnl_duracion" runat="server" CssClass="centered">
                    <input type="number" name="input_duracion" id="input_duracion" placeholder="Ingrese un número" min="1" required />
                    <select id="select_duracion" name="select_duracion">
                        <option value="1">Minutos</option>
                        <option value="60">Horas</option>
                        <option value="720">Días</option>
                        <option value="21600">Meses</option>
                        <option value="7884000">Años</option>
                    </select>
                </asp:Panel>
                <div class="error" id="error_duracion">
                    <p>Debe ingresar un número mínimo para la duración</p>
                </div>

                <!--<form id="form_duracion" name="form_duracion">
        	<input type="radio" name="duracion" id="muy_baja_duracion" value="13" checked/>
            <label for="muy_baja_duracion">1 hora o menos</label><br>
            <input type="radio" name="duracion" id="baja_duracion" value="14"/>
            <label for="baja_duracion">De 1 a 4 días</label><br>
            <input type="radio" name="duracion" id="media_duracion" value="15"/>
            <label for="media_duracion">De 1 a 3 semanas</label><br>
            <input type="radio" name="duracion" id="alta_duracion" value="16"/>
            <label for="alta_duracion">De 1 a 6 meses</label><br>
            <input type="radio" name="duracion" id="muy_alta_duracion" value="17"/>
            <label for="muy_alta_duracion">6 meses o más</label>
        </form>-->

                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="return check_duracion()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev" /></a>
                </div>
            </div>

            <div class="step" data-x="40000" data-y="0" data-z="-40000" data-rotate-y="0">
                <h1 style="color: #699;">Costo:</h1>
                <p class="content">¿Que tipo de inversión desea hacer en la técnica?</p>
                <asp:Panel ID="pnl_costo" runat="server">
                </asp:Panel>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="check_costo()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev" /></a>
                </div>
            </div>

            <div class="step" data-x="45000" data-y="0" data-z="-45000" data-rotate-y="180">
                <h1 style="color: #660;">Escalabilidad:</h1>
                <p class="content">¿Que tan escalable puede ser el grupo de participantes?</p>
                <asp:Panel ID="pnl_escalabilidad" runat="server"></asp:Panel>
                <div class="footer-options">
                    <a class="next" href="javascript:impress().next()" onclick="check_escalabilidad()">
                        <img src="img/siguiente.png" width="99" height="40" alt="next" /></a>
                    <a class="prev" href="javascript:impress().prev()">
                        <img src="img/anterior.png" width="100" height="42" alt="prev" /></a>
                </div>
            </div>


            <div class="step" data-x="50000" data-y="0" data-z="-50000" data-rotate-y="0">
                <input type="button" onclick="test()" value="Test" />
            </div>


            <div class="step centered" data-x="0" data-y="0" data-z="5000" data-rotate-y="270">
                <h1 style="color: #0076F5;">Cargando resultados</h1>
                <div class="bubblingG">
                    <span id="bubblingG_1"></span>
                    <span id="bubblingG_2"></span>
                    <span id="bubblingG_3"></span>
                </div>
            </div>

            <div class="step" data-x="0" data-y="0" data-z="5000" data-rotate-x="45">
                <h1 style="color: #660;">Resultados</h1>
            </div>
        </div>

        <script src="js/impress.js"></script>
        <script>impress().init();</script>
    </form>
</body>
</html>
