var tablausuario;

$(document).ready(function () {
    $("#btnCancelar").hide();
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetRoles,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != null) {

                $.each(data.data, function (i, item) {
                    if (item.Activo) {
                        $("<option>").attr({ "value": item.IdRol }).text(item.Descripcion).appendTo("#cboRol");
                    }
                })
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

    tablausuario = $('#tbusuario').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetUsuarios,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Nombres" },
            { "data": "Apellidos" },
            { "data": "LoginUsuario" },
            { "data": "Clave" },
            {
                "data": "oRol", "render": function (data) {
                    return data.Descripcion
                }
            },
            { "data": "DescripcionReferencia" },
            { "data": "Activo", "render": function (data) {
                    if (data) {
                        return "Activo"
                    } else {
                        return "No Activo"
                    }
                }
            },
            { "data": "IdUsuario", "render": function (data) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='editar(" + data + ")'><i class='fas fa-pen'></i></button>" +
                        "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
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

function editar($idusuario) {

    $("#txtIdUsuario").val($idusuario);
    $("#txtIdReferencia").val("0");

    jQuery.ajax({
        url: $.MisUrls.url.UrlGetUsuario + "?idusuario=" + $idusuario,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != null) {

                $("#txtNombre").val(data.Nombres);
                $("#txtApellidos").val(data.Apellidos);
                $("#cboRol").val(data.IdRol);
                $("#txtUsuario").val(data.LoginUsuario);
                $("#txtClave").val(data.Clave)
                $("#cboReferencia").val(data.DescripcionReferencia)

                var valor = 0;
                valor = data.Activo == true ? 1 : 0
                $("#cboEstado").val(valor);

                $("#btnCancelar").show();
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}

function GuardarCambios() {

    var $data = {
        oUsuario: {
            IdUsuario: parseInt($("#txtIdUsuario").val()),
            Nombres: $("#txtNombre").val(),
            Apellidos: $("#txtApellidos").val(),
            IdRol: $("#cboRol").val(),
            LoginUsuario: $("#txtUsuario").val(),
            Clave: $("#txtClave").val(),
            DescripcionReferencia: $("#cboReferencia").val(),
            IdReferencia: $("#txtIdReferencia").val(),
            Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
        }
    }

    jQuery.ajax({
        url: $.MisUrls.url.UrlPostUsuario,
        type: "POST",
        data: JSON.stringify($data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                tablausuario.ajax.reload();
                limpiar();
                swal("Mensaje", "Se guardaron los cambios", "success")
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

function eliminar($idusuario) {
    if (confirm("¿Desea eliminar el usuario seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlDeleteUsuario + "?idusuario=" + $idusuario,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablausuario.ajax.reload();
                } else {
                    alert("No se pudo eliminar el usuario");
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

function limpiar() {

    $("#txtIdUsuario").val("0");
    $("#txtIdReferencia").val("0");

    $("#cboReferencia").val("NINGUNA");

    $("#txtNombre").val("");
    $("#txtApellidos").val("");
    $("#cboRol").val(1);
    $("#txtUsuario").val("");
    $("#txtClave").val("");
    $("#cboEstado").val(1)

    $("#btnCancelar").hide();
}

function Cancelar() {
    limpiar();
}

function VerReferencia() {
    var continuar = false;
    var urlorigen = "";
    var idOrigen = "";
    $("#tbModal thead").html("");

    debugger;
    

    switch ($("#cboReferencia").val()) {
        case "ALUMNO":
            $("#txtSeleccione").text("Seleccione un alumno")
            $("<tr>").append(
                $("<th>").text(""),
                $("<th>").text("Codigo"),
                $("<th>").text("Nombres"),
                $("<th>").text("Apellidos"),
                $("<th>").text("Documento Identidad")
            ).appendTo("#tbModal thead");
            urlorigen = $.MisUrls.url.UrlGetAlumnos;
            idOrigen = "IdAlumno";
            continuar = true;
            break;
        case "DOCENTE":
            $("#txtSeleccione").text("Seleccione un docente")
            $("<tr>").append(
                $("<th>").text(""),
                $("<th>").text("Codigo"),
                $("<th>").text("Nombres"),
                $("<th>").text("Apellidos"),
                $("<th>").text("Documento Identidad")
            ).appendTo("#tbModal thead");
            urlorigen = $.MisUrls.url.UrlGetDocentes;
            idOrigen = "IdDocente";
            continuar = true;
            break;
        default:
            //Declaraciones ejecutadas cuando ninguno de los valores coincide con el valor de la expresión
            break;
    }

    if (continuar) {
        if ($.fn.DataTable.isDataTable('#tbModal')) {
            $('#tbModal').DataTable().destroy();
        }
        $('#tbModal tbody').html("");

        var table = $('#tbModal').DataTable({
            "ajax": {
                "url": urlorigen,
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                {
                    "data": idOrigen, "render": function (data, type, row, meta) {
                        return "<button class='btn btn-primary btn-sm' type='button' onclick='Seleccionar(" + JSON.stringify(row) + ")'><i class='fa fa-check'></i></button>"
                    },
                    "orderable": false,
                    "searchable": false,
                    "width": "150px"
                },
                { "data": "Codigo" },
                { "data": "Nombres" },
                { "data": "Apellidos" },
                { "data": "DocumentoIdentidad" }
            ],
            "language": {
                "url": $.MisUrls.url.Url_datatable_spanish
            }

        });

        $('#modalReferencia').modal('show');

    }
 
    
}

$("#cboReferencia").change(function () {
    $("#txtIdReferencia").val("0");
});

function Seleccionar(json) {

    var id = ""
    switch ($("#cboReferencia").val()) {
        case "ALUMNO":
            id = json.IdAlumno;
            break;
        case "DOCENTE":
            id = json.IdDocente;
            continuar = true;
            break;
        default:
            break;
    }
    
    $("#txtIdReferencia").val(id);

    $("#txtNombre").val(json.Nombres);
    $("#txtApellidos").val(json.Apellidos);

    $('#modalReferencia').modal('hide');
}