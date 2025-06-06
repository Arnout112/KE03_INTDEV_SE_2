function renderDashboardCharts(ordersPerMonth, customersPerMonth) {
    const ordersLabels = ordersPerMonth.map(x => x.Month);
    const ordersData = ordersPerMonth.map(x => x.Count);

    const customersLabels = customersPerMonth.map(x => x.Month);
    const customersData = customersPerMonth.map(x => x.Count);

    const ctxOrders = document.getElementById('ordersChart');
    new Chart(ctxOrders, {
        type: 'bar',
        data: {
            labels: ordersLabels,
            datasets: [{
                label: 'Orders per maand',
                data: ordersData,
                backgroundColor: 'rgba(54, 162, 235, 0.5)'
            }]
        },
        options: {
            scales: {
                y: {
                    ticks: {
                        stepSize: 2
                    }
                }
            }
        }
    });

    const ctxCustomers = document.getElementById('customersChart');
    new Chart(ctxCustomers, {
        type: 'line',
        data: {
            labels: customersLabels,
            datasets: [{
                label: 'Klanten geregistreerd per maand',
                data: customersData,
                backgroundColor: 'rgba(255, 99, 132, 0.5)'
            }]
        },
        options: {
            scales: {
                y: {
                    ticks: {
                        stepSize: 2
                    }
                }
            }
        }
    });
}
