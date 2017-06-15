$(document).ready(function () {
    var urlAPI = "http://localhost:63313/api/especie";
    var urlAPIClasificaciones = "http://localhost:63313/api/clasificacion";
    var urlAPITiposAnimal = "http://localhost:63313/api/tipoAnimal";
    
    function cargaSelectorTiposAnimales() {
        $.get(urlAPITiposAnimal, function (response, state) {

            if (state == 'success') {
                $.each(response.data, function (index, item) {
                    $('#slctTiposAnimal').append(
                        new Option(item.denominacion, item.idTipoAnimal));
                });
            }
            else {
                console.log('response -> ', response);
                console.log('state -> ', state);
            }
        });
    }
    
    function cargaSelectorClasificaciones() {
        $.get(urlAPIClasificaciones, function (response, state) {

            if (state == 'success') {
                $.each(response.data, function (index, item) {
                    $('#slctClasificaciones').append(
                        new Option(item.denominacion, item.idClasificacion));
                });
            }
            else {
                console.log('response -> ', response);
                console.log('state -> ', state);
            }
        });
    }

    function getEspecies() {
        $.get(urlAPI, function (response, state) {
            $('#mainContent').html('');

            if (state == 'success') {
                var rellenoInfo = '';

                rellenoInfo += '<table id="tablaEspecies">'
                rellenoInfo += '<tr>';
                rellenoInfo += '<th>Id</th>';
                rellenoInfo += '<th>Nombre</th>';
                rellenoInfo += '<th>Patas</th>';
                rellenoInfo += '<th>Es Mascota</th>';
                rellenoInfo += '<th>Clasificación</th>';
                rellenoInfo += '<th>Tipo Animal</th>';
                rellenoInfo += '<th colspan="2">Acciones</th>';
                rellenoInfo += '</tr>';

                $.each(response.data, function (index, item) {
                    rellenoInfo += '<tr>';
                    rellenoInfo +=    '<td>' + item.idEspecie + '</td>';
                    rellenoInfo +=    '<td>' + item.nombre + '</td>';
                    rellenoInfo +=    '<td>' + item.nPatas + '</td>';
                    rellenoInfo +=    '<td>';
                    rellenoInfo +=        item.esMascota ? 'Sí' : 'No';
                    rellenoInfo +=    '</td>';
                    rellenoInfo +=    '<td>' + item.clasificacion.denominacion+ '</td>';
                    rellenoInfo +=    '<td>' + item.tipoAnimal.denominacion + '</td>';
                    rellenoInfo +=    '<td><button data-id="' + item.idEspecie + '" id="btnEliminar">X</button></td>';
                    rellenoInfo +=    '<td><button data-id="' + item.idEspecie + '" id="btnEditar">Editar</button>';
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
    
    $('#btnInsertarEspecie').click(function () {
        var dataNuevaEspecie = {
            id: 0,
            nombre: $('#txtNombre').val(),
            nPatas: $('#txtNPatas').val(),
            esMascota: $('#slctEsMascota').val(),
            clasificacion: { IdClasificacion: $('#slctClasificaciones').val() },
            tipoAnimal: { IdTipoAnimal: $('#txtTiposAnimal').val() },
        };
        $.post(urlAPI, dataNuevaEspecie, function (response, state) {
            if (state == 'success') {
                getEspecies();
            }
            else {
                console.log('response -> ', response);
                console.log('state -> ', state); 
            }
        }, 'json');
        
    });
    
    $('#mainContent').on('click', '#btnEditar', function () {

        //var idEspecie = $(this).attr('data-id');
        //var nuevaEspecie = $('#txtNuevaEspecie').val();

        //var dataEspecieAModificar = {
        //    IdEspecie: idEspecie,
        //    nombre: $('#txtNombre').val(),
        //    nPatas: $('#txtNPatas').val(),
        //    esMascota: $('#txtEsMascota').val(),
        //    clasificacion: { IdClasificacion: $('#txtClasificacion').value() },
        //    tipoAnimal: { IdTipoAnimal: $('#txtTipoAnimal').value() },
        //};

        //$.ajax({
        //    url: urlAPI + '/' + idEspecie,
        //    type: "PUT",
        //    dataType: 'json',
        //    data: dataEspecieAModificar,
        //    success: function (data) {
        //        getEspecies();
        //        console.log(data);
        //    },
        //    error: function (data) {
        //        console.log(data);
        //    }
        //});
    });

    $('#mainContent').on('click', '#btnEliminar', function () {

        var idEspecie = $(this).attr('data-id');

        $.ajax({
            url: urlAPI + '/' + idEspecie,
            type: "DELETE",
            success: function (data) {
                getEspecies();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    //cargaSelectorTiposAnimales();
    cargaSelectorClasificaciones();
    getEspecies();
})