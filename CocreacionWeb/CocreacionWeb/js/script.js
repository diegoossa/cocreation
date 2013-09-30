var problemas;
var fase;
var no_participantes;
var nivel_conocimiento;
var ubicacion;
var participantes;
var duracion;
var costo;
var escalabilidad;
var response;// = '{ "criterios":[{"id_criterio":1,"criterio":"Temprana","grupo":1,"valor_inicial":null,"valor_final":null},{"id_criterio":2,"criterio":"Intermedia","grupo":1,"valor_inicial":null,"valor_final":null},{"id_criterio":3,"criterio":"Avanzada","grupo":1,"valor_inicial":null,"valor_final":null},{"id_criterio":4,"criterio":"Grupo Pequeño","grupo":2,"valor_inicial":null,"valor_final":null},{"id_criterio":5,"criterio":"Grupo Mediano","grupo":2,"valor_inicial":null,"valor_final":null},{"id_criterio":6,"criterio":"Grupo Grande","grupo":2,"valor_inicial":null,"valor_final":null},{"id_criterio":7,"criterio":"Basico","grupo":3,"valor_inicial":null,"valor_final":null},{"id_criterio":8,"criterio":"Medio","grupo":3,"valor_inicial":null,"valor_final":null},{"id_criterio":9,"criterio":"Alto","grupo":3,"valor_inicial":null,"valor_final":null},{"id_criterio":10,"criterio":"Avanzado","grupo":3,"valor_inicial":null,"valor_final":null},{"id_criterio":11,"criterio":"Presencial","grupo":4,"valor_inicial":null,"valor_final":null},{"id_criterio":12,"criterio":"Virtual","grupo":4,"valor_inicial":null,"valor_final":null},{"id_criterio":13,"criterio":"Muy Bajo","grupo":5,"valor_inicial":null,"valor_final":null},{"id_criterio":14,"criterio":"Bajo","grupo":5,"valor_inicial":null,"valor_final":null},{"id_criterio":15,"criterio":"Medio","grupo":5,"valor_inicial":null,"valor_final":null},{"id_criterio":16,"criterio":"Alto","grupo":5,"valor_inicial":null,"valor_final":null},{"id_criterio":17,"criterio":"Muy Alto","grupo":5,"valor_inicial":null,"valor_final":null},{"id_criterio":18,"criterio":"Bajo","grupo":6,"valor_inicial":null,"valor_final":null},{"id_criterio":19,"criterio":"Medio","grupo":6,"valor_inicial":null,"valor_final":null},{"id_criterio":20,"criterio":"Alto","grupo":6,"valor_inicial":null,"valor_final":null},{"id_criterio":21,"criterio":"Gerente","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":22,"criterio":"Empleados","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":23,"criterio":"Moderadores","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":24,"criterio":"Usuarios finales","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":25,"criterio":"Miembros de un grupo","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":26,"criterio":"Gerente","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":27,"criterio":"Empleados","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":28,"criterio":"Moderadores","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":29,"criterio":"Usuarios finales","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":30,"criterio":"Miembros de un grupo","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":31,"criterio":"Expertos del tema de discución","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":32,"criterio":"Secretario","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":33,"criterio":"Facilitador o coordinador de la técnica","grupo":7,"valor_inicial":null,"valor_final":null},{"id_criterio":34,"criterio":"Redes y conexiones entre participantes","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":35,"criterio":"Generar conocimiento","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":36,"criterio":"Generar aprendizaje","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":37,"criterio":"Generar productividad","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":38,"criterio":"Reducción de errores","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":39,"criterio":"Crear comunidades prácticas","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":40,"criterio":"Generar estrategias","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":41,"criterio":"Generar entretenimiento","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":42,"criterio":"Visualizar administración de conocimiento","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":43,"criterio":"Identificar conocimiento de los participantes","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":44,"criterio":"Generar mejores prácticas","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":45,"criterio":"Identificar problemas","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":46,"criterio":"Identificar situación actual","grupo":8,"valor_inicial":null,"valor_final":null},{"id_criterio":47,"criterio":"Bajo","grupo":9,"valor_inicial":null,"valor_final":null},{"id_criterio":48,"criterio":"Medio","grupo":9,"valor_inicial":null,"valor_final":null},{"id_criterio":49,"criterio":"Alto","grupo":9,"valor_inicial":null,"valor_final":null}]}';
var tecnicas;

var topTres = new Array();


function fillForm() {

    var json = JSON.parse(response);

    var formFase = document.getElementById("form_fase");
    var formNoIntegrantes = document.getElementById("form_no_participantes");
    var formConocimiento = document.getElementById("form_nivel_conocimiento");
    var formUbicacion = document.getElementById("form_ubicacion");
    var formCosto = document.getElementById("form_costo");
    var formEscalabilidad = document.getElementById("form_escalabilidad");
    var formProblema = document.getElementById("form_problema");
    var formIntegrantes = document.getElementById("form_participantes");
    var formDuracion = document.getElementById("form_duracion");


    for (var i = 0; i < json.criterios.length; i++) {
        switch (json.criterios[i].grupo) {
            case 1:
                var radio = createRadio('fase', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formFase.appendChild(radio);
                formFase.appendChild(label);
                formFase.appendChild(espacio);
                break;
            case 3:
                var radio = createRadio('nivel', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formConocimiento.appendChild(radio);
                formConocimiento.appendChild(label);
                formConocimiento.appendChild(espacio);
                break;
            case 4:
                var radio = createRadio('ubicacion', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formUbicacion.appendChild(radio);
                formUbicacion.appendChild(label);
                formUbicacion.appendChild(espacio);
                break;
            case 6:
                var radio = createRadio('costo', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formCosto.appendChild(radio);
                formCosto.appendChild(label);
                formCosto.appendChild(espacio);
                break;
            case 7:
                var chkBox = createCheckBox('participantes', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formIntegrantes.appendChild(chkBox);
                formIntegrantes.appendChild(label);
                formIntegrantes.appendChild(espacio);
                break;
            case 8:
                var chkBox = createCheckBox('check_problema', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formProblema.appendChild(chkBox);
                formProblema.appendChild(label);
                formProblema.appendChild(espacio);
                break;
            case 9:
                var radio = createRadio('escalabilidad', json.criterios[i].id_criterio, json.criterios[i].id_criterio);
                var label = createLabel(json.criterios[i].id_criterio, json.criterios[i].criterio);
                var espacio = document.createElement('br');
                formEscalabilidad.appendChild(radio);
                formEscalabilidad.appendChild(label);
                formEscalabilidad.appendChild(espacio);
                break;
            default:
        }
    }
    // Excepciones, ya que sólo se carga una sola vez y es un campo de texto
    var numero = document.createElement('input');
    numero.type = 'number';
    numero.id = 'no_participantes';
    numero.placeholder = "Ingrese un número";
    numero.min = 1;
    var espacio = document.createElement('br');
    formNoIntegrantes.appendChild(numero);
    formFase.appendChild(espacio);
}

$(document).ready(function () {
    var webMethod = "http://localhost:3195/cocreacion_ws.asmx/getDatos";
    $.ajax({
        type: "POST", //Verbo del servicio
        url: webMethod, //Url del servicio
        contentType: "text/xml", //Tipo de dato que se va a devolver
        success: function (data) { //data es el dato que devolvio el servicio
            var xml = $(data);
            response = xml.text();
            //alert(xml.text());
            fillForm();
            // si todo salio bien.
        },
        error: function (e) {
            alert(e); //si se ha producido un error
        }
    });
});

function rateTecnica() {
    var soapRequest = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><rateTecnica xmlns="http://tempuri.org/"><problema>' + problemas.toString() + '</problema><fase>' + fase + '</fase><noParticipantes>' + no_participantes + '</noParticipantes><conocimiento>' + nivel_conocimiento + '</conocimiento><ubicacion>' + ubicacion + '</ubicacion><participante>' + participantes.toString() + '</participante><duracion>' + duracion + '</duracion><costo>' + costo + '</costo><escalabilidad>' + escalabilidad + '</escalabilidad></rateTecnica></soap:Body></soap:Envelope>';
    //alert(soapRequest);

    $.ajax("http://localhost:3195/cocreacion_ws.asmx?op=rateTecnica",
               {
                   type: "POST",
                   data: soapRequest,
                   contentType: "text/xml; charset=utf-8",
                   success: function (data) { //data es el dato que devolvio el servicio
                       //temp = data;
                       var xml = $(data);
                       //alert(xml.text());
                       tecnicas = xml.text();
                       fillTecnicas();
                       // si todo salio bien.
                   },
                   error: function (e) {
                       alert("Error: " + e); //si se ha producido un error
                   }
               });
}

function fillTecnicas() {
    var json = JSON.parse(tecnicas);
    var ganadora = document.getElementById("ganadora");
    var segunda = document.getElementById("segunda");
    var tercera = document.getElementById("tercera");
    var link = document.getElementById("link");

    //topTres[0] = json.tecnicas[0].id_tecnica;
    //topTres[1] = json.tecnicas[1].id_tecnica;
    //topTres[2] = json.tecnicas[2].id_tecnica;

    var url = document.createElement('a');
    var h2 = document.createElement('h3');
    h2.innerHTML = "Ver técnicas";
    url.href = "ListaTecnicas.aspx?tecnica1=" + json.tecnicas[0].id_tecnica + "&tecnica2=" + json.tecnicas[1].id_tecnica + "&tecnica3=" + json.tecnicas[2].id_tecnica;

    var espacio = document.createElement('br');
    var titulo = document.createElement('h2');
    titulo.innerHTML = json.tecnicas[0].nombre_tecnica;    
    var descripcion = document.createElement('p');
    descripcion.innerHTML = json.tecnicas[0].descripcion;
    descripcion.className = "descripcion";
    ganadora.appendChild(titulo);
    ganadora.appendChild(descripcion);
    ganadora.appendChild(espacio);

    var titulo2 = document.createElement('h2');
    titulo2.innerHTML = json.tecnicas[1].nombre_tecnica;
    titulo2.className = "descripcion";
    segunda.appendChild(titulo2);

    var titulo3 = document.createElement('h2');
    titulo3.innerHTML = json.tecnicas[2].nombre_tecnica;
    titulo3.className = "descripcion";
    tercera.appendChild(titulo3);

    url.appendChild(h2);
    link.appendChild(url);


}

function createRadio(name, value, id) {
    var radio = document.createElement("input");
    radio.type = 'radio';
    radio.name = name;
    radio.value = value;
    radio.id = id;
    radio.checked = true;
    return radio;
}

function createCheckBox(name, value, id) {
    var check = document.createElement("input");
    check.type = 'checkbox';
    check.name = name;
    check.value = value;
    check.id = id;
    return check;
}

function createLabel(HtmlFor, innerHtml) {
    var label = document.createElement("label");
    label.htmlFor = HtmlFor;
    label.innerHTML = innerHtml;
    return label;
}

function check_problemas() {
    problemas = new Array();
    var check_problemas = document.getElementById("form_problema").check_problema;
    var cont = 0;
    for (var i = 0; i < check_problemas.length; i++) {
        if (check_problemas[i].checked) {
            cont++;
            //problemas = problemas + ", " + check_problemas[i].value;
            problemas.push(check_problemas[i].value);
        }
    }
    if (cont == 0) {
        document.getElementById("error_problema").style.display = "block";
        return false;
    }
    else {
        document.getElementById("error_problema").style.display = "none";
        return true;
    }
}

function check_fase() {
    var check_fase = document.getElementById("form_fase").fase;
    for (var i = 0; i < check_fase.length; i++) {
        if (check_fase[i].checked) {
            fase = check_fase[i].value;
        }
    }
}

function check_no_participantes() {
    var txt_no_participantes = document.getElementById("no_participantes");
    if ((txt_no_participantes.value != "") && (parseInt(txt_no_participantes.value) > 0)) {
        no_participantes = txt_no_participantes.value;
        document.getElementById("error_no_participantes").style.display = "none";
        return true;
    }
    else {
        document.getElementById("error_no_participantes").style.display = "block";
        return false;
    }
}

function check_nivel_conocimiento() {
    var check_nivel_conocimiento = document.getElementById("form_nivel_conocimiento").nivel;
    for (var i = 0; i < check_nivel_conocimiento.length; i++) {
        if (check_nivel_conocimiento[i].checked) {
            nivel_conocimiento = check_nivel_conocimiento[i].value;
        }
    }
}

function check_ubicacion() {
    var check_ubicacion = document.getElementById("form_ubicacion").ubicacion;
    for (var i = 0; i < check_ubicacion.length; i++) {
        if (check_ubicacion[i].checked) {
            ubicacion = check_ubicacion[i].value;
        }
    }
}

function check_participantes() {
    participantes = new Array();
    var check_participantes = document.getElementById("form_participantes").participantes;
    var cont = 0;
    for (var i = 0; i < check_participantes.length; i++) {
        if (check_participantes[i].checked) {
            cont++;
            //participantes = participantes + ", " + check_participantes[i].value;
            participantes.push(check_participantes[i].value);
        }
    }
    if (cont == 0) {
        document.getElementById("error_participantes").style.display = "block";
        return false;
    }
    else {
        document.getElementById("error_participantes").style.display = "none";
        return true;
    }
}

function check_duracion() {

    var txt_duracion = document.getElementById("input_duracion").value;

    if (txt_duracion != "") {
        var posicion = document.getElementById("select_duracion").selectedIndex;
        var selected_duracion = document.getElementById("select_duracion").options[posicion].value;
        duracion = parseInt(txt_duracion) * parseInt(selected_duracion);
        document.getElementById("error_duracion").style.display = "none";
        return true;
    }
    else {
        document.getElementById("error_duracion").style.display = "block";
        return false;
    }
}

function check_costo() {
    var check_costo = document.getElementById("form_costo").costo;
    for (var i = 0; i < check_costo.length; i++) {
        if (check_costo[i].checked) {
            costo = check_costo[i].value;
        }
    }
}

function check_escalabilidad() {
    var check_escalabilidad = document.getElementById("form_escalabilidad").escalabilidad;
    for (var i = 0; i < check_escalabilidad.length; i++) {
        if (check_escalabilidad[i].checked) {
            escalabilidad = check_escalabilidad[i].value;
        }
    }
}




