$(document).ready(function () {

    $.get("/cart/FactorInfo", function (data, status) {
        $("#total").text(data.Total);
        $("#sum").text(data.Sum);
        $("#discount").text(data.Discount);
        $("#delivery").text(data.Delivery);
    })

    if ($("#item-wrapper").length != 0) {
        $(".factor").show();
    }
    else {
        $("#empty").show();
    }


    $(".add-btn").on('click', function (e) {
        var current = $(this).closest('div').find('span').text();
        $.ajax({
            type: "POST",
            url: '/cart/Add',
            data: { id: $(this).val() },
        }).fail(function () {
            alert("error");
        }).always(function () {
            $.get("/cart/FactorInfo", function (data, status) {
                console.log(data);
                $("#total").text(data.Total);
                $("#sum").text(data.Sum);
                $("#discount").text(data.Discount);
                $("#delivery").text(data.Delivery);
            })
            $.get("/cart/Count", function (data, status) {
                if (data > 0) {
                    $("#cart-count").addClass("cart-count");
                    $("#cart-count").text(data)
                }
                else {
                    $("#cart-count").removeClass("cart-count");
                }
            })
        });
        let currentCount = parseInt(current);
        $(this).closest('div').find('span').text(currentCount + 1);
        let eachPrice = $(this).closest('div').parent().find("#each-price").text();
        $(this).closest('div').parent().find("#total-price").text((currentCount + 1) * eachPrice);
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
            }).always(function () {
                $.get("/cart/FactorInfo", function (data, status) {
                    $("#total").text(data.Total);
                    $("#sum").text(data.Sum);
                    $("#discount").text(data.Discount);
                    $("#delivery").text(data.Delivery);
                });
                $.get("/cart/Count", function (data, status) {
                    if (data > 0) {
                        $("#cart-count").addClass("cart-count");
                        $("#cart-count").text(data)
                    }
                    else {
                        $("#cart-count").removeClass("cart-count");
                    }
                })
            });
            if (currentCount != 1) {
                $(this).closest('div').find('span').text(currentCount - 1);
                let eachPrice = $(this).closest('div').parent().find("#each-price").text();
                $(this).closest('div').parent().find("#total-price").text((currentCount - 1) * eachPrice);
            }
            else {
                $(this).closest('div').parent().remove();
                if ($("#item-wrapper").length == 0) {
                    $(".factor").hide();
                    $("#empty").show();
                }
            }
        }
    });

});