
function ValidarCampoDecimal(control) {
    if ($(control).val().trim() == '') {
        $(control).val("");
    }
    else {
        if (isNaN(parseFloat(control.value))) {
            control.value = 0;
        }
        else {
            control.value = parseFloat(control.value);
        }
    }
}

function validaNumero_Letras_Tilde(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[A-Za-zñÑ-áéíóúÁÉÍÓÚ0-9\s\t]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validaNumeroTelefonico(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /(?:\d{3}|\(\d{3}\))([-\/\.])\d{3}\1\d{4}/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validarNumerosLetras(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    patron = /^[A-Za-zñÑáéíóúÁÉÍÚÓ0-9 ]+$/;
    te = String.fromCharCode(tecla); // 5
    return patron.test(te); // 6
}

function validarNumerosLetrasAC(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /^[ 0-9-A-z]*$/;
    te = String.fromCharCode(tecla); // 5
    return patron.test(te); // 6
}

function validarRuta(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[&-;,.0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s\n]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_Email(e) {
    tecla = (document.all) ? e.keyCode : e.key;
    if (tecla == 8) return true;
    var patron = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_Codigo(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[-0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnm\x00\s]/;
    c;
}

function val_Descripcion(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[&-;,.0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s\n]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_DescripcionQ(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[?¿&-;,.0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s\n]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_DescripcionReporte(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[();,.0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s\n]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_Correo(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[-_.QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnm0123456789@\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_AZ(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}
function val_AZPUNTO(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ.\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_LoginUser(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[\.\-QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}
function val_AZ_Empresa(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\S]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}
function validarSoloNumeros(e) {

    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validar_Numero_Punto(e) {

    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /[0-9.]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function validaNumero_Letras_Tilde_Coma(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[A-Za-zñÑ-áéíóúÁÉÍÓÚ0-9\s\t,]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}


function val_19_(e) {

    if ($("#numPer").val() == 0) {
        $("#numPer").val('');
        $("#numPer").focus();
    }

    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[1234567890\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_19(e) {

    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[1234567890\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function lTrim(sStr) {
    while (sStr.charAt(0) == " ")
        sStr = sStr.substr(1, sStr.length - 1);
    return sStr;
}

function rTrim(sStr) {
    while (sStr.charAt(sStr.length - 1) == " ")
        sStr = sStr.substr(0, sStr.length - 1);
    return sStr;
}

function allTrim(sStr) {
    return rTrim(lTrim(sStr));
}
function validarNull1(e) {
    return (allTrim(e));
}

function ValidarNUll(ID_Textto) {
    var texto = document.getElementById(ID_Textto);
    $("input[id$='" + ID_Textto + "']").val(allTrim(texto.value));
}


function UI_Select(DisplayControl, DropDownControl) {
    $('#' + DisplayControl).text($('#' + DropDownControl + ' option:selected').text());
}

///     COMPARA FECHAS 1: fecha1 > fecha2 ; -1 : fecha1 < fecha2: 0: fecha1 = fecha2

function ConvertirCadenaAFecha(fecha) {
    var arrayMes = ['enero', 'febrero', 'marzo', 'abril', 'mayo', 'junio', 'julio', 'agosto', 'septiembre', 'octubre', 'noviembre', 'diciembre'];
    var dia = fecha.substring(0, 2);
    var mes = arrayMes.indexOf(fecha.substring(3, fecha.lastIndexOf(",")).trim());
    var anio = fecha.substring(fecha.lastIndexOf(",") + 1).trim()

    var date = new Date(anio, mes, dia);
    return date;
}

function CompararFechas(fecha1, fecha2) {
    var day1 = fecha1.substring(0, 2);
    var month1 = fecha1.substring(3, 5);
    var year1 = fecha1.substring(6, 10);
    var datecompare1 = month1 + "/" + day1 + "/" + year1;
    var date1 = new Date(datecompare1);

    var day2 = fecha2.substring(0, 2);
    var month2 = fecha2.substring(3, 5);
    var year2 = fecha2.substring(6, 10);
    var datecompare2 = month2 + "/" + day2 + "/" + year2;
    var date2 = new Date(datecompare2);

    if (date1 < date2)
        return -1;
    else if (date1 > date2)
        return 1;
    else
        return 0;
}

function validarFechaMenorActual(date) {
    var day = date.substring(0, 2);
    var month = date.substring(3, 5);
    var year = date.substring(6, 10);
    var datecompare = month + "/" + day + "/" + year;

    var today = new Date();
    var date2 = new Date(datecompare);

    if (date2 < today)
        return true;
    else
        return false;
}

function validarFechaMenorIgualActual(date) {
    var day = date.substring(0, 2);
    var month = date.substring(3, 5);
    var year = date.substring(6, 10);
    var datecompare = month + "/" + day + "/" + year;

    var today = new Date();
    var date2 = new Date(datecompare);

    if (date2 <= today)
        return true;
    else
        return false;
}

function validarFechaMayorActual(date) {
    var day = date.substring(0, 2);
    var month = date.substring(3, 5);
    var year = date.substring(6, 10);
    var datecompare = month + "/" + day + "/" + year;

    var today = new Date();
    var date2 = new Date(datecompare);

    if (date2 > today)
        return true;
    else
        return false;
}

function validarFechaIncioFin(datei, datef) {
     
    var validate = true;
    var FechaInicio = encodeURI($.trim($("#" + datei).val()));
    var FechaFin = encodeURI($.trim($("#" + datef).val()));

    if (ValidarFecha(datei) != 0) {
        if (FechaInicio != "") {
            appendErrorMessage("#msgFechaInicioError", 'Formato de fecha incorrecto'/*$("#IdMessageIncorrectDate").val()*/, true);
            validate = false;
        }       
    }
    else 
        appendErrorMessage("#msgFechaInicioError", "", false);


    if (ValidarFecha(datef) != 0) {

        if (FechaFin != "") {
            appendErrorMessage("#msgFechaFinError", 'Formato de fecha incorrecto'/*$("#IdMessageIncorrectDate").val()*/, true);
            validate = false;
        }
     
    }
    else 
       appendErrorMessage("#msgFechaFinError", "", false);


    if (validate == false)
       return false;
    

    if (FechaInicio != "" && FechaFin != "") {
        if (Comparar_Fechas(FechaInicio, FechaFin)) {
            appendErrorMessage("#msgFechaInicioError", 'La fecha inicio no debe ser mayor a la fecha fin' /*$("#IdMessageDateNoMenorInicio").val()*/, true);
            return false;
        }
        else {
            appendErrorMessage("#msgFechaInicioError", "", false);
            return true;
        }
    }
    else {
        appendErrorMessage("#msgFechaInicioError", "", false);
        return true;
    }
}

function validarFechaMayorIgualActual(date) {
    var day = date.substring(0, 2);
    var month = date.substring(3, 5);
    var year = date.substring(6, 10);
    var datecompare = month + "/" + day + "/" + year;

    var today = new Date();
    var date2 = new Date(datecompare);

    if (date2 >= today)
        return true;
    else
        return false;
}

function CreateUrl(Action, Controller) {
    var Url = '';
    var UrlAcionResult = '';
    var ParamUrl = $('#UrlActionGen').val();
    Url = ParamUrl.toString().replace('Home', Controller);
    UrlAcionResult = Url.toString().replace('Inicio', Action);
    return UrlAcionResult;
}

$.fn.limpiarFormularios = function () {
    return this.each(function () {
        $('input,select,textarea', this).limpiarCampos();
    });
};
$.fn.limpiarCampos = function () {
    return this.each(function () {
        var t = this.type, tag = this.tagName.toLowerCase();
        if (t == 'text' || t == 'password' || tag == 'textarea')
            this.value = '';
        else if (t == 'checkbox' || t == 'radio')
            this.checked = false;
        else if (tag == 'select') {
            this.selectedIndex = 0;
            this.parentNode.firstChild.innerHTML = this.firstChild.innerHTML
        }
    });
};

function val_SoloDeciamles(e, field) {
    key = e.keyCode ? e.keyCode : e.which
    // backspace
    if (key == 8) return true
    // 0-9
    if (key > 47 && key < 58) {
        if (field.value == '') return true
        regexp = /[0-9].[0-9]{1}$/
        return !(regexp.test(field.value))
    }
    // ,
    if (key == 46) {
        if (field.value == '') return false
        regexp = /^[0-9]+$/
        return regexp.test(field.value)
    }
    // other key
    return false

}

$.fn.clearSelect = function () {
    return this.each(function () {
        if (this.tagName == 'SELECT')
            this.options.length = 0;
    });
}

function Val_Numeros_Punto(evt) {
    var keyPressed = (evt.which) ? evt.which : event.keyCode
    return !((keyPressed != 13) && (keyPressed != 46) && (keyPressed < 48 || keyPressed > 57));
}

function val_09(e) {

    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_09_2D(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /^[0-9]+(\.[0-9]?[0-9]?)?$/;

    var text;
    te = String.fromCharCode(tecla);
    inputText = e.target || e.srcElement;

    if (inputText.value == 0 || inputText.value == "") {
        text = te;
    }
    else {
        text = inputText.value;
        strlength = text.length;
        strf = text.substr(0, inputText.selectionStart);
        strb = text.substr(inputText.selectionStart, strlength);
        text = strf + te + strb;
    }

    return patron.test(text);
}

function val_SoloDeciamlesTwo(e, field) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[&-.0-9\x00\s\n]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);

}

function EnterSubmit(e, buttonClick) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        var obj = document.getElementById(buttonClick);
        obj.click();
    }
}

function emailCheck(emailStr) {

    var emailPat = "/^(.+)@(.+)$/";
    var specialChars = "\\(\\)<>@,;:\\\\\\\"\\.\\[\\]";
    var validChars = "\[^\\s" + specialChars + "\]";
    var quotedUser = "(\"[^\"]*\")";
    var ipDomainPat = /^[(d{1,3}).(d{1,3}).(d{1,3}).(d{1,3})]$/;
    var atom = validChars + '+';
    var word = "(" + atom + "|" + quotedUser + ")";
    var userPat = new RegExp("^" + word + "(\\." + word + ")*$");
    var domainPat = new RegExp("^" + atom + "(\\." + atom + ")*$");
    var matchArray = emailStr.match(emailPat);
    if (matchArray == null) {
        alert("La dirección de correo parece ser inválida (verifique las @ y .)")
        return false
    }
    var user = matchArray[1]
    var domain = matchArray[2]

    if (user.match(userPat) == null) {
        alert("El nombre de usuario parece ser inválido.")
        return false
    }

    var IPArray = domain.match(ipDomainPat)
    if (IPArray != null) {
        for (var i = 1; i <= 4; i++) {
            if (IPArray[i] > 255) {
                alert("La dirección IP de destino es inválida!")
                return false
            }
        }
        return true
    }

    var domainArray = domain.match(domainPat)
    if (domainArray == null) {
        alert("El dominio no parece ser válido.")
        return false
    }
    var atomPat = new RegExp(atom, "g")
    var domArr = domain.match(atomPat)
    var len = domArr.length
    if (domArr[domArr.length - 1].length < 2 ||
        domArr[domArr.length - 1].length > 3) {
        alert("Las direcciones deben terminar con dominios de tres letras, o el código de país de dos letras.")
        return false
    }

    if (len < 2) {
        var errStr = "Dominio Inválido!";
        alert(errStr)
        return false
    }

    return true;
}

function val_Hours(e) {
     
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /^[0-9]?:[0-9]?$/;

    var text;
    te = String.fromCharCode(tecla);

    
    inputText = document.getElementById('' + (e.target || e.srcElement).id);



    if (inputText.value == 0 || inputText.value == "") {
        text = te;
    }
    else {
        text = inputText.value;
        strlength = text.length;
        strf = text.substr(0, inputText.selectionStart);
        strb = text.substr(inputText.selectionStart, strlength);
        text = strf + te + strb;
    }
    return patron.test(text);
}

function ContarPalabras(texto) {
    //var cantidadPalabras = texto.trim().split(/\b[\s,\.\-:;]*/).length;
    var primerBlanco = /^ /
    var ultimoBlanco = / $/
    var variosBlancos = /[ ]+/g

    texto = texto.replace(variosBlancos, " ");
    texto = texto.replace(primerBlanco, "");
    texto = texto.replace(ultimoBlanco, "");
    var textoTroceado = texto.split(" ");
    var cantidadPalabras = textoTroceado.length;

    return cantidadPalabras;
}

function CortarTextoPorCantidadPalabras(texto, cantidadPalabrasPermitidas) {
    var contador = 1;
    var resultado = "";

    for (var i = 0; i < texto.length; i++) {
        if (i !== 0) {
          
            if (texto[i] === " " && texto[i - 1] !== "") {
                contador += 1;
            }
            if (contador > cantidadPalabrasPermitidas) {
                break;
            }
        }

        resultado += texto[i];
    }

    return resultado;
}


/// Para verificar si una cadena está vacía, nula o indefinida

function isEmpty(str) {
    return (!str || 0 === str.length);
}

// Para verificar si una cadena está en blanco, nula o indefinida

function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

function redondear(num, decimales = 2){
    var signo = (num >= 0 ? 1 : -1);
    num = num * signo;
    if (decimales === 0) //con 0 decimales
        return signo * Math.round(num);
    // round(x * 10 ^ decimales)
    num = num.toString().split('e');
    num = Math.round(+(num[0] + 'e' + (num[1] ? (+num[1] + decimales) : decimales)));
    // x * 10 ^ (-decimales)
    num = num.toString().split('e');
    return signo * (num[0] + 'e' + (num[1] ? (+num[1] - decimales) : -decimales));
}
function tryParseInt(str,defaultValue) {
    var retValue = defaultValue;
    if(!isBlank(str) && !isNaN(str)){
        retValue = parseInt(str);
    }
    
    return retValue;
}

function tryParseFloat(str,defaultValue) {
    var retValue = defaultValue;
    if(!isBlank(str) && !isNaN(str)){
        retValue = parseFloat(str);
    }
    return retValue;
}