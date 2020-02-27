

$(document).ready(function () {

    $.each($('.total-price'), function () {
        $(this).text(addCommas($(this).text()));
    });

    $.each($('.each-price'), function () {
        $(this).text(addCommas($(this).text()));
    });


    $.each($('.item-wrapper'), function () {
        $(this).show();
    });


    function addCommas(nStr) {
        nStr += '';
        var x = nStr.split('.');
        var x1 = x[0];
        var x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }


    $.get("/cart/FactorInfo", function (data, status) {
        $("#total").text(addCommas(data.Total));
        $("#sum").text(addCommas(data.Sum));
        $("#discount").text(addCommas(data.Discount));
        $("#delivery").text(addCommas(data.Delivery));
    })

    $(".fa-trash-o").on("click", function () {
        itemId = $(this).closest('div').parent().find(".add-btn").val();
        var icon = $(this);
        $.ajax({
            type: "POST",
            url: '/cart/trash',
            data: { id: itemId },
        }).fail(function () {
            alert("error");
        }).always(function () {
            //$(this).closest('div').parent().css("background-color", "red");
            //$(this).parent().closest(".fa-trash-o").css("color", "red");
            icon.closest('div').parent().remove();
            $.get("/cart/Count", function (data, status) {
                if (data > 0) {
                    $("#cart-count").addClass("cart-count");
                    $("#cart-count").text(data);
                    $.get("/cart/FactorInfo", function (data, status) {
                        $("#total").text(addCommas(data.Total));
                        $("#sum").text(addCommas(data.Sum));
                        $("#discount").text(addCommas(data.Discount));
                        $("#delivery").text(addCommas(data.Delivery));
                    })
                }
                else {
                    $("#cart-count").removeClass("cart-count");
                    if ($(".item-wrapper").length == 0) {
                        $(".factor").hide();
                        $("#empty").show();
                    }
                }
            })

        });
    });


    if ($(".item-wrapper").length != 0) {
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
                $("#total").text(addCommas(data.Total));
                $("#sum").text(addCommas(data.Sum));
                $("#discount").text(addCommas(data.Discount));
                $("#delivery").text(addCommas(data.Delivery));
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
        let eachPrice = $(this).closest('div').parent().find(".each-price").text().replace(",", "");
        $(this).closest('div').parent().find(".total-price").text(addCommas((currentCount + 1) * eachPrice));
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
                    $("#total").text(addCommas(data.Total));
                    $("#sum").text(addCommas(data.Sum));
                    $("#discount").text(addCommas(data.Discount));
                    $("#delivery").text(addCommas(data.Delivery));
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
            if (currentCount != 1) {
                $(this).closest('div').find('span').text(currentCount - 1);
                let eachPrice = $(this).closest('div').parent().find(".each-price").text().replace(",", "");
                $(this).closest('div').parent().find(".total-price").text(addCommas((currentCount - 1) * eachPrice));
            }
            else {
                $(this).closest('div').parent().remove();
                if ($(".item-wrapper").length == 0) {
                    $(".factor").hide();
                    $("#empty").show();
                }
            }
        }
    });

});