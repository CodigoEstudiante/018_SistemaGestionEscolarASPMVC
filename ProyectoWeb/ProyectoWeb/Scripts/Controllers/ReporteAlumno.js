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

})

function Buscar() {

    var nombres = $("#txtnombres").val();
    var apellidos = $("#txtapellidos").val();
    var codigo = $("#txtcodigo").val();
    var documentoidentidad = $("#txtdocidentidad").val();

    jQuery.ajax({
        url: $.MisUrls.url.UrlGetConsultaReporteAlumno + "?nombres=" + nombres + "&apellidos=" + apellidos + "&codigo=" + codigo + "&documentoidentidad=" + documentoidentidad,
        type: "GET",
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
                        { "data": "Codigo" },
                        { "data": "Documento Identidad" },
                        { "data": "Nombres" },
                        { "data": "Apellidos" },
                        { "data": "Fecha Nacimiento" },
                        { "data": "Sexo" },
                        { "data": "Ciudad" },
                        { "data": "Direccion" },
                        { "data": "Nivel Academico" },
                        { "data": "Turno" },
                        { "data": "Grado" },
                        { "data": "Seccion" },
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