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

    for (let i = 0; i < Colors.length; i++) {
        let container = $("#colors");
        $('<input />', { type: 'checkbox', id: `color-${Colors[i].Id}`, title: `${Colors[i].Title}` }).appendTo(container);
        $("#colors").append(`<label for="color-${Colors[i].Id}" class='color' style="background-color:${Colors[i].ColorCode}" title="${Colors[i].Title}"></span>`);
    }
    for (let i = 0; i < Sizes.length; i++) {
        let container = $("#sizes");
        $('<input />', { type: 'checkbox', id: `size-${Sizes[i].Id}`, title: `${Sizes[i].Tag}` }).appendTo(container);
        $("#sizes").append(`<label class="size" for="size-${Sizes[i].Id}">${Sizes[i].Tag}</label>`);
    }


});