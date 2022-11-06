function getInfo() {
    let inputId = document.getElementById('stopId');
    let divStopName = document.getElementById('stopName');
    let busesElement = document.getElementById('buses');

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${inputId.value}`)
        .then(res => res.json())
        .then((data) => {
            busesElement.innerHTML = '';
            divStopName.textContent = data['name'];
            for (const key in data['buses']) {
                let createLiElement = document.createElement('li');
                createLiElement.textContent = `Bus ${key} arrives in ${data['buses'][key]} minutes`;
                busesElement.appendChild(createLiElement);
            }
        })
        .catch(() => {
            busesElement.innerHTML = '';
            divStopName.textContent = 'Error'
        });
}