$(document).ready(function () {
    $.get("/cart/Count", function (data, status) {
        $("#cart-count").text(data)
    })

    $.get("/cart/ItemCount", function (data, status) {
        $.each(data, function (key, value) {
            $('#item-wrapper').children('div').children('span').each(function () {
                if ($(this).closest('div').find('button').val() == value.Id) {
                    $(this).closest('div').find('span').text(value.Count);
                }
            });
        });
    })

    $(".add-btn").on('click', function (e) {
        var current = $(this).closest('div').find('span').text();

        $.ajax({
            type: "POST",
            url: '/cart/Add',
            data: { id: $(this).val() },
        }).fail(function () {
            alert("error");
        })
            .always(function () {
                $.get("/cart/Count", function (data, status) {
                    $("#cart-count").text(data);

                })
            });;
        let currentCount = parseInt(current);
        $(this).closest('div').find('span').text(currentCount + 1)
    });

    $(".remove-btn").on('click', function (e) {
        var current = $(this).closest('div').find('span').text();
        $.ajax({
            type: "POST",
            url: '/cart/remove',
            data: { id: $(this).val() },
        }).fail(function () {
            alert("error");
        })
            .always(function () {
                $.get("/cart/Count", function (data, status) {
                    $("#cart-count").text(data);

                })
            });;
        let currentCount = parseInt(current);
        if (currentCount > 0) {
            $(this).closest('div').find('span').text(currentCount - 1)
        }
    });
});