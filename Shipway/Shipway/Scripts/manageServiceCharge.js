$(document).ready(function () {
    $(".listServiceCharge").DataTable();
});

$(".editmodal").click(function(){
    var url = $(this).data("url");
    $.get(url, function (data) {
        $(".partial-container").html(data);
        $("#modal_serviceCharge").modal("show");
    })
})

$(".deletemodal").click(function () {
    var url = $(this).data("url");
    $.get(url, function (data) {
        $(".partial-container").html(data);
        $("#modal_serviceCharge").modal("show");
    })
})