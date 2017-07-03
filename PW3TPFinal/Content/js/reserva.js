//Para cargar la lista de sedes
$(document).ready(function () {
    $("#VersionReserva").change(function () {
        $("#SedeReserva").empty();
        $.ajax({
            type: 'POST',
            url: '../SedeReserva',
            dataType: 'json',
            data: { id: $("#VersionReserva").val() },
            success: function (sedes) {
                $("#SedeReserva").append('<option value="' + "0" + '">' + "Seleccione Sede" + '</option>');
                $.each(sedes, function (i, sede) {
                    $("#SedeReserva").append('<option value="' + sede.Value + '">' + sede.Text + '</option>');
                });
            },
            error: function (ex) {
                alert('Error al cargar sedes');
            }
        });
        return false;
    })

    //Para cargar los horarios disponibles
    $("#SedeReserva").change(function () {
        $("#FechaHoraReserva").empty();
        $.ajax({
            type: 'POST',
            url: '../ObtenerFechaHoraReserva',
            dataType: 'json',
            data: { idSede: $("#SedeReserva").val(), idVersion: $("#VersionReserva").val()  },
            success: function (fechas) {
                $("#FechaHoraReserva").append('<option value="' + "0" + '">' + "Seleccione Fecha y Hora" + '</option>');
                $.each(fechas, function (i, fecha) {
                    $("#FechaHoraReserva").append('<option value="' + fecha.Value + '">' + fecha.Text + '</option>');
                });
            },
            error: function (ex) {
                alert('Error al cargar fechas');
            }
        });
        return false;
    })
});