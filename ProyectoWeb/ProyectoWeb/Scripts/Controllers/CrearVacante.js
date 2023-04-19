

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

    //obtenemos las vacantes
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetListarVacantes + "?idnivel=" + idnivel,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#tbdata tbody").html("");

            if (data != null) {

                $.each(data, function (i, row) {
                    $("<tr>").append(
                        $("<td>").text(row.oNivel.DescripcionNivel),
                        $("<td>").text(row.oNivel.DescripcionTurno),
                        $("<td>").text(row.oGradoSeccion.DescripcionGrado),
                        $("<td>").text(row.oGradoSeccion.DescripcionSeccion),
                        $("<td>").append(
                            $("<input>").attr({ "type": "number" }).val(row.TotalVacantes)
                        )
                    ).data("data", row).appendTo("#tbdata tbody");
                })

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


    if ($('#tbdata > tbody > tr').length < 1) {
        swal("Mensaje", "No existen datos para guardar cambios", "warning")
        return;
    }

    var xml = "<DETALLE>" ;

    $('#tbdata > tbody  > tr').each(function (index, tr) {

        xml = xml +
            "<DATA>" +
            "<IdNivelDetalle>" + $(tr).data("data").IdNivelDetalle + "</IdNivelDetalle>" +
            "<TotalVacantes>" + $($(tr).find("input")).val() + "</TotalVacantes>" +
            "</DATA>";
    });

    xml = xml + "</DETALLE>";



    jQuery.ajax({
        url: $.MisUrls.url.UrlPostGuardarVacantes,
        type: "POST",
        data: JSON.stringify({ Vxml: xml}),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
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
}) 


$("#cboNivelAcademico").change(function () {

    $("#tbdata tbody").html("");
}) 