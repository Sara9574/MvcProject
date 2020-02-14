$(document).ready(function () {
    console.log("hi");
    $.get("/ajax/categories", function (data, status) {
        console.log(data);
        var mySelect = $('.dropdown-menu');
        $.each(data, function (val, text) {
            mySelect.append(
                $(`<a class="dropdown-item" href="${text.Title}"></a>`).val(val).html(text.Title)
            );
            if (val != 2) {
                mySelect.append(
                    $('<div class="dropdown-divider"></div>')
                );
            }
        });
    });

   
});