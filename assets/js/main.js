let chart = document.getElementById('myChart').getContext('2d');
let chart1 = document.getElementById('myChart_2').getContext('2d');
let chart2 = document.getElementById('myChart_3').getContext('2d');

let orderMetrics = document.getElementById('orderMetrics');
let annualMetrics = document.getElementById('orderMetricTotals');



orderMetrics.addEventListener('DOMNodeInserted', () => {
    console.log(this.textContent);
});
// console.log(orderMetrics.textContent);



let orderChart2 = new Chart(chart2, {
    type: 'bar',
    data: {
        labels: ["January", "February", "March", "April", "May"],
        datasets: [
            {
                label: "2018",
                backgroundColor: "#0000FF",
                barThickness: 20,
                data: [25469, 22956, 24442, 23321, 25064], // Orders Processed in January [2017 to 2020] 
                borderWidth: 2
            },
            {
                label: "2019",
                backgroundColor: "#ffa500",
                barThickness: 20,
                data: [25843, 22540, 24635, 25504, 25543],
                borderWidth: 2
            },
            {
                label: "2020",
                backgroundColor: "#B4B5B2",
                borderColor: "#000000",
                barThickness: 20,
                data: [23237, 21711, 25097, 21503, orderMetrics.textContent],
                borderWidth: 4
            }
            //{
            //    label: "April",
            //    backgroundColor: "#60BD07",
            //    borderColor: "#000000",
            //    barThickness: 20,
            //    data: [23321, 25504, orderMetrics.textContent],
            //    borderWidth: 4
            //}
        ]
    },
    options: {
        responsive: true,
        maintainAspectRatio: true,
        scales: {
            xAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    //  labelString: 'Orders Processed'
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                },
                ticks: {
                    // beginAtZero: true,
                    // steps: 1000,
                    min: 0,
                    max: 30000,
                    //    stepValue: 80000
                }
            }]
        }
    }

});




let orderChart1 = new Chart(chart1, {
    type: 'bar',
    data: {
        labels: ['Total Orders'],
        datasets: [
            {
                label: "2018",
                backgroundColor: "#0000FF",
                barThickness: 108,
                data: [288450], // data["TO"] -> 03/03/2020 
                borderWidth: 2
            },
            {
                label: "2019",
                backgroundColor: "#ffa500",
                barThickness: 108,
                data: [285129],
                borderWidth: 2
            },
            {
                label: "2020",
                backgroundColor: "#FFFF00",
                borderColor: "#000000",
                barThickness: 108,
                data: [annualMetrics.textContent],
                borderWidth: 4
            }
        ]
    },
    options: {
        responsive: true,
        maintainAspectRatio: true,
        scales: {
            xAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    //  labelString: 'Orders Processed'
                }
            }],
            yAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                },
                ticks: {
                    // beginAtZero: true,
                    // steps: 1000,
                    min: 0,
                    max: 300000,
                    //    stepValue: 80000
                }
            }]
        }
    }

});


let orderChart = new Chart(chart, {
    type: 'bar',
    data: {
        labels: ['Orders Processed'],
        datasets: [
            {
                label: "Monthly Orders Processed",
                backgroundColor: "#0000ff",
                borderColor: "#000000",
                data: [orderMetrics.textContent], // data["TO"] -> 03/03/2020 
                borderWidth: 4
            },
            {
                label: "Monthly Target Orders",
                backgroundColor: "#ffa500",
                data: [24080],
                borderWidth: 1
            },
            {
                label: "Monthly Super Bonus",
                backgroundColor: "#9f9fac",
                data: [25000],
                borderWidth: 1
            }
        ]
    },
    options: {
        responsive: true,
        maintainAspectRatio: true,
        scales: {
            xAxes: [{
                display: true,
                scaleLabel: {
                    display: true,
                    //  labelString: 'Orders Processed'
                }
            }],
            yAxes: [{
                display: true,
                ticks: {
                    // beginAtZero: true,
                    // steps: 1000,
                    min: 0,
                    max: 30000,
                    stepValue: 10000
                }
            }]
        }
    }

});
