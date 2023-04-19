

$(document).ready(function () {


    jQuery.ajax({
        url: $.MisUrls.url.UrlGetRoles,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != null) {

                $.each(data.data, function (i, item) {
                    if (item.Activo) {
                        $("<option>").attr({ "value": item.IdRol }).text(item.Descripcion).appendTo("#cboRol");

                    }
                })
            }
            
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
})


function btnBuscar() {

    $("#tbpermiso tbody").html("");
    jQuery.ajax({
        url: $.MisUrls.url.UrlGetRolPermisos + "?IdRol=" + $("#cboRol").val(),
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != null) {
                $.each(data, function (i, row) {

                    $("<tr>").append(
                        $("<td>").text(i + 1),
                        $("<td>").append(
                            $("<input>").attr({ "type": "checkbox" }).data("IdPermiso", row.IdPermisos).prop('checked', row.Activo)
                        ),
                        $("<td>").text(row.Menu),
                        $("<td>").text(row.SubMenu)
                    ).appendTo("#tbpermiso tbody");
                    
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


    if ($("#tbpermiso tbody tr").length < 1) {
        alert("Primero debe seleccionar un rol y añadir los permisos");
        return;
    }

    var $xml = "<DETALLE>"
    var permiso = "";
    $('input[type="checkbox"]').each(function () {
        var idpermiso = $(this).data("IdPermiso").toString();
        var activo = $(this).prop("checked") == true ? "1" : "0";


        permiso = permiso + "<PERMISO><IdPermisos>" + idpermiso + "</IdPermisos><Activo>" + activo + "</Activo></PERMISO>";

    });
    $xml = $xml + permiso;
    $xml = $xml + "</DETALLE>"

    var request = { xml: $xml };


    jQuery.ajax({
        url: $.MisUrls.url.UrlPostGuardarCambios,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.resultado) {
                swal("Mensaje", "Se guardaron los permisos", "success")
            } else {
                swal("Mensaje", "No se pudo registrar los permisos", "warning")
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });

}