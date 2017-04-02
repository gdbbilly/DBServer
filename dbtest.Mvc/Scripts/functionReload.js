var valor = 0;
$.ajax({
    type: "POST",
    url: "/Home/GetTime",
    data: "{}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (jasonResult) {
        valor = jasonResult;
        setInterval(function () {
            location.reload();
        }, valor);
    }
});