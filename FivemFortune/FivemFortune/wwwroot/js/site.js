$(document).ready(function () {
    $(document).on('click', '.buyCrateBtn', function (e) {
        e.preventDefault();

        var $button = $(this);
        var price = $button.data('price');

        $.ajax({
            url: '/Home/BuyCrate',
            method: 'GET',
            data: { price: price }, 
            success: function (response) {
                if (response.success) {
                    $('#coinsValue').text(response.coins);

                    var notification = $('#boughtnotification');
                    notification.text(response.message);
                    notification.addClass(response.colorClass);
                    notification.show();
                    setTimeout(function () {
                        notification.hide();
                        notification.removeClass(response.colorClass);
                    }, 3000);
                }
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });
});