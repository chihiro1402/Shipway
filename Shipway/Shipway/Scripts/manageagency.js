$(document).ready(function () {
    $(".listAgency").DataTable();
})

$(".editmodal").click(function () {
    var url = $(this).data("url");
    $.get(url, function (data) {
        $('.partial-container').html(data);
        $("#modal_agency").modal("show");
    })
})

$(".deletemodal").click(function () {
    var url = $(this).data("url");
    $.get(url, function (data) {
        $('.partial-container').html(data);
        $("#modal_agency").modal("show");
    })
})