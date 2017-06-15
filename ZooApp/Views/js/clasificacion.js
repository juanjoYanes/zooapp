$(document).ready(function () {
    var urlAPI = "http://localhost:63313/api/clasificacion";

    
    function getClasificaciones() {
        $.get(urlAPI, function (response, state) {
            $('#mainContent').html('');

            if (state == 'success') {
                var rellenoInfo = '';

                rellenoInfo += '<table id="tablaClasificaciones">'
                rellenoInfo += '<tr>';
                rellenoInfo += '<th>Id</th>';
                rellenoInfo += '<th>Denominacion</th>';
                rellenoInfo += '<th colspan="2">Acciones</th>';
                rellenoInfo += '</tr>';

                $.each(response.data, function (index, item) {
                    rellenoInfo += '<tr>';
                    rellenoInfo +=      '<td>' + item.idClasificacion + '</td>';
                    rellenoInfo +=      '<td>' + item.denominacion + '</td>';
                    rellenoInfo +=      '<td><button data-id="' + item.idClasificacion + '" id="btnEliminar">X</button></td>';
                    rellenoInfo +=      '<td><button data-id="' + item.idClasificacion + '" id="btnEditar">Editar</button>';
                    rellenoInfo += '</tr>';
                });
                rellenoInfo += '</table>';

                $('#mainContent').append(rellenoInfo);
            }
            else {
                Console.log('response -> ', response);
                Console.log('state -> ', state);
            }
        });
    }

    $('#btnInsertarClasificacion').click(function () {
        var dataNuevaClasificacion = {
            id: 0,
            denominacion: $('#txtDenominacion').val() 
        };
        $.post(urlAPI, dataNuevaClasificacion, function (response, state) {
            if (state == 'success') {
                getClasificaciones();
                $('#txtDenominacion').val('');
            }
            else {
                console.log('response -> ', response);
                console.log('state -> ', state);
            }
        }, 'json');

    });

    $('#mainContent').on('click', '#btnEditar', function () {

        var idClasificacion = $(this).attr('data-id');
        var nuevoValorDenominacion = $('#txtNuevoDatoParaDenominacion').val();

        var dataClasificacionAModificar = {
            IdClasificacion: idClasificacion,
            denominacion: nuevoValorDenominacion
        };

        $.ajax({
            url: urlAPI + '/' + idClasificacion,
            type: "PUT",
            dataType: 'json',
            data: dataClasificacionAModificar,
            success: function (data) {
                getClasificaciones();
                $('#txtNuevoDatoParaDenominacion').val('');
                console.log(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#mainContent').on('click', '#btnEliminar', function () {

        var idClasificacion = $(this).attr('data-id');

        $.ajax({
            url: urlAPI + '/' + idClasificacion,
            type: "DELETE",
            success: function (data) {
                getClasificaciones();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    getClasificaciones();
})