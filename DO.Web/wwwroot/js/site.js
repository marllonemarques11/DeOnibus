$(document).ready(function () {

    $('.nav-link').click(function () {
        HideNotSelectedNav($(this).prop('id'));
    });

    VerifyCheckBoxes();

    $('input:checkbox').click(function () {
        VerifyCheckBoxes();
    });

    $('#btnConfirm').click(function () {
        var arrTravelsChecked = [];

        var tab = ($('#FavoriteTravels').css('display') == 'none' ?
            $('#TravelsForSale').prop('id') : $('#FavoriteTravels').prop('id'));

        $('input:checkbox:checked').each(function () { arrTravelsChecked.push($(this).prop('id')) });

        var ids = arrTravelsChecked.join(',');

        if (tab == 'TravelsForSale') {
            var travelsToSave = [];
            
            arrTravelsChecked.forEach(id => {
                debugger;
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
}

function VerifyCheckBoxes() {
    $('#btnConfirm').prop('disabled',
        ($('input:checkbox:checked').length == 0) ? true : false);
}

function SendTravelsToFavoriteList(travels) {
    $.ajax({
        method: "POST",
        url: urlPost,
        data: JSON.stringify( travels ),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function () {
            alert('Passagens salvas às suas favoritas.')
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
            alert('Passagens excluidas de suas favoritas.')
        },
        error: function (err) {
            alert(err);
        }
    })
}

function FindBestPrice() {

    $('[id^="Price-"]')
}