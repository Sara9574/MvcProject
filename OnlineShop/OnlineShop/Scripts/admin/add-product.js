var selectedSizes;
var selectedColors;
$(document).ready(function () {
    $("#add").on("click", function (e) {
        e.preventDefault();
        selectedSizes = [];
        selectedColors = [];
        $('#colors input:checked').each(function () {
            selectedColors.push($(this).attr('id').replace("color-", ""));
        });
        $('#sizes input:checked').each(function () {
          
            selectedSizes.push($(this).attr('id').replace("size-", ""));
        });
        selectedColors = selectedColors.map(Number);
        selectedSizes = selectedSizes.map(Number);

        var title = $('#pro-title').val().trim();
        var subCatId = $('#sub-cat').val();
        var link1 = $('#img1').val().trim();
        var link2 = $('#img2').val().trim();
        var link3 = $('#img3').val().trim();
        var link4 = $('#img4').val().trim();
        var desc = $('#desc').val().trim();
        var price = $('#price').val().trim();

        if (title == "") {
            $('#pro-title').focus();
            return alert("عنوان را وارد کنید!")
        }
        if (link1 == "") {
            $('#img1').focus();
            return alert("لینک تصویر اول را وارد کنید!")
        }
        if (link2 == "") {
            $('#img2').focus();
            return alert("لینک تصویر دوم را وارد کنید!")
        }
        if (link3 == "") {
            $('#img3').focus();
            return alert("لینک تصویر سوم را وارد کنید!")
        }
        if (link4 == "") {
            $('#img4').focus();
            return alert("لینک تصویر چهارم را وارد کنید!")
        }
        if (desc == "") {
            $('#desc').focus();
            return alert("توضیحات را وارد کنید!")
        }
        if (price == "") {
            $('#price').focus();
            return alert("قیمت را وارد کنید!")
        }

      

        $.post("/item/addproduct", {
            Title: title,
            SubCatId: subCatId,
            Price: price,
            Colors: selectedColors,
            Sizes: selectedSizes,
            Description: desc,
            Link1: link1,
            Link2: link2,
            Link3: link3,
            Link4: link4,
        })
            .done(function (data, status) {
                alert(`محصول جدید با کد ${data} اضافه شد.`);
                window.location.replace("/admin/panel");
            });
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