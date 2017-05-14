$(document).ready(function () {
    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    //Line Graph ArrayList From Controller
    $.ajax({
        url: '/Tests/Statistics',
        type: 'GET',
        cache: false,
        success: function (result) {
            Morris.Line({
                element: 'graph-line',
                behaveLikeLine: true,
                data: result,
                xkey: 'period',
                ykeys: ['Value','rate'],
                labels: ['Values','Rates'],
                pointSize: 2,
                lineWidth: 1,
                hideHover: 'auto',

                //xLabelFormat: function (d) {
                //    return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'][d.getMonth()] + ' ' + d.getDate();
                //}

                xLabelFormat: function (x) { // <--- x.getMonth() returns valid index
                    var month = months[x.getMonth()];
                    return month;
                },
                dateFormat: function(x) {
                    var month = months[new Date(x).getMonth()];
                    return month;
                },
            });
        },
        error: function (error,result) {
            alert(error);
            console.log(result);
        }
    });



    //Area Graph
    Morris.Area({
        element: 'graph-area',
        padding: 10,
        behaveLikeLine: true,
        gridEnabled: false,
        gridLineColor: '#dddddd',
        axes: true,
        fillOpacity: .7,
        data: [{
            period: '2010 Q1',
            iphone: 10,
            ipad: 10,
            itouch: 10
        }, {
            period: '2010 Q2',
            iphone: 1778,
            ipad: 7294,
            itouch: 18441
        }, {
            period: '2010 Q3',
            iphone: 4912,
            ipad: 12969,
            itouch: 3501
        }, {
            period: '2010 Q4',
            iphone: 3767,
            ipad: 3597,
            itouch: 5689
        }, {
            period: '2011 Q1',
            iphone: 6810,
            ipad: 1914,
            itouch: 2293
        }, {
            period: '2011 Q2',
            iphone: 5670,
            ipad: 4293,
            itouch: 1881
        }],
        lineColors: ['#ED5D5D', '#D6D23A', '#32D2C9'],
        xkey: 'period',
        ykeys: ['iphone', 'ipad', 'itouch'],
        labels: ['iPhone', 'iPad', 'iPod Touch'],
        pointSize: 0,
        lineWidth: 0,
        hideHover: 'auto'

    });
});


       

