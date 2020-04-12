$(document).ready(function () {

    
    $("input:radio[name=color]").change(function () {
        var selectedColor = $('input[type="radio"]:checked').val();;
        $("#selectedColor").text(selectedColor);
       
    });
    $("input:radio[name=size]").change(function () {
        var selectedSize = $('input:radio[name=size]:checked').val();;
        $("#selectedSize").text(selectedSize);
    });
   

    $(".add-btn").on('click', function (e) {
        var current = $(this).closest('div').find('span').text();
        let currentCount = parseInt(current);
        $(this).closest('div').find('span').text(currentCount + 1)
    });



    $(".submit-add-btn").on('click', function (e) {
        $.ajax({
           type: "POST",
            url: '/cart/Add',
            data: { id: $(this).val(), count: $("#count").text() },
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

