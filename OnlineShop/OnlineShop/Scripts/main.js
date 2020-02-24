$(document).ready(function () {
   
    $.get("/cart/Count", function (data, status) {
        if (data > 0) {
            $("#cart-count").addClass("cart-count");
            $("#cart-count").text(data)
        }
    })
    //$.get("/ajax/categories", function (data, status) {
    //    console.log(data);
    //    var mySelect = $('.dropdown-menu');
    //    $.each(data, function (val, text) {
    //        mySelect.append(
    //            $(`<a class="dropdown-item" href="${text.Title}"></a>`).val(val).html(text.Title)
    //        );
    //        if (val != (data.length-1)) {
    //            mySelect.append(
    //                $('<div class="dropdown-divider"></div>')
    //            );
    //        }
    //    });
    //});

   
});