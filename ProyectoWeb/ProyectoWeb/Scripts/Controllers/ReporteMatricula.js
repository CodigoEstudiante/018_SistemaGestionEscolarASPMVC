var tabladata;
$(document).ready(function () {

    $('#tbdata').DataTable({
        responsive: true,
        "scrollY": "300px",
        "scrollCollapse": true,
        "scrollX": true,
        "paging": false,
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        }
    })


    //OBTENER PERIODO ACTUAL
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetPeriodos,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#cboperiodo").html();
            

            if (data.data != null)
                $("<option>").attr({ "value": "0" }).text("Todos").appendTo("#cboperiodo");

                $.each(data.data, function (i, item) {
                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdPeriodo }).text(item.Descripcion).appendTo("#cboperiodo");
                    }
                    listarNivelAcademico()
                })
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

            $("#cbonivelacademico").html("");
            if (data != null) {
                $("<option>").attr({ "value": "0" }).text("Todos").appendTo("#cbonivelacademico");
                $.each(data.data, function (i, item) {
                    if (item.oPeriodo.IdPeriodo == IdPeriodo && item.Activo == true) {
                        $("<option>").attr({ "value": item.IdNivel }).text(item.DescripcionNivel).appendTo("#cbonivelacademico");
                    }
                })
                $("#cbonivelacademico").val($("#cbonivelacademico option:first").val());
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

    var IdNivel = parseInt($("#cbonivelacademico").val());

    jQuery.ajax({
        url: $.MisUrls.url.UrlGeGradosxNivel + "?idnivel=" + IdNivel,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cbogradoseccion").html("");
            if (data != null) {
                $("<option>").attr({ "value": "0" }).text("Todos").appendTo("#cbogradoseccion");
                $.each(data, function (i, item) {
                    var value = item.oGradoSeccion
                    $("<option>").attr({ "value": value.IdGradoSeccion }).text(value.DescripcionGrado + " - " + value.DescripcionSeccion).appendTo("#cbogradoseccion");
                })
                $("#cbogradoseccion").val($("#cbogradoseccion option:first").val());
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

    var request = {
        codigomatricula: $("#txtcodigomatricula").val(),
        situacionmatricula: $("#cbosituacionmatricula").val(),
        codigoalumno: $("#txtcodigoalumno").val(),
        nombres: $("#txtnombres").val(),
        apellidos: $("#txtapellidos").val(),
        documentoidentidad: $("#txtdocidentidad").val(),
        periodo: parseInt($("#cboperiodo").val()) == 0 ? "" : $("#cboperiodo option:selected").text(),
        nivelacademico: parseInt($("#cbonivelacademico").val()) == 0 ? "" : $("#cbonivelacademico option:selected").text(),
        gradoseccion: parseInt($("#cbogradoseccion").val()) == 0 ? "" : $("#cbogradoseccion option:selected").text()
    }


    jQuery.ajax({
        url: $.MisUrls.url.UrlPostMatriculaConsultaReporte,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.data != null) {
                var json = JSON.parse(data.data)

                if ($.fn.DataTable.isDataTable('#tbdata')) {
                    $('#tbdata').DataTable().destroy();
                }
                
                $('#tbdata').DataTable({
                    responsive: true,
                    data: json,
                    columns: [
                        { "data": "Codigo Matricula" },
                        { "data": "Situacion" },
                        { "data": "Repitente" },
                        { "data": "Nivel Academico" },
                        { "data": "Turno Nivel" },
                        { "data": "Grado" },
                        { "data": "Seccion" },
                        { "data": "Codigo alumno" },
                        { "data": "Documento identidad alumno" },
                        { "data": "Nombres" },
                        { "data": "Apellidos" },
                    ],
                    "scrollY": "300px",
                    "scrollCollapse": true,
                    "scrollX": true,
                    "paging": false,
                    dom: 'Bfrtip',
                    buttons: [
                        {
                            extend: 'excelHtml5',
                            title: 'Reporte_' + ObtenerFecha()
                        },
                        {
                            extend: 'print'
                        }
                    ],
                    "language": {
                        "url": $.MisUrls.url.Url_datatable_spanish
                    }
                });
                


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

function ObtenerFecha() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();

    return output;
}


$("#cboperiodo").change(function () {
    listarNivelAcademico();
   
}) 
$("#cbonivelacademico").change(function () {
    listarGradosPorNivel();

}) 
