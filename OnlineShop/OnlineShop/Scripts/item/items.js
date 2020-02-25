$(document).ready(function () {
    $.get("/cart/Count", function (data, status) {
        $("#cart-count").text(data)
    })

    $.get("/cart/ItemCount", function (data, status) {
        $.each(data, function (key, value) {
            $('#items').children('div').children('span').each(function () {
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
                    if (data > 0) {
                        $("#cart-count").addClass("cart-count");
                        $("#cart-count").text(data)
                    }
                    else {
                        $("#cart-count").removeClass("cart-count");
                    }
                })
            });;
        let currentCount = parseInt(current);
        $(this).closest('div').find('span').text(currentCount + 1)
    });

    $(".remove-btn").on('click', function (e) {
        var current = $(this).closest('div').find('span').text();
        let currentCount = parseInt(current);
        if (currentCount > 0) {
            $.ajax({
                type: "POST",
                url: '/cart/remove',
                data: { id: $(this).val() },
            }).fail(function () {
                return alert("error");
            })
                .always(function () {
                    $.get("/cart/Count", function (data, status) {
                        if (data > 0) {
                            $("#cart-count").addClass("cart-count");
                            $("#cart-count").text(data)
                        }
                        else {
                            $("#cart-count").removeClass("cart-count");
                        }
                    })
                });;
            $(this).closest('div').find('span').text(currentCount - 1)
        }
        
       
    });
});