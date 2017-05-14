$(document).ready(function () {
    $('.listAccount').DataTable();

    if (parseInt($('#PermissionId').val()) == 2) {
        $('.adminAgency').css('display', 'block');
    } else {
        $('.adminAgency').css('display', 'none');
    }
});

$('.editmodal').click(function () {
    var url = $(this).data("url");
    $.get(url, function (data) {
        $('.partial-container').html(data);
        $("#modal_account").modal("show");
    })
});

$('.deletemodal').click(function () {
    var url = $(this).data("url");
    $.get(url, function (data) {
        $('.partial-container').html(data);
        $("#modal_account").modal("show");
    })
})

$('#PermissionId').change(function () {
    if (parseInt($('#PermissionId').val()) == 2) {
        $('.adminAgency').css('display', 'block');
    } else {
        $('.adminAgency').css('display', 'none');
    }
})

