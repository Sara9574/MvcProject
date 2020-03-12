$(document).ready(function () {
        $("#right-sidebar").children().each(function (index) {
            $(this).removeClass("active");
        });
    var url = window.location.pathname.split("/");
    var action = url[2];
    $(`#${action}`).addClass("active");
});