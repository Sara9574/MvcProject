function GetURLParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
}

function addCommas(nStr) {
    nStr += '';
    var x = nStr.split('.');
    var x1 = x[0];
    var x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
} 

$(document).ready(function () {
    let title = decodeURIComponent(GetURLParameter('q'));
    if (count == 0) {
        $("#title").hide();
        $("#lbl-nothing").text(`نتیجه‌ای برای جستجوی "${title}" یافت نشد!`);
        $("#nothing").show();
    }
   
    if (title) {
        $("#title").text(`"نتیجه جستجو "${title}`);
    }

    $.each($('.each-price'), function () {
        $(this).text(addCommas($(this).text()));
    });

    $.each($('.item-wrapper'), function () {
        $(this).show();
    });
   
});