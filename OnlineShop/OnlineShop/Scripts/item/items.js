$(document).ready(function () {
    $(".add-btn").on('click', function (e) {
        let current = $(this).closest('div').find('span').text()
        let currentCount = parseInt(current);
        $(this).closest('div').find('span').text(currentCount + 1)
    });

    $(".remove-btn").on('click', function (e) {
        let current = $(this).closest('div').find('span').text()
        let currentCount = parseInt(current);
        if (currentCount > 0) {
            $(this).closest('div').find('span').text(currentCount - 1)
        }
    });
});