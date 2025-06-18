document.addEventListener("DOMContentLoaded", function () {
    new Chart(document.getElementById('ordersChart').getContext('2d'), {
        type: 'bar',
        data: {
            labels: ordersLabels,
            datasets: [{
                label: 'Orders per maand',
                data: ordersData,
                backgroundColor: 'rgba(54, 162, 235, 0.5)'
            }]
        }
    });

    new Chart(document.getElementById('customersChart').getContext('2d'), {
        type: 'line',
        data: {
            labels: customersLabels,
            datasets: [{
                label: 'Klanten geregistreerd per maand',
                data: customersData,
                backgroundColor: 'rgba(255, 99, 132, 0.5)'
            }]
        }
    });
});
