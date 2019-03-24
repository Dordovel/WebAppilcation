window.onload= function() {

    var butt = $("input[value='Подробнее']");
    for (var a = 0; a < butt.length; a++) {
            butt.eq(a).on("click",
                function () {
                    window.location.replace("WebForm1.aspx?id="+$(this).attr("id"));
                });
    }
}