$(document).ready(function () {
    
    $('.nav-link').click(function () {
        HideNotSelectedNav($(this).prop('id'));
    });

    VerifyCheckBoxes();

    $('input:checkbox').click(function () {
        VerifyCheckBoxes();
    });

    $('#btnConfirm').click(function () {
        
    });
});

function HideNotSelectedNav(notSelectedNavId) {
    if (notSelectedNavId == "first-tab") {
        $('#TravelsForSale').show();
        $('#FavoriteTravels').hide();
    }
    else {
        $('#FavoriteTravels').show();
        $('#TravelsForSale').hide();
    }
}

function VerifyCheckBoxes() {
    if ($('input:checkbox:checked').length == 0) {
        $('#btnConfirm').prop('disabled', true);
    }
    else {
        $('#btnConfirm').prop('disabled', false);
    }
}

function SendTravelToFavoriteList(travelList) {

}

function ExcludeTravelToFavoriteList(travelList) {

}