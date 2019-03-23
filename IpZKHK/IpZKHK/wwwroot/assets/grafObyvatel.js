var ctx = document.getElementById('prostorProGraf');
var myChart = new Chart(ctx, {
    type: 'horizontalBar',
    data: {
        labels: ['0-14', '14-64', '65+'],
        datasets: [{
            label: 'Počet obyvatel ve věku',
            data: [250,250,300],
            backgroundColor: [
                'rgba(90, 190,20, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(180, 5, 5, 0.2)',
                                    ],
            borderColor: [
                'rgba(90, 190,20, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(180, 5, 5, 1)',
                                   ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            xAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});


document.getElementById("CelkemPocet").innerHTML = "Celkem: <b>" + (250 + 250 + 300) + "</b> obyvatel.";
