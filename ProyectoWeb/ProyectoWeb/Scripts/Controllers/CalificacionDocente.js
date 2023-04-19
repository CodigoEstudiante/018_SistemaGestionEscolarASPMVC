

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
function VerNotas() {
    if ($("#cboalumno").val() == null) {
        swal("Mensaje", "Seleccione un alumno", "warning");
        return;
    }

    var IdDocente = parseInt($("#cboDocente").val());
    var idnivel = parseInt($("#cboNivelAcademico").val());
    var idgradoseccion = parseInt($("#cboGradoSeccion").val());
    var idcurso = parseInt($("#cboCurso").val());
    var idalumno = parseInt($("#cboalumno").val());



    jQuery.ajax({
        url: $.MisUrls.url.UrlGetObtenerNotas + "?idgradoseccion=" + idgradoseccion + "&idnivel=" + idnivel + "&iddocente=" + IdDocente + "&idcurso=" + idcurso + "&idalumno=" + idalumno,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#tbdata tbody").html("")
          
            if (data != null) {
                
                $.each(data, function (i, row) {
                    $("<tr>").append(
                        $("<td>").text(row.oCurricula.Descripcion),
                        $("<td>").append(
                            $("<input>").attr({ "type": "number" }).val(row.Nota)
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

   
    if ($("#cboalumno").val() == null) {
        swal("Mensaje", "Seleccione un alumno", "warning");
        return;
    }

    if ($('#tbdata > tbody > tr').length < 1) {
        swal("Mensaje", "No existen datos para guardar cambios", "warning")
        return;
    }

    var idalumno = parseInt($("#cboalumno").val());

    var xml = "<DETALLE>";

    $('#tbdata > tbody  > tr').each(function (index, tr) {

        xml = xml +
            "<DATA>" +
            "<IdCurricula>" + $(tr).data("data").oCurricula.IdCurricula + "</IdCurricula>" +
            "<IdAlumno>" + idalumno + "</IdAlumno>" +
            "<Nota>" + $($(tr).find("input")).val() + "</Nota>" +
            "</DATA>";
    });

    xml = xml + "</DETALLE>";


    jQuery.ajax({
        url: $.MisUrls.url.UrlPostGuardarNotas,
        type: "POST",
        data: JSON.stringify({ requestXML: xml}),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                swal("Mensaje", "Se guardaron los cambios", "success");
            } else {
                swal("Mensaje", "Error al guardar cambios", "warning");
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

    //obtenemos los alumnos
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetObtenerAlumnosAsignados + "?idgradoseccion=" + idgradoseccion + "&idnivel=" + idnivel,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cboalumno").html("");
            if (data != null) {

                $.each(data, function (i, item) {
                    var value = item.oAlumno;
                    $("<option>").attr({ "value": value.IdAlumno }).text(value.Nombres + " " + value.Apellidos).appendTo("#cboalumno");
                })
                $("#cboalumno").val($("#cboalumno option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}



$("#cboDocente").change(function () {
    listarNivelAcademico();
    $("#tbdata tbody").html("");
    $("#cboalumno").html("");
}) 


$("#cboalumno").change(function () {
    $("#tbdata tbody").html("")
}) 
