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
    
    $((tab == 'FavoriteTravels' ? '#first-tab' : '#second-tab')).css('visibility',
        ($('input:checkbox:checked').length == 0) ? 'visible' : 'hidden');
}

function SendTravelsToFavoriteList(travels) {
    $.ajax({
        method: "POST",
        url: urlPost,
        data: JSON.stringify( travels ),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function () {
            alert('Passagens salvas às suas favoritas.');
            window.location.href = urlIndex;
        },
        error: function (err) {
            alert(err);
        }
    })
}

function ExcludeTravelsFromFavoriteList(objectsId) {
    $.ajax({
        method: "POST",
        url: urlDelete,
        data: { objectsId: objectsId },
        success: function () {
            alert('Passagens excluidas de suas favoritas.');
            window.location.href = urlIndex;
        },
        error: function (err) {
            alert(err);
        }
    })
}