
var tablanivelacademico;

$(document).ready(function () {

    //obtenemos periodos
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetPeriodos,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            $("#cboperiodo").html("");
            if (data != null) {

                $.each(data.data, function (i, item) {
                    if (item.Activo) {
                        $("<option>").attr({ "value": item.IdPeriodo }).text(item.Descripcion).appendTo("#cboperiodo");
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

    //validamos el formulario
    $("#formNivel").validate({
        rules: {
            descripcionNivel: "required",
            descripcionTurno: "required",
            horaInicio: "required",
            horaFin: "required",
            comboperiodo:
            {
                required: true
            }
        },
        messages: {
            descripcionNivel: "Ingresar descripcion nivel",
            descripcionTurno: "Ingresar descripcion turno",
            horaInicio: "Ingresar hora inicio",
            horaFin: "Ingresar hora fin",
            comboperiodo: "Eliga un periodo"
        }
    });


    //formato de tiempo
    $("#txtHoraInicio").timepicker({
        timeFormat: 'HH:mm:ss'
    });
    $("#txtHoraFin").timepicker({
        timeFormat: 'HH:mm:ss'
    });


    tablanivelacademico = $('#tbnivel').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetNivelesAcademicos,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "oPeriodo", render: function (data) {
                    return data.Descripcion
                }
            },
            { "data": "DescripcionNivel" },
            { "data": "DescripcionTurno" },
            {
                "data": "HoraInicio", render: function (data) {
                    return ObtenerFormatoHora(data)
                }
            },
            {
                "data": "HoraFin", render: function (data) {
                    return ObtenerFormatoHora(data)
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
                "data": "IdNivel", "render": function (data, type, row, meta) {
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

    $("#txtIdNivel").val(0);
    
    if (json != null) {

        $("#txtIdNivel").val(json.IdNivel);
        
        $("#txtDescripcionNivel").val(json.DescripcionNivel);
        $("#txtDescripcionTurno").val(json.DescripcionTurno);
        $("#txtHoraInicio").val(ObtenerFormatoHora(json.HoraInicio));
        $("#txtHoraFin").val(ObtenerFormatoHora(json.HoraFin));
        $("#cboperiodo").val(json.oPeriodo.IdPeriodo);

        var valor = 0;
        valor = json.Activo == true ? 1 : 0
        $("#cboEstado").val(valor);

    } else {
        $("#txtDescripcionNivel").val("");
        $("#txtDescripcionTurno").val("");
        $("#txtHoraInicio").val("");
        $("#txtHoraFin").val("");
        $("#cboperiodo").val(1);

        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}

function eliminar($idnivel) {
    if (confirm("¿Desea eliminar el nivel academico seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlDeleteNivelAcademico + "?idnivel=" + $idnivel,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablanivelacademico.ajax.reload();
                } else {
                    swal("Mensaje", "No se pudo eliminar el nivel academico", "warning")
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


    if ($("#formNivel").valid()) {

        var $data = {
            oNivel: {
                IdNivel : parseInt($("#txtIdNivel").val()),
                oPeriodo: {
                    IdPeriodo: parseInt($("#cboperiodo").val())
                },
                DescripcionNivel: $("#txtDescripcionNivel").val(),
                DescripcionTurno: $("#txtDescripcionTurno").val(),
                TextoHoraInicio: $("#txtHoraInicio").val(),
                TextoHoraFin: $("#txtHoraFin").val(),
                Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url.UrlPostNivelAcademico,
            type: "POST",
            data: JSON.stringify($data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablanivelacademico.ajax.reload();
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

