function toggle() {
    let buttonStatus = document.querySelector('.button');
    let statusText = document.getElementById('extra');

    if (buttonStatus.textContent == 'More') {
        buttonStatus.textContent = 'Less';
        statusText.style.display = 'block';
    } else {
        buttonStatus.textContent = 'More';
        statusText.style.display = 'none';
        console.log(2);
    }
}