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
});