$(document).ready(function () {
    $('#TravelsForSale').show();
    $('#FavoriteTravels').hide();

    var tab = '';
    var confirmFavorite = 'Confirmar Favorito(s)';
    var deleteFavorite = 'Excluir Favoritos';

    $('#btnConfirm').html(confirmFavorite);

    $('.nav-link').click(function () {
        tab = HideNotSelectedNav($(this).prop('id'));
        $('#btnConfirm').html((tab == 'TravelsForSale') ? confirmFavorite : deleteFavorite);

        $('#drpDeparturePeriod, #drpBusClass, #txtLimitPrice, #btnFilter').css('visibility',
            (tab == 'TravelsForSale') ? 'visible' : 'hidden');
    });

    EnableFieldsByCheckBoxes(tab);

    $('input:checkbox').click(function () {
        EnableFieldsByCheckBoxes(tab);
    });

    $('#btnConfirm').click(function () {
        var arrTravelsChecked = [];

        $('input:checkbox:checked').each(function () { arrTravelsChecked.push($(this).prop('id')) });

        var ids = arrTravelsChecked.join(',');

        if (tab == 'TravelsForSale') {
            var travelsToSave = [];
            
            arrTravelsChecked.forEach(id => {
                travelsToSave.push(travelsAvailable.find(function (object) { return object.objectId == id }));
            });
            SendTravelsToFavoriteList(travelsToSave);
        }
        else {
            ExcludeTravelsFromFavoriteList(ids);
        }
    });

    $('#btnFilter').click(function () {
        var period = ($('#drpDeparturePeriod option:selected').text() != 'embarque' ?
            $('#drpDeparturePeriod option:selected').text() : '');

        var busClass = ($('#drpBusClass option:selected').text() != 'classes disponíveis' ?
            $('#drpBusClass option:selected').text() : '');

        var limitPrice = $('#txtLimitPrice').val();

        switch (period) {
            case 'madrugada':
                period = '00:00, 05:59'
                break;
            case 'manhã':
                period = '06:00, 11:59'
                break;
            case 'tarde':
                period = '12:00, 17:59'
                break;
            case 'noite':
                period = '18:00, 23:59'
                break;
            default:
        }

        Filter(period, busClass, limitPrice);
    });
    $('body').on('click', '#tbodyTravelsAvailable', function () {
        EnableFieldsByCheckBoxes(tab);
        $('input:checkbox').click(function () {
            EnableFieldsByCheckBoxes(tab);
        });
    });
});

function HideNotSelectedNav(selectedNavId) {
    if (selectedNavId == "first-tab") {
        $('#TravelsForSale').show();
        $('#FavoriteTravels').hide();
    }
    else {
        $('#FavoriteTravels').show();
        $('#TravelsForSale').hide();
    }

    tab = ($('#FavoriteTravels').css('display') == 'none' ?
        $('#TravelsForSale').prop('id') : $('#FavoriteTravels').prop('id'));

    return tab;
}

function EnableFieldsByCheckBoxes(tab) {
    $('#btnConfirm').prop('disabled',
        ($('input:checkbox:checked').length == 0) ? true : false);
    
    $((tab == 'FavoriteTravels' ? '#first-tab, ' : '#second-tab, ')
        +'#drpDeparturePeriod, #drpBusClass, #txtLimitPrice, #btnFilter').css('visibility',
        ($('input:checkbox:checked').length == 0) ? 'visible' : 'hidden');

    if (tab == 'FavoriteTravels') {
        $('#drpDeparturePeriod, #drpBusClass, #txtLimitPrice, #btnFilter').css('visibility', 'hidden');
    }
}

function SendTravelsToFavoriteList(travels) {
    $.ajax({
        method: 'POST',
        url: urlPost,
        data: JSON.stringify(travels),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function () {
            alert('Passagens salvas às suas favoritas.');
            window.location.href = urlIndex;
        },
        error: function (err) {
            alert(err);
        }
    });
}

function ExcludeTravelsFromFavoriteList(objectsId) {
    $.ajax({
        method: 'DELETE',
        url: urlDelete,
        data: { objectsId: objectsId },
        success: function () {
            alert('Passagens excluidas de suas favoritas.');
            window.location.href = urlIndex;
        },
        error: function (err) {
            alert(err);
        }
    });
}

function Filter(period, busClass, priceLimit) {
    $.ajax({
        method: 'GET',
        url: urlIndex,
        data: { period: period, busClass: busClass, priceLimit: priceLimit },
        success: function (data) {
            var teste = $('#tbodyTravelsAvailable', data).html();
            $('#tbodyTravelsAvailable').html(teste);
        },
        error: function (err) {
            err
        }
    });
}