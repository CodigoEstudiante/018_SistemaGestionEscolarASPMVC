
var tablagradoseccion;

$(document).ready(function () {


    //validamos el formulario
    $("#formGradoSeccion").validate({
        rules: {
            descripcionGrado: "required",
            descripcionSeccion: "required"
        },
        messages: {
            descripcionGrado: "Ingresar descripcion grado",
            descripcionSeccion: "Ingresar descripcion seccion"
        }
    });


    tablagradoseccion = $('#tbgradoseccion').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetGradosSecciones,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "DescripcionGrado" },
            { "data": "DescripcionSeccion" },
            {
                "data": "Activo", "render": function (data) {
                    if (data) {
                        return "Activo"
                    } else {
                        return "No Activo"
                    }
                }
            },
            {
                "data": "IdGradoSeccion", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "150px"
            }
        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        }
    });

});


function abrirPopUpForm(json) {

    $("#txtIdGradoSeccion").val(0);
    
    if (json == null) {

        $("#txtDescripcionGrado").val("");
        $("#txtDescripcionSeccion").val("");
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}


function Guardar() {


    if ($("#formGradoSeccion").valid()) {

        var $data = {
            oGradoSeccion: {
                IdGradoSeccion: parseInt($("#txtIdGradoSeccion").val()),
                DescripcionGrado: $("#txtDescripcionGrado").val(),
                DescripcionSeccion: $("#txtDescripcionSeccion").val(),
                Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }
        

        jQuery.ajax({
            url: $.MisUrls.url.UrlPostGradoSeccion,
            type: "POST",
            data: JSON.stringify($data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablagradoseccion.ajax.reload();
                    $('#FormModal').modal('hide');
                } else {

                    swal("Mensaje", "No se pudo guardar los cambios", "warning")
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });

    }

}

function eliminar($idgradoseccion) {
    if (confirm("¿Desea eliminar el grado y seccion seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlDeleteGradoSeccion + "?idgradoseccion=" + $idgradoseccion,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablagradoseccion.ajax.reload();
                } else {
                    swal("Mensaje", "No se pudo eliminar el grado y seccion", "warning")
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });

    }
}




function ObtenerFormatoFecha(datetime) {

    var re = /-?\d+/;
    var m = re.exec(datetime);
    var d = new Date(parseInt(m[0]))


    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '-' + (('' + month).length < 2 ? '0' : '') + month + '-' + d.getFullYear();

    return output;
}


function ObtenerFormatoHora(datetime) {

    var re = /-?\d+/;
    var m = re.exec(datetime);
    var d = new Date(parseInt(m[0]))

    var seconds = d.getSeconds();
    var minutes = d.getMinutes();
    var hour = d.getHours();

   
    seconds = (seconds.toString().length == 1) ? seconds.toString() + "0" : seconds.toString();
    minutes = (minutes.toString().length == 1) ? minutes.toString() + "0" : minutes.toString();
    hour = (hour.toString().length == 1) ? "0" + hour.toString()  : hour.toString();

    var output = hour + ":" + minutes + ":" + seconds;
    return output;
}

