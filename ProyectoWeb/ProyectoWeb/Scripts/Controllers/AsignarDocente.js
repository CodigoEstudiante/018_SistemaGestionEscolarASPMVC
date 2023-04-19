
var tablaasignado;

$(document).ready(function () {

    tablaasignado = $('#tbasignados').DataTable({
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        }
    });
    


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
                $("#cboperiodo").val($("#cboperiodo option:first").val());

                listarNivelAcademico();

            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });


    //obtenemos periodos
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetDocentes,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            $("#cboDocente").html("");
            if (data != null) {

                $.each(data.data, function (i, item) {
                    if (item.Activo) {
                        $("<option>").attr({ "value": item.IdDocente }).text(item.Nombres + " " + item.Apellidos).appendTo("#cboDocente");
                    }
                })
                $("#cboDocente").val($("#cboDocente option:first").val());

            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });


    
    

})


function listarNivelAcademico() {
    
    var IdPeriodo = parseInt($("#cboperiodo").val());

    jQuery.ajax({
        url: $.MisUrls.url.UrlGetNivelesAcademicos,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            $("#cboNivelAcademico").html("");
            if (data != null) {

                $.each(data.data, function (i, item) {
                    if (item.oPeriodo.IdPeriodo == IdPeriodo && item.Activo == true ) {
                        $("<option>").attr({ "value": item.IdNivel }).data("data",item).text(item.DescripcionNivel).appendTo("#cboNivelAcademico");
                    }
                })

                $("#cboNivelAcademico").val($("#cboNivelAcademico option:first").val());
                listarGradosPorNivel();
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
}

function listarGradosPorNivel() {

    var IdNivel = parseInt($("#cboNivelAcademico").val());

    jQuery.ajax({
        url: $.MisUrls.url.UrlGeGradosxNivel + "?idnivel=" + IdNivel,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cboGradoSeccion").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    var value = item.oGradoSeccion
                    $("<option>").attr({ "value": value.IdGradoSeccion }).text(value.DescripcionGrado + " - " + value.DescripcionSeccion ).appendTo("#cboGradoSeccion");
                })

                $("#cboGradoSeccion").val($("#cboGradoSeccion option:first").val());

            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}


function Buscar() {

    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());

    //obtenemos los grados x niveles
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetCursosxNivelGrado + "?idnivel=" + idnivel + "&idgradoseccion=" + idgradoseccion,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cboCurso").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    if (item.Asignado) {
                        $("<option>").attr({ "value": item.IdCurso }).text(item.Descripcion).appendTo("#cboCurso");
                    }
                })

                listarAsignados()
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
}

function Asignar() {

    var encontrado = false;
    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());
    var idcurso = parseInt($("#cboCurso").val());
    var iddocente = $("#cboDocente").val()

    tablaasignado.rows().every(function (rowIdx, tableLoop, rowLoop) {
        var data = this.data();

        console.log(data);
        if (data.oNivelDetalleCurso.oCurso.IdCurso == idcurso && data.oDocente.IdDocente == iddocente)
            encontrado = true;
    });

    if ($("#cboCurso").val() == null) {
        swal("Mensaje", "Debe seleccionar un curso primero", "warning");
        return;
    }

    if (encontrado) {
        swal("Mensaje", "Ya se encuentra registrado el curso a un docente", "warning");
        return;
    }

    

    var request = {
        oDocenteCurso: {

            oNivelDetalleCurso :{
                oNivel: { IdNivel: idnivel },
                oGradoSeccion: { IdGradoSeccion: idgradoseccion },
                oCurso: { IdCurso : idcurso }
            },
            oDocente: {
                IdDocente : iddocente
            }
        }
    }

    jQuery.ajax({
        url: $.MisUrls.url.UrlPostDocenteGuardarAsignacion,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Asignado correctamente", "success");
                tablaasignado.ajax.reload();
            } else {
                swal("Mensaje", "Error al asignar", "warning");
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}

function eliminar($idhorario) {
    if (confirm("¿Desea eliminar el horario seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlPostEliminarHorario + "?idhorario=" + $idhorario,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablaasignado.ajax.reload();
                    $("#txtHoraInicio").val("");
                    $("#txtHoraFin").val("");

                } else {
                    swal("Mensaje", "No se pudo eliminar el horario", "warning")
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

function listarAsignados() {

    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());

    if ($.fn.DataTable.isDataTable('#tbasignados')) {
        $('#tbasignados').DataTable().destroy();
    }

    tablaasignado = $('#tbasignados').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetListarAsignados + "?idnivel=" + idnivel + "&idgradoseccion=" + idgradoseccion,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "oNivelDetalleCurso", render: function (data) {
                    return data.oCurso.IdCurso
                },
                'visible': false 
            },
            {
                "data": "oDocente", render: function (data) {
                    return data.Codigo
                }
            },
            {
                "data": "oDocente", render: function (data) {
                    return data.Nombres + " " + data.Apellidos
                }
            },
            {
                "data": "oNivelDetalleCurso", render: function (data) {
                    return data.oNivel.DescripcionNivel
                }
            },
            {
                "data": "oNivelDetalleCurso", render: function (data) {
                    return data.oGradoSeccion.DescripcionGrado + " " + data.oGradoSeccion.DescripcionSeccion
                }
            },
            {
                "data": "oNivelDetalleCurso", render: function (data) {
                    return data.oCurso.Descripcion
                }
            },
            {
                "data": "IdHorario", "render": function (data, type, row, meta) {
                    return  "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
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

}



$("#cboPeriodo").change(function () {
    listarNivelAcademico();

    $("#cbodata").html("");
    $('#cbodata').bootstrapDualListbox('refresh', true);
}) 

$("#cboNivelAcademico") .change(function () {
    listarGradosPorNivel();
    $("#cbodata").html("");
    $('#cbodata').bootstrapDualListbox('refresh', true);
}) 



function ObtenerFormatoHora(datetime) {

    var re = /-?\d+/;
    var m = re.exec(datetime);
    var d = new Date(parseInt(m[0]))

    var seconds = d.getSeconds();
    var minutes = d.getMinutes();
    var hour = d.getHours();


    seconds = (seconds.toString().length == 1) ? seconds.toString() + "0" : seconds.toString();
    minutes = (minutes.toString().length == 1) ? minutes.toString() + "0" : minutes.toString();
    hour = (hour.toString().length == 1) ? "0" + hour.toString() : hour.toString();

    var output = hour + ":" + minutes + ":" + seconds;
    return output;
}
