
var tablaRol;

$(document).ready(function () {

    tablaRol = $('#tbRol').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetRoles,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Descripcion" },
            {
                "data": "Activo", "render": function (data) {
                    if (data) {
                        return "Activo"
                    } else {
                        return "No Activo"
                    }
                }
            },
            { "data": "IdRol", "render": function (data) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirPopUpForm("+data+")'><i class='fas fa-pen'></i></button>" +
                            "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar("+ data +")'><i class='fa fa-trash'></i></button>"
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


function abrirPopUpForm($idrol) {
    
    $("#txtidRol").val($idrol);
    if ($idrol != 0) {

        jQuery.ajax({
            url: $.MisUrls.url.UrlGetRol + "?idrol=" + $idrol,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data != null) {
                    
                    $("#txtDescripcion").val(data.Descripcion);

                    var valor = 0;
                    valor = data.Activo == true ? 1 : 0
                    $("#cboEstado").val(valor);
                }

            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });
    } else {
        $("#txtDescripcion").val("");
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}

function eliminar($idrol) {
    if (confirm("¿Desea eliminar el rol seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlDeleteRol + "?idrol=" + $idrol,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablaRol.ajax.reload();
                } else {
                    alert("No se pudo eliminar el rol");
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

function Guardar() {
    var $data = {
        oRol: {
            IdRol: parseInt($("#txtidRol").val()),
            Descripcion: $("#txtDescripcion").val(),
            Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
        }
    }

    jQuery.ajax({
        url: $.MisUrls.url.UrlPostRol,
        type: "POST",
        data: JSON.stringify($data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            if (data.resultado) {
                tablaRol.ajax.reload();
                $('#FormModal').modal('hide');
            } else {
                alert("No se pudo guardar los cambios");
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}