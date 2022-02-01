$(function () {
    $('.categorie_id').on('change', function ()
    {
        var id = $(this).val();
        alert(id);
        $.get('/Utilisateur/getProducts', { id: id }, function (data) {
            $('.product_id').empty();
            $('.product_id').append("<option value=''>select a categorie Articles</option>")
            $.each(data, function (index, row)
            {

               $('.product_id').append("<option value='" + row.Identity1 + "'>" + row.Plaque + "</option>")
            });
        });
    });
});

//$(function () {
//    $('.product_id').on('change', function () {
//        var product_id = $(this).val();
//        //alert(product_id);
//        $.get('/ConsommationCarburant/getUnitPrice', { product_id: product_id }, function (data) {
//            $('#unit_price').val(data.PrixUnitaire);
//        });
//    });
//});
//$(function () {
//    $('.product_id').on('change', function () {
//        var product_id = $(this).val();
//        //alert(product_id);
//        $.get('/HistoriquePaiement/getPrixTotal', { product_id: product_id }, function (data) {
//            $('#unit_price').val(data.PrixTotal);
//        });
//    });
//});

$(function () {
    $('#qty').on('keyup', function () {
        var qty = $(this).val();
        var unit_price = $('#unit_price').val();
        var total = qty * unit_price;
        $('#total').val(total);
    });
});

////print details
//$(function () {
//    $('#print').on('click', function () {
//        window.print();
//        return false;
//    });
//});
