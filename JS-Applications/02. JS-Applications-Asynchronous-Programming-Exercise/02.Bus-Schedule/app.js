function solve() {

    let buttonDepart = document.getElementById('depart');
    let buttonArrive = document.getElementById('arrive');
    let infoBox = document.querySelector('.info');
    let stopName;
    let nextStop = 'depot';

    function depart() {
        buttonDepart.disabled = true;
        buttonArrive.disabled = false;

        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStop}`)
            .then(res => res.json())
            .then((data) => {
                infoBox.textContent = `Next stop ${data['name']}`;
                stopName = data['name'];
                nextStop = data['next']
            })
            .catch(() => {
                buttonDepart.disabled = true;
                buttonArrive.disabled = true;
                infoBox.textContent = 'Error';
            })
    }

    function arrive() {
        buttonDepart.disabled = false;
        buttonArrive.disabled = true;
        infoBox.textContent = `Arriving at ${stopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();