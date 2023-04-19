
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
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });


    //obtenemos docentes
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
    
    var IdDocente = parseInt($("#cboDocente").val());

    jQuery.ajax({
        url: $.MisUrls.url.UrlGetNivelAcademicoxDocente + "?iddocente=" + IdDocente,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
            $("#cboNivelAcademico").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                     $("<option>").attr({ "value": item.IdNivel }).data("data",item).text(item.DescripcionNivel).appendTo("#cboNivelAcademico");
                })

                $("#cboNivelAcademico").val($("#cboNivelAcademico option:first").val());
                listarGrados();
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
}

function listarGrados() {
    var IdDocente = parseInt($("#cboDocente").val());
    var IdNivel = parseInt($("#cboNivelAcademico").val());

    jQuery.ajax({
        url: $.MisUrls.url.UrlGetGradoSeccionxDocente + "?idnivel=" + IdNivel + "&iddocente=" + IdDocente,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cboGradoSeccion").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    $("<option>").attr({ "value": item.IdGradoSeccion }).text(item.DescripcionGrado + " - " + item.DescripcionSeccion ).appendTo("#cboGradoSeccion");
                })

                $("#cboGradoSeccion").val($("#cboGradoSeccion option:first").val());
                ListarCursos();
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}


function ListarCursos() {
    var IdDocente = parseInt($("#cboDocente").val());
    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());

    //obtenemos los cursos
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetCursosxDocente + "?idgradoseccion=" + idgradoseccion + "&idnivel=" + idnivel + "&iddocente=" + IdDocente,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cboCurso").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    $("<option>").attr({ "value": item.IdCurso }).text(item.Descripcion).appendTo("#cboCurso");
                })
                $("#cboCurso").val($("#cboCurso option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
}

function Agregar() {
    
    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());
    var idcurso = parseInt($("#cboCurso").val());
    var iddocente = $("#cboDocente").val()

 
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
        },
        conceptoCurricula: $("#txtconceptocurricula").val()
    }

    jQuery.ajax({
        url: $.MisUrls.url.UrlPostAgregarCurricula,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                $("#txtconceptocurricula").val("");
                swal("Mensaje", "Agregado correctamente", "success");
                tablaasignado.ajax.reload();
            } else {
                swal("Mensaje", "Error al agregar", "warning");
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}

function eliminar($IdCurricula) {
    if (confirm("¿Desea eliminar la curricula seleccionada?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlGetEliminarCurricula + "?IdCurricula=" + $IdCurricula,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tablaasignado.ajax.reload();

                } else {
                    swal("Mensaje", "No se pudo eliminar la curricula", "warning")
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

function Buscar() {
    
    var iddocente = parseInt($("#cboDocente").val());
    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());
    var idcurso = parseInt($("#cboCurso").val());

    if ($.fn.DataTable.isDataTable('#tbasignados')) {
        $('#tbasignados').DataTable().destroy();
    }

    tablaasignado = $('#tbasignados').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetListarCurricula + "?idgradoseccion=" + idgradoseccion + "&idnivel=" + idnivel + "&iddocente=" + iddocente + "&idcurso=" + idcurso,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Descripcion"},
            {
                "data": "IdCurricula", "render": function (data, type, row, meta) {
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



$("#cboDocente").change(function () {
    listarNivelAcademico();
}) 
