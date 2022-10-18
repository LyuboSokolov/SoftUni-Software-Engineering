function attachEventsListeners() {

    let allButtons = document.querySelectorAll('input[type ="button"]');
    let inputDays = document.getElementById('days');
    let inputHours = document.getElementById('hours');
    let inputMinutes = document.getElementById('minutes');
    let inputSeconds = document.getElementById('seconds');

    let seconds = 0;
    let inputNumb = 0;
    let labelText = '';
    for (const button of allButtons) {
        button.addEventListener('click', (e) => {
            inputNumb = (e.currentTarget.parentNode.children)[1].value;
            labelText = (e.currentTarget.parentNode.children)[0].textContent;

            if (labelText == 'Days: ') {
                seconds = Number(inputNumb) * 86400;
            } else if (labelText == 'Hours: ') {
                seconds = Number(inputNumb) * 3600;
            } else if (labelText == 'Minutes: ') {
                seconds = Number(inputNumb) * 60;
            } else {
                seconds = Number(inputNumb);
            }
            inputSeconds.value = seconds;
            inputMinutes.value = seconds / 60;
            inputHours.value = seconds / 3600;
            inputDays.value = seconds / 86400;
        })
    }
}