export default {
    confirm(message, callback){
        swal({
            title: "Confirmación",
            text: message,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#286090",
            confirmButtonText: "SI",
            cancelButtonText: "NO",
            closeOnConfirm: true,
            closeOnCancel: true
        },
            function (isConfirm) {
    
                if (isConfirm) {
                    callback();
                }
        });
    },
    confirmAjax(message, callback){
        swal({
            title: "Confirmación",
            text: message,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#286090",
            confirmButtonText: "SI",
            cancelButtonText: "NO",
            closeOnConfirm: false,
            closeOnCancel: true,
            showLoaderOnConfirm: true
        },
            function () {
                callback();
        });
    },
    success (mensaje) {
        swal({
            title: "Mensaje",
            text: mensaje,
            type: "success"
        });
    },
    successAction(mensaje, callback) {
        swal({
            title: "Mensaje",
            text: mensaje,
            type: "success"
        },function(){
            callback();
        });
    },
    warning(mensaje){
        swal({
            title: "Mensaje",
            text: mensaje,
            type: "warning"
        });
    },
    error (mensaje) {
        swal({
            title: "Error",
            text: mensaje,
            type: "error"
        })
    }
}