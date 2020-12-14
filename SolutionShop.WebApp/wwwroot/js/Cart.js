var cartController = function () {
    this.initialize = function () {
        loadData();

    }
    function loadData() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "POST",
            url: "/" + culture + '/Cart/GetListItems',  
            success: function (res) {
                $('#lbl_number_of_items').text(res.length);                    
            }
        });
    }
}