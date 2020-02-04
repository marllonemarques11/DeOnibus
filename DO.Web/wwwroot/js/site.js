$(document).ready(function () {
    
    $('.nav-link').click(function () {
        HideNotSelectedNav($(this).prop('id'));
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