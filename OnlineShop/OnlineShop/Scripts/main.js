window.onscroll = function () { myFunction() };

var header = document.getElementById("myHeader");
var sticky = header.offsetTop + 5;
console.log(header.offsetTop);


function myFunction() {
    console.log(window.pageYOffset);
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
    } else {
        header.classList.remove("sticky");
    }
}

$(document).ready(function () {
   
    $.get("/cart/Count", function (data, status) {
        if (data > 0) {
            $("#cart-count").addClass("cart-count");
            $("#cart-count").text(data)
        }
        else {
            $("#cart-count").removeClass("cart-count");
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