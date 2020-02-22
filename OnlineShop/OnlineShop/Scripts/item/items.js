$(document).ready(function () {
    $(".add-btn").on('click', function (e) {
        let current = $("-count").text();
        let currentCount = parseInt(current);
        $(".count").text(currentCount+1);
    });
});