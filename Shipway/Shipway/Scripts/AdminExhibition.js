$(document).ready(function () {
    $(".listExhibition").DataTable();
})


function GetTotalCost(arrayAddress, arraySize) {
    var array = [];
    for (i = 0; i < arrayAddress.length; i++) {
        array.push(arrayAddress[i]);
    }
    for (i = 0; i < arraySize.length; i++) {
        array.push(arraySize[i]);
    }


    for (i = 0; i < array.length; i++) {
        $(array[i]).keyup(function () {
            var isCost = true;
            for (j = 0; j < arrayAddress.length; j++) {
                if ($(arrayAddress[j]).val() == "") {
                    $(".totalmoney").html("0 VND");
                    isCost = false;
                }
            }

            if (isCost == true) {
                $.ajax({
                    url: "/ExhibitionCustomer/TotalMoney",
                    type: "POST",
                    dataType: "json",
                    data: {
                        weigh: parseInt($("#PackageWeigh").val()) || 0,
                        packagelong: parseInt($("#PackageLong").val()) || 0,
                        wide: parseInt($("#PackageWide").val()) || 0,
                        high: parseInt($("#PackageHigh").val()) || 0,
                        citysender: ($("#stateSender").val()).toString(),
                        cityReceiver: ($("#stateReceive").val()).toString(),
                        kindService: parseInt($("#KindServiceId").val())
                    },
                    success: function (data) {
                        $("#Cost").val(data.TotalMoney);
                        $("#DayReceive").val(data.DayReceiver);
                        $(".totalmoney").html(data.TotalMoney);
                        var temp = "Dự kiến giao trong ngày : " + data.DayReceiver;
                        $("#dayReceive").html(temp);
                    }
                })
            }
        })

        $(array[i]).change(function () {
            var isCost = true;
            for (j = 0; j < arrayAddress.length; j++) {
                if ($(arrayAddress[j]).val() == "") {
                    $(".totalmoney").html("0 VND");
                    isCost = false;
                }
            }

            if (isCost == true) {
                $.ajax({
                    url: "/ExhibitionCustomer/TotalMoney",
                    type: "POST",
                    dataType: "json",
                    data: {
                        weigh: parseInt($("#PackageWeigh").val()) || 0,
                        packagelong: parseInt($("#PackageLong").val()) || 0,
                        wide: parseInt($("#PackageWide").val()) || 0,
                        high: parseInt($("#PackageHigh").val()) || 0,
                        citysender: ($("#stateSender").val()).toString(),
                        cityReceiver: ($("#stateReceive").val()).toString(),
                        kindService: parseInt($("#KindServiceId").val())
                    },
                    success: function (data) {
                        $("#Cost").val(data.TotalMoney);
                        $("#DayReceive").val(data.DayReceiver);
                        $(".totalmoney").html(data.TotalMoney);
                        var temp = "Dự kiến giao trong ngày : " + data.DayReceiver;
                        $("#dayReceive").html(temp);
                    }
                })
            }
        })

        $(array[i]).keydown(function () {
            var isCost = true;
            for (j = 0; j < arrayAddress.length; j++) {
                if ($(arrayAddress[j]).val() == "") {
                    $(".totalmoney").html("0 VND");
                    isCost = false;
                }
            }

            if (isCost == true) {
                $.ajax({
                    url: "/ExhibitionCustomer/TotalMoney",
                    type: "POST",
                    dataType: "json",
                    data: {
                        weigh: parseInt($("#PackageWeigh").val()) || 0,
                        packagelong: parseInt($("#PackageLong").val()) || 0,
                        wide: parseInt($("#PackageWide").val()) || 0,
                        high: parseInt($("#PackageHigh").val()) || 0,
                        citysender: ($("#stateSender").val()).toString(),
                        cityReceiver: ($("#stateReceive").val()).toString(),
                        kindService: parseInt($("#KindServiceId").val())
                    },
                    success: function (data) {
                        $("#Cost").val(data.TotalMoney);
                        $("#DayReceive").val(data.DayReceiver);
                        $(".totalmoney").html(data.TotalMoney);
                        var temp = "Dự kiến giao trong ngày : " + data.DayReceiver;
                        $("#dayReceive").html(temp);
                    }
                })
            }
        })
    }
}

GetTotalCost(["#SenderAddress", "#ReceiverAddress"], ["#PackageWeigh", "#PackageLong", "#PackageWide", "#PackageHigh", "#KindServiceId"]);