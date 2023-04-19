

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

//$.MisUrls.url.UrlGetNivelesAcademicos,

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

    //obtenemos los grados x niveles
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetGradosxNiveles + "?idnivel=" + idnivel,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cbodata").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    $("<option>").attr({ "value": item.IdGradoSeccion }).text(item.DescripcionGrado + " - " + item.DescripcionSeccion).prop('selected', item.Asignado).appendTo("#cbodata");
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

    var xml = "";

    xml = "<DETALLE>" +
        "<DATA>"+
            "<IdNivel>" + idnivel + "</IdNivel>" +
        "</DATA><GRADOSECCION>";


    $($('#cbodata').val()).each(function (i, item) {

        xml = xml +
            "<DATA>" +
            "<IdGradoSeccion>" + item + "</IdGradoSeccion >" +
            "</DATA>";
    });
    xml = xml + "</GRADOSECCION></DETALLE>";

    

    jQuery.ajax({
        url: $.MisUrls.url.UrlPostGradoxNivel,
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
  
    $("#cbodata").html("");
    $('#cbodata').bootstrapDualListbox('refresh', true);
}) 