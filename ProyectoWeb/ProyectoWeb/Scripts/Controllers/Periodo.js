
var tablaperiodo;

$(document).ready(function () {

    $("#formPeriodo").validate({
        rules: {
            descripcion: "required",
            fechainicio: "required",
            fechafin: "required",
        },
        // Specify validation error messages
        messages: {
            descripcion: "Ingresar descripcion",
            fechainicio: "Ingresar fecha inicio",
            fechafin: "Ingresar fecha fin"
        }
    });

    $('#txtFechaInicio').datepicker();
    
    $('#txtFechaFin').datepicker();

    tablaperiodo = $('#tbperiodo').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetPeriodos,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Descripcion" },
            {
                "data": "FechaInicio", render: function (data) {
                    return ObtenerFormatoFecha(data)
                }
            },
            {
                "data": "FechaFin", render: function (data) {
                    return ObtenerFormatoFecha(data)
                }
            },
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
                "data": "IdPeriodo", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='fas fa-pen'></i></button>" +
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


function abrirPopUpForm(json) {

    $("#txtIdPeriodo").val(0);
    
    if (json != null) {

        $("#txtIdPeriodo").val(json.IdPeriodo);
        
        $("#txtDescripcion").val(json.Descripcion);
        $("#txtFechaInicio").val(ObtenerFormatoFecha(json.FechaInicio));
        $("#txtFechaFin").val(ObtenerFormatoFecha(json.FechaFin));

        var valor = 0;
        valor = json.Activo == true ? 1 : 0
        $("#cboEstado").val(valor);

    } else {
        $("#txtDescripcion").val("");
        $("#txtFechaInicio").val("");
        $("#txtFechaFin").val("");
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}

function eliminar($idperiodo) {
    if (confirm("¿Desea eliminar el periodo seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlDeletePeriodo + "?idperiodo=" + $idperiodo,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablaperiodo.ajax.reload();
                } else {
                    swal("Mensaje", "No se pudo eliminar el periodo", "warning")
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


    if ($("#formPeriodo").valid()) {

        var $data = {
            oOperiodo: {
                IdPeriodo: parseInt($("#txtIdPeriodo").val()),
                Descripcion: $("#txtDescripcion").val(),
                textoFechaInicio: $("#txtFechaInicio").val(),
                textoFechaFin: $("#txtFechaFin").val(),
                Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url.UrlPostPeriodo,
            type: "POST",
            data: JSON.stringify($data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablaperiodo.ajax.reload();
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



function ObtenerFormatoFecha(datetime) {

    var re = /-?\d+/;
    var m = re.exec(datetime);
    var d = new Date(parseInt(m[0]))


    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '-' + (('' + month).length < 2 ? '0' : '') + month + '-' + d.getFullYear();

    return output;
}