$(document).ready(function () {
    var urlAPI = "http://localhost:63313/api/tipoAnimal";


    function getTiposAnimal() {
        $.get(urlAPI, function (response, state) {
            $('#mainContent').html('');

            if (state == 'success') {
                var rellenoInfo = '';

                rellenoInfo += '<table id="tablaTiposAnimal">'
                rellenoInfo += '<tr>';
                rellenoInfo += '<th>Id</th>';
                rellenoInfo += '<th>Denominacion</th>';
                rellenoInfo += '<th colspan="2">Acciones</th>';
                rellenoInfo += '</tr>';

                $.each(response.data, function (index, item) {
                    rellenoInfo += '<tr>';
                    rellenoInfo +=      '<td>' + item.idTipoAnimal + '</td>';
                    rellenoInfo +=      '<td>' + item.denominacion + '</td>';
                    rellenoInfo +=      '<td><button data-id="' + item.idTipoAnimal + '" id="btnEliminar">X</button></td>';
                    rellenoInfo +=      '<td><button data-id="' + item.idTipoAnimal + '" id="btnEditar">Editar</button>';
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

    $('#btnInsertarTipoAnimal').click(function () {
        var dataNuevoTipoAnimal = {
            id: 0,
            denominacion: $('#txtDenominacion').val()
        };
        $.post(urlAPI, dataNuevoTipoAnimal, function (response, state) {
            if (state == 'success') {
                getTiposAnimal();
                $('#txtDenominacion').val('');
            }
            else {
                console.log('response -> ', response);
                console.log('state -> ', state);
            }
        }, 'json');

    });

    $('#mainContent').on('click', '#btnEditar', function () {

        var idTipoAnimal = $(this).attr('data-id');
        var nuevoValorDenominacion = $('#txtNuevoDatoParaDenominacion').val();

        var dataTipoAnimalAModificar = {
            IdTipoAnimal: idTipoAnimal,
            denominacion: nuevoValorDenominacion
        };

        $.ajax({
            url: urlAPI + '/' + idTipoAnimal,
            type: "PUT",
            dataType: 'json',
            data: dataTipoAnimalAModificar,
            success: function (data) {
                getTiposAnimal();
                $('#txtNuevoDatoParaDenominacion').val('');
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#mainContent').on('click', '#btnEliminar', function () {

        var idTipoAnimal= $(this).attr('data-id');

        $.ajax({
            url: urlAPI + '/' + idTipoAnimal,
            type: "DELETE",
            success: function (data) {
                getTiposAnimal();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    getTiposAnimal();
})