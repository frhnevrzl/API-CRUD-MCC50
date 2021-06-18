//////Test Line Chart
////var options = {
////    chart: {
////        type: 'line'
////    },
////    series: [{
////        name: 'sales',
////        data: [30, 40, 35, 50, 49, 60, 70, 91, 125]
////    }],
////    xaxis: {
////        categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999]
////    }
////}

////var chart = new ApexCharts(document.querySelector("#LineCh"), options);

////chart.render();
//////Test Donut Chart
////var options = {
////    series: [44, 55, 41, 17, 15],
////    chart: {
////        type: 'donut',
////    },
////    responsive: [{
////        breakpoint: 480,
////        options: {
////            chart: {
////                width: 200
////            },
////            legend: {
////                position: 'bottom'
////            }
////        }
////    }]
////};

////var chart = new ApexCharts(document.querySelector("#DonutCh"), options);
////chart.render();
//////Test Bar Chart
////var options = {
////    series: [{
////        data: [44, 55, 41, 64, 22, 43, 21]
////    }, {
////        data: [53, 32, 33, 52, 13, 44, 32]
////    }],
////    chart: {
////        type: 'bar',
////        height: 430
////    },
////    plotOptions: {
////        bar: {
////            horizontal: true,
////            dataLabels: {
////                position: 'top',
////            },
////        }
////    },
////    dataLabels: {
////        enabled: true,
////        offsetX: -6,
////        style: {
////            fontSize: '12px',
////            colors: ['#fff']
////        }
////    },
////    stroke: {
////        show: true,
////        width: 1,
////        colors: ['#fff']
////    },
////    tooltip: {
////        shared: true,
////        intersect: false
////    },
////    xaxis: {
////        categories: [2001, 2002, 2003, 2004, 2005, 2006, 2007],
////    },
////};

////var chart = new ApexCharts(document.querySelector("#BarCh"), options);
////chart.render();

var url = 'https://localhost:44323/API/Role/';

$.getJSON(url, function (response) {
    console.log(response);
    var data = response.map(item => item.roleName).filter((value, index, self) => self.indexOf(value) === index);
    console.log(data);
    var dataCount = response.map(item => item.accountRoles.length);
    console.log(dataCount);
    var options = {
        series: [{
            data: dataCount
        }],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: true,
            }
        },
        dataLabels: {
            enabled: true
        },
        xaxis: {
            categories: data,
        }
    };

    var chart = new ApexCharts(document.querySelector("#SalCh"), options);
    chart.render();
});

var url = 'https://localhost:44323/API/University/'
$.getJSON(url, function (response) {
    console.log(response);
    var data = response.map(item => item.universityName).filter((value, index, self) => self.indexOf(value) === index);
    console.log(data);
    var dataCount = response.map(item => item.education.length);
    console.log(dataCount);

    var options = {
        series: dataCount,
        chart: {
            type: 'pie'
        },
        labels: data
    };

    var chart = new ApexCharts(document.querySelector("#UniCh"), options);
    chart.render();
});