

$(document).ready(function () {
    
    $('#cbodata').bootstrapDualListbox({
        filterTextClear: 'Mostrar todos',
        filterPlaceHolder: 'Filtrar',
        moveSelectedLabel: 'Mover seleccionados',
        moveAllLabel: 'Mover Todos',
        removeSelectedLabel: 'Eliminar seleccionados',
        removeAllLabel: 'Eliminar Todos',
        btnClass: 'btn btn-secondary',
        infoTextEmpty: 'Lista Vacia',
        infoText: 'Mostrando todos {0}',
        infoTextFiltered: '<span class="badge badge-warning">Filtrado</span> {0} de {1}',
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
                        $("<option>").attr({ "value": item.IdNivel }).text(item.DescripcionNivel).appendTo("#cboNivelAcademico");
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

            $("#cbodata").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    $("<option>").attr({ "value": item.IdCurso }).text(item.Descripcion).prop('selected', item.Asignado).appendTo("#cbodata");
                })

                $('#cbodata').bootstrapDualListbox('refresh', true);

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

    if ($('#cbodata').val().length < 1) {
        swal("Mensaje", "No existen datos para guardar cambios", "warning")
        return;
    }


    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());

    var xml = "";

    xml = "<DETALLE>" +
        "<NIVEL>" +
        "<IdNivel>" + idnivel + "</IdNivel>" +
        "</NIVEL>" +
        "<GRADOSECCION>" +
        "<IdGradoSeccion>" + idgradoseccion + "</IdGradoSeccion>" +
        "</GRADOSECCION>" +
        "<CURSOS>";


    $($('#cbodata').val()).each(function (i, item) {

        xml = xml +
            "<DATA>" +
            "<IdCurso>" + item + "</IdCurso >" +
            "</DATA>";
    });
    xml = xml + "</CURSOS></DETALLE>";

    

    jQuery.ajax({
        url: $.MisUrls.url.UrlPostGuardarAsignacion,
        type: "POST",
        data: JSON.stringify({ Vxml: xml}),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                $("#cbodata").html("");
                $('#cbodata').bootstrapDualListbox('refresh', true);
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


