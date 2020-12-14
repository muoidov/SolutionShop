// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var siteController = function () {
    this.initialize - function () {
        resgiterEvents();
        loadCart();

    }
    function loadCart() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            }
        });
    }
    
}
function resgiterEvents() {
    $('body').on('click', '.btn-add-cart', function (e) {
        e.preventDefault();
        const culture = $('#hidCulture').val();
        const id = $(this).data('id');
        $.ajax({
            type: "POST",
            url: "/" + culture + '/Cart/AddToCart',
            data: {
                id: id,
                languageId: culture
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}