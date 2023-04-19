
var tabladata;

$(document).ready(function () {

    //validamos el formulario
    $("#formdata").validate({
        rules: {
            documentoidentidad: "required",
            nombres: "required",
            apellidos: "required",
            email: "required",
            numerotelefonico: "required",
            gradoestudio: "required",
            fechanacimiento: "required",
            ciudad: "required",
            direccion: "required"
        },
        messages: {
            documentoidentidad: "Ingresar documento identidad",
            nombres: "Ingresar nombres",
            apellidos: "Ingresar apellidos",
            email: "Ingresar email",
            numerotelefonico: "Ingresar numero telefonico",
            gradoestudio: "Ingresar grado estudio",
            fechanacimiento: "Ingresar fecha nacimiento",
            ciudad: "Ingresar  ciudad",
            direccion: "Ingresar  direccion"
        }
    });


    $('#txtfechanacimiento').datepicker();

    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url.UrlGetDocentes,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Codigo" },
            { "data": "DocumentoIdentidad" },
            { "data": "Nombres" },
            { "data": "Apellidos" },
            {
                "data": "FechaNacimiento", render: function (data) {
                    return ObtenerFormatoFecha(data)
                }
            },
            { "data": "Sexo" },
            { "data": "GradoEstudio" },
            { "data": "Ciudad" },
            { "data": "Direccion" },
            { "data": "Email" },
            { "data": "NumeroTelefono" },
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
                "data": "IdDocente", "render": function (data, type, row, meta) {
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

        $("#txtid").val(json.IdDocente);

        $("#txtdocumentoidentidad").val(json.DocumentoIdentidad);
        $("#txtcodigo").val(json.Codigo);
        $("#txtnombres").val(json.Nombres);
        $("#txtapellidos").val(json.Apellidos);

        $("#txtgradoestudio").val(json.GradoEstudio);
        $("#txtemail").val(json.Email);
        $("#txtnumerotelefonico").val(json.NumeroTelefono);


        
        $("#txtfechanacimiento").val(ObtenerFormatoFecha(json.FechaNacimiento));
        $("#cbosexo").val(json.Sexo);
        $("#txtciudad").val(json.Ciudad);
        $("#txtdireccion").val(json.Direccion);

        var valor = 0;
        valor = json.Activo == true ? 1 : 0
        $("#cboEstado").val(valor);

    } else {
        $("#txtdocumentoidentidad").val("");
        $("#txtcodigo").val("");
        $("#txtnombres").val("");
        $("#txtapellidos").val("");

        $("#txtgradoestudio").val("");
        $("#txtemail").val("");
        $("#txtnumerotelefonico").val("");

        
        $("#txtfechanacimiento").val("");
        $("#cbosexo").val("Masculino");
        $("#txtciudad").val("");
        $("#txtdireccion").val("");

        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}



function Guardar() {

    if ($("#formdata").valid()) {

        var request = {
            oDocente: {
                IdDocente: $("#txtid").val(),
                DocumentoIdentidad: $("#txtdocumentoidentidad").val(),
                Codigo : $("#txtcodigo").val(),
                Nombres : $("#txtnombres").val(),
                Apellidos : $("#txtapellidos").val(),
                GradoEstudio: $("#txtgradoestudio").val(),
                Email: $("#txtemail").val(),
                NumeroTelefono: $("#txtnumerotelefonico").val(),
                TextoFechaNacimiento : $("#txtfechanacimiento").val(),
                Sexo : $("#cbosexo").val(),
                Ciudad : $("#txtciudad").val(),
                Direccion : $("#txtdireccion").val(),
                Activo : parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url.UrlPostGuardarDocente,
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



function eliminar($iddocente) {
    if (confirm("¿Desea eliminar el docente seleccionado?")) {
        jQuery.ajax({
            url: $.MisUrls.url.UrlGetEliminarDocente + "?iddocente=" + $iddocente,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                } else {
                    swal("Mensaje", "No se pudo eliminar el docente", "warning")
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

