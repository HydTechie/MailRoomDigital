$(document).ready(function () {

    var newHeight = $(window).height();
    console.log(newHeight);
    if (newHeight > 800) {
        $('.dashBoardContent').css("height", (newHeight * 0.9) + "px");
        $('.dashboardRow').css("height", (newHeight * 0.18) + "px");
        $('.metricChartRow').css("height", (newHeight * 0.42) + "px");
        $('.metricLinkRow').css("height", (newHeight * 0.13) + "px");
    }

    else if (newHeight > 700 && newHeight <= 800) {//my screen //done
        $('.dashBoardContent').css("height", (newHeight * 0.88) + "px");
        $('.dashboardRow').css("height", (newHeight * 0.18) + "px");
        $('.metricChartRow').css("height", (newHeight * 0.51) + "px");
        $('.metricLinkRow').css("height", (newHeight * 0.22) + "px");
    }

    else if (newHeight > 600 && newHeight <= 700) {
        $('.dashBoardContent').css("height", (newHeight * 0.87) + "px");
        $('.dashboardRow').css("height", (newHeight * 0.22) + "px");//done
        $('.metricChartRow').css("height", (newHeight * 0.56) + "px");//done
        $('.metricLinkRow').css("height", (newHeight * 0.35) + "px");//done
    }

    else if (newHeight > 500 && newHeight <= 600) {
        $('.dashBoardContent').css("height", (newHeight * 0.86) + "px");
        $('.dashboardRow').css("height", (newHeight * 0.28) + "px");//done
        $('.metricChartRow').css("height", (newHeight * 0.66) + "px");//done
        $('.metricLinkRow').css("height", (newHeight * 0.47) + "px");//done
    }

    else if (newHeight > 400 && newHeight <= 500) {
        $('.dashBoardContent').css("height", (newHeight * 0.83) + "px");
        $('.dashboardRow').css("height", (newHeight * 0.34) + "px");//done
        $('.metricChartRow').css("height", (newHeight * 0.89) + "px");//done
        $('.metricLinkRow').css("height", (newHeight * 0.49) + "px");//done
    }




});

function loadChartsInDashboard(number, newHeight) {
    //$('.totalSummary').css("height", (newHeight * 0.8) + "px");

    if (number == '1') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#E1F4FB'

            },
            title: {
                text: 'Verification Required',
                style: {
                    color: '#484b4f',
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },
            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 30,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 30,
                    to: 75,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 75,
                    to: 150,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 4,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $(".overallVerificationRequiredContainer").height();
            //$(window).resize(function () {
            //    newh = $(".overallVerificationRequiredContainer").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('overallVerificationRequiredContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 150,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [dashboardData.TodoTotalCountByAllClaimTypes],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '2') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#E1F4FB'

            },
            title: {
                text: 'Roll Back',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 10,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 10,
                    to: 25,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 25,
                    to: 50,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 6,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart2;
        $(function () {
            //var new2 = $("#overallProgress").height();
            //$(window).resize(function () {
            //    new2 = $("#overallProgress").height();
            //    chart2.redraw();
            //    chart2.reflow();
            //});
            chart2 = new Highcharts.chart('overallRollBackContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 50,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed', 
                    data: [dashboardData.RollbackTotalCountByAllClaimTypes],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '3') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#E1F4FB'

            },
            title: {
                text: 'Optional Verification',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },


            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 20,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 20,
                    to: 50,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 50,
                    to: 100,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 5,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#overallProgress").height();
            //$(window).resize(function () {
            //    newh = $("#overallProgress").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('overallOptionalVerificationContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 100,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [dashboardData.CompletedTotalCountByAllClaimTypes],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '4') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Verification Required',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 8,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 8,
                    to: 20,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 20,
                    to: 40,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 5,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#cms1500").height();
            //$(window).resize(function () {
            //    newh = $("#cms1500").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('cmsVerificationRequiredContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 40,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [10],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '5') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Roll Back',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 2,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 2,
                    to: 5,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 5,
                    to: 10,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 6,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#cms1500").height();
            //$(window).resize(function () {
            //    newh = $("#cms1500").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('cmsRollBackContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 10,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [0],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '6') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Optional Verification',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 8,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 8,
                    to: 20,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 20,
                    to: 40,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 5,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#cms1500").height();
            //$(window).resize(function () {
            //    newh = $("#cms1500").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('cmsOptionalVerificationContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 40,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [30],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '7') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Verification Required',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 12,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 12,
                    to: 30,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 30,
                    to: 60,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 4,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#ub04").height();
            //$(window).resize(function () {
            //    newh = $("#ub04").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('ub04VerificationRequiredContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 60,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [20],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '8') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Roll Back',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 4,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 4,
                    to: 10,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 10,
                    to: 20,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 6,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#ub04").height();
            //$(window).resize(function () {
            //    newh = $("#ub04").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('ub04RollBackContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 20,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [5],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '9') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Optional Verification',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 8,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 8,
                    to: 20,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 20,
                    to: 40,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 5,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#ub04").height();
            //$(window).resize(function () {
            //    newh = $("#ub04").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('ub04OptionalVerificationContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 40,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [30],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '10') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Verification Required',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 10,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 10,
                    to: 25,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 25,
                    to: 50,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 6,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#dentalClaims").height();
            //$(window).resize(function () {
            //    newh = $("#dentalClaims").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('dcVerificationRequiredContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 50,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [20],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '11') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Roll Back',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 4,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 4,
                    to: 10,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 10,
                    to: 20,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 5,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#dentalClaims").height();
            //$(window).resize(function () {
            //    newh = $("#dentalClaims").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('dcRollBackContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 20,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [10],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '12') {
        var gaugeOptions = {
            chart: {
                type: 'gauge',
                borderRadius: '10px', backgroundColor: '#F0F0F0'

            },
            title: {
                text: 'Optional Verification',
                style: {
                    color: '#484b4f',
                    font: "Segoe UI",
                    fontSize: '14px',
                    fontWeight: 'bold'
                }
            },

            pane: {
                center: ['50%', '70%'],
                size: '170%',
                startAngle: -90,
                endAngle: 90,
                background: {
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                    innerRadius: '60%',
                    outerRadius: '100%',
                    shape: 'arc'
                }
            },

            tooltip: {
                enabled: false
            },

            // the value axis
            yAxis: {
                plotBands: [{
                    from: 0,
                    to: 4,
                    color: '#FF0000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 4,
                    to: 10,
                    color: '#FFFF00',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }, {
                    from: 10,
                    to: 20,
                    color: '#008000',
                    innerRadius: '60%',
                    outerRadius: '100%'
                }],
                lineWidth: 0,
                minorTickInterval: null,
                tickAmount: 5,
                title: {
                    y: 0
                },
                labels: {
                    y: 0,
                    distance: -40,
                    style: {
                        color: '#484b4f',
                        fontSize: '10px'
                    },
                    step: 1
                }
            },

            plotOptions: {
                gauge: {
                    dataLabels: {
                        y: 35,
                        borderWidth: 0,
                        useHTML: true
                    }
                }
            }
        };
        var chart1;
        $(function () {
            //var newh = $("#dentalClaims").height();
            //$(window).resize(function () {
            //    newh = $("#dentalClaims").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('dcOptionalVerificationContainer', Highcharts.merge(gaugeOptions, {
                yAxis: {
                    min: 0,
                    max: 20,
                    title: {
                        text: null
                    }
                },

                credits: {
                    enabled: false
                },

                series: [{
                    name: 'Speed',
                    data: [20],
                    dataLabels: {
                        format: '<div style="text-align:center"><span style="font-size:15px;color:' +
                            ((Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black') + '">{y}</span><br/>' +
                            '</div>'
                    }
                }]

            }));
        });
    }
    else if (number == '13') {
        var chart1;
        $(function () {
            //var newh = $("#allocatedVsCompleted").height();
            //$(window).resize(function () {
            //    newh = $("#allocatedVsCompleted").height();
            //    chart1.redraw();
            //    chart1.reflow();
            //});
            chart1 = new Highcharts.chart('allocatedVsCompletedContainer', {
                chart: {
                    type: 'area',
                    borderRadius: '10px', backgroundColor: '#F0F0F0'

                },
                title: {
                    text: 'Allocated Vs Completed'
                },
                xAxis: {
                    categories: ['15-11-2018', '16-11-2018', '17-11-2018', '18-11-2018', '19-11-2018', '20-11-2018', '21-11-2018'],
                    tickmarkPlacement: 'on',
                    title: {
                        enabled: false
                    }
                },
                yAxis: {
                    title: {
                        text: 'Count'
                    },
                    labels: {
                        formatter: function () {
                            return this.value;
                        }
                    }
                },
                tooltip: {
                    split: true,

                },
                plotOptions: {
                    area: {
                        stacking: 'normal',
                        lineColor: '#666666',
                        lineWidth: 1,
                        marker: {
                            lineWidth: 1,
                            lineColor: '#666666'
                        }
                    }
                },
                credits: {
                    enabled: false
                },
                series: [{
                    name: 'Allocated',
                    data: [20, 10, 50, 20, 80, 60, 70],
                    color: '#837050'
                }, {
                    name: 'Completed',
                    data: [10, 5, 45, 40, 60, 30, 50],
                    color: '#E6BC5C'
                }]
            });
        });
    }
    else if (number == '13') {
        //$(function () {
        //    var newh = $("#importantLinks").height();
        //    $(window).resize(function () {
        //        newh = $("#importantLinks").height();
        //        $("#importantLinksContainer").height() = newh;
        //    });
        //});
    }
}