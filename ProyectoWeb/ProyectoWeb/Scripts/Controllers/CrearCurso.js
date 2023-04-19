
var tabladata;

$(document).ready(function () {


    //validamos el formulario
    $("#formdata").validate({
        rules: {
            descripcion: "required"

        },
        messages: {
            descripcion: "Ingresar descripcion"
        }
    });


    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetListarCursos,
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
            {
                "data": "IdCurso", "render": function (data, type, row, meta) {
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

    $("#txtid").val(0);
    
    if (json == null) {

        $("#txtdescripcion").val("");
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}


function Guardar() {


    if ($("#formdata").valid()) {

        var $data = {
            oCurso: {
                IdCurso: parseInt($("#txtid").val()),
                Descripcion: $("#txtdescripcion").val(),
                Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }
        

        jQuery.ajax({
            url: $.MisUrls.url.UrlPostGuardarCurso,
            type: "POST",
            data: JSON.stringify($data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
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

function eliminar($idcurso) {
    if (confirm("¿Desea eliminar el curso seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlGetEliminarCurso + "?idcurso=" + $idcurso,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                } else {
                    swal("Mensaje", "No se pudo eliminar el curso", "warning")
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


