$(document).ready(function () {
    $("#add").on("click", function (e) {
        e.preventDefault();
    });
    $('#cat').on('change', function (e) {
        $('#sub-cat').find('option').remove();
        let id = $("#cat option:selected").val();
        $.get(`/subcategory/subcats/${id}`, function (data, status) {
            for (let i = 0; i < data.length; i++) {
                $("#sub-cat").append(new Option(`${data[i].Title}`, `${data[i].Id}`));
            }
        });
    });
    $('#cat').trigger("change");

    $.get(`/ajax/colors`, function (data, status) {
        for (let i = 0; i < data.length; i++) {
            let container = $("#colors");
            $('<input />', { type: 'checkbox', id: `color-${data[i].Id}`, title: `${data[i].Title}` }).appendTo(container);
            $("#colors").append(`<label for="color-${data[i].Id}" class='color' style="background-color:${data[i].ColorCode}" title="${data[i].Title}"></span>`);
        }
    });

    $.get(`/ajax/sizes `, function (data, status) {
        for (let i = 0; i < data.length; i++) {
            let container = $("#sizes");
            $('<input />', { type: 'checkbox', id: `size-${data[i].Id}`, title: `${data[i].Tag}` }).appendTo(container);
            $("#sizes").append(`<label class="size" for="size-${data[i].Id}">${data[i].Tag}</label>`);
        }
    });

});