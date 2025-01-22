$(document).ready(function () {
    $("#btnIngresar").click(AutenticarUsuario);
    $('#txt_NombreUsuario').focus();
    $('#txt_NombreUsuario').keypress(function (e) {
        if (e.which === 13) {
            AutenticarUsuario();
        }
    });

    $('#txt_Contrasena').keypress(function (e) {
        if (e.which === 13) {
            AutenticarUsuario();
        }
    });

});

function AutenticarUsuario() {
    $('.ladda-button').ladda().ladda('start');


    $.ajax({
        url: $("#form-login").attr('action'),
        data: $("#form-login").serialize(),
        type: "post",
        cache: false,
        success: function (data) {
            if (data.mensaje) {
                $("#idTextMessageError").html(data.mensaje);
                $('.ladda-button').ladda().ladda('stop');
                return;
            }

            window.localStorage.setItem("tk_s_c_s", data.token)
            window.location.href = ".."+ data.url;
        }
    });
}