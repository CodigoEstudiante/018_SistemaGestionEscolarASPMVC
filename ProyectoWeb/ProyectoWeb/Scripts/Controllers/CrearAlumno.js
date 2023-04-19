
var tabladata;

$(document).ready(function () {

    //validamos el formulario
    $("#formNivel").validate({
        rules: {
            nombres: "required",
            apellidos: "required",
            documentoidentidad: "required",
            fechanacimiento: "required",
            ciudad: "required",
            direccion: "required"

        },
        messages: {
            nombres: "Ingresar nombres",
            apellidos: "Ingresar apellidos",
            documentoidentidad: "Ingresar documento identidad",
            fechanacimiento: "Ingresar fecha nacimiento",
            ciudad: "Ingresar  ciudad",
            direccion: "Ingresar  direccion"
        }
    });


    $('#txtfechanacimiento').datepicker();

    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetAlumnos,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Codigo" },
            { "data": "Nombres" },
            { "data": "Apellidos" },
            { "data": "DocumentoIdentidad" },
            {
                "data": "FechaNacimiento", render: function (data) {
                    return ObtenerFormatoFecha(data)
                }
            },
            { "data": "Sexo" },
            { "data": "Ciudad" },
            { "data": "Direccion" },
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
                "data": "IdAlumno", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='fas fa-pen'></i></button>" +
                        "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        }
    });

});


function abrirPopUpForm(json) {

    $("#txtid").val(0);
    
    if (json != null) {

        $("#txtid").val(json.IdAlumno);
        
        $("#txtcodigo").val(json.Codigo);
        $("#txtnombres").val(json.Nombres);
        $("#txtapellidos").val(json.Apellidos);
        $("#txtdocumentoidentidad").val(json.DocumentoIdentidad);
        $("#txtfechanacimiento").val(ObtenerFormatoFecha(json.FechaNacimiento));
        $("#cbosexo").val(json.Sexo);
        $("#txtciudad").val(json.Ciudad);
        $("#txtdireccion").val(json.Direccion);

        var valor = 0;
        valor = json.Activo == true ? 1 : 0
        $("#cboEstado").val(valor);

    } else {
        $("#txtcodigo").val("");
        $("#txtnombres").val("");
        $("#txtapellidos").val("");
        $("#txtdocumentoidentidad").val("");
        $("#txtfechanacimiento").val("");
        $("#cbosexo").val("Masculino");
        $("#txtciudad").val("");
        $("#txtdireccion").val("");

        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}



function Guardar() {

    if ($("#formNivel").valid()) {

        var request = {
            oAlumno: {
                IdAlumno : $("#txtid").val(),
                Codigo : $("#txtcodigo").val(),
                Nombres : $("#txtnombres").val(),
                Apellidos : $("#txtapellidos").val(),
                DocumentoIdentidad : $("#txtdocumentoidentidad").val(),
                TextoFechaNacimiento : $("#txtfechanacimiento").val(),
                Sexo : $("#cbosexo").val(),
                Ciudad : $("#txtciudad").val(),
                Direccion : $("#txtdireccion").val(),
                Activo : parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url.UrlPostGuardarAlumno,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
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



function eliminar($idalumno) {
    if (confirm("¿Desea eliminar el alumno seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlGetEliminarAlumno + "?idalumno=" + $idalumno,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                } else {
                    swal("Mensaje", "No se pudo eliminar el alumno", "warning")
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

