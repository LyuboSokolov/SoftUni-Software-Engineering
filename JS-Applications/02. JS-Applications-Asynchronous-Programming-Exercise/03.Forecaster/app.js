function attachEvents() {
    let inputLocation = document.getElementById('location');
    let buttonSubmit = document.getElementById('submit');
    let divForecast = document.getElementById('forecast');
    let divCurrent = document.getElementById('current');
    let divUpcoming = document.getElementById('upcoming');
    let divContent = document.getElementById('content');

    let createDiv = document.createElement('div');
    createDiv.id = 'error';
    createDiv.textContent = 'Error';
    let isError = false;
    buttonSubmit.addEventListener('click', () => {

        fetch('http://localhost:3030/jsonstore/forecaster/locations')
            .then(res => res.json())
            .then((data) => {

                let currentLocation = data.find(x => x['name'] == inputLocation.value);

                if (currentLocation) {
                    createDiv.remove();
                    let code = currentLocation['code'];
                    fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`)
                        .then(res => res.json())
                        .then((data) => {

                            divCurrent.textContent = '';
                            let createDivForecasts = document.createElement('div');
                            createDivForecasts.classList.add('forecasts');

                            let createSpanConditionSymbol = document.createElement('span');
                            createSpanConditionSymbol.classList.add('conditon', 'symbol');

                            let weatherSymbol;
                            let condition = data['forecast']['condition'];

                            switch (condition) {
                                case 'Sunny': weatherSymbol = '&#x2600'; break;
                                case 'Partly sunny': weatherSymbol = '&#x26C5'; break;
                                case 'Overcast': weatherSymbol = '&#x2601'; break;
                                case 'Rain': weatherSymbol = '&#x2614'; break;
                                case 'Degrees': weatherSymbol = '&#176'; break;
                                default:
                                    break;
                            }
                            createSpanConditionSymbol.innerHTML = weatherSymbol;

                            createDivForecasts.appendChild(createSpanConditionSymbol);

                            let createSpanConditon = document.createElement('span');
                            createSpanConditon.classList.add('condition');

                            let createSpanLocation = document.createElement('span');
                            createSpanLocation.classList.add('forecast-data');
                            createSpanLocation.textContent = data['name'];
                            createSpanConditon.appendChild(createSpanLocation);

                            let createSpanDegree = document.createElement('span');
                            createSpanDegree.classList.add('forecast-data');
                            createSpanDegree.innerHTML = `${data['forecast']['low']}&#176/${data['forecast']['high']}&#176`;
                            createSpanConditon.appendChild(createSpanDegree);


                            let createSpanWether = document.createElement('span');
                            createSpanWether.classList.add('forecast-data');
                            createSpanWether.textContent = `${data['forecast']['condition']}`;
                            createSpanConditon.appendChild(createSpanWether);

                            createDivForecasts.appendChild(createSpanConditon);

                            divCurrent.appendChild(createDivForecasts);
                        })


                    fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`)
                        .then(res => res.json())
                        .then((data) => {

                            divUpcoming.textContent = '';
                            let createDivForecastInfo = document.createElement('div');
                            createDivForecastInfo.classList.add('forecast-info');

                            for (const key in data['forecast']) {

                                let weatherSymbol;
                                let condition = data['forecast'][key]['condition'];

                                switch (condition) {
                                    case 'Sunny': weatherSymbol = '&#x2600'; break;
                                    case 'Partly sunny': weatherSymbol = '&#x26C5'; break;
                                    case 'Overcast': weatherSymbol = '&#x2601'; break;
                                    case 'Rain': weatherSymbol = '&#x2614'; break;
                                    case 'Degrees': weatherSymbol = '&#176'; break;
                                    default:
                                        break;
                                }
                                let createSpanUpcoming = document.createElement('span');
                                createSpanUpcoming.classList.add('upcoming');

                                let createSpanSymbol = document.createElement('span');
                                createSpanSymbol.classList.add('symbol');
                                createSpanSymbol.innerHTML = weatherSymbol;
                                createSpanUpcoming.appendChild(createSpanSymbol);

                                let createSpanForecastData = document.createElement('span');
                                createSpanForecastData.classList.add('forecast-data');
                                createSpanForecastData.innerHTML = `${data['forecast'][key]['low']}&#176/${data['forecast'][key]['high']}&#176`
                                createSpanUpcoming.appendChild(createSpanForecastData);

                                let createSpanForecast = document.createElement('span');
                                createSpanForecast.classList.add('forecast-data');
                                createSpanForecast.textContent = `${data['forecast'][key]['condition']}`;
                                createSpanUpcoming.appendChild(createSpanForecast);

                                createDivForecastInfo.appendChild(createSpanUpcoming);
                            }
                            divUpcoming.appendChild(createDivForecastInfo);
                        })
                    divForecast.style.display = 'block';
                    isError = false;
                } else {

                    if (!isError) {
                        divForecast.style.display = 'none';
                        createDiv = document.createElement('div');
                        createDiv.id = 'error';
                        createDiv.textContent = 'Error';
                        divContent.appendChild(createDiv);
                        isError = true;
                    }
                }
            })
            .catch(() => {
                createDiv = document.createElement('div');
                createDiv.id = 'error';
                createDiv.textContent = 'Error';
            })
    })
}
attachEvents();