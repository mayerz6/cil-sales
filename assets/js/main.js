 let chart = document.getElementById('myChart').getContext('2d');
let orderMetrics = document.getElementById('orderMetrics');
let button = document.getElementById('alert')


let orderChart = new Chart(chart, {
    type: 'bar',
    data: {
        labels: ['Orders Processed'],
        datasets: [
            {
                label: "Monthly Orders Processed",
                backgroundColor: "#0000ff",
                data: [orderMetrics.textContent], // data["TO"] -> 03/03/2020 
                borderWidth: 1
            },
            {
                label: "Monthly Target Orders",
                backgroundColor: "#ffa500",
                data: [22660],
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
        responsive: false,
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
