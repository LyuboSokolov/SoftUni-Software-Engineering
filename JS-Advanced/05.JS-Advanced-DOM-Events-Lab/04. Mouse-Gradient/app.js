function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let result = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (e) => {
        result.textContent = Math.floor(e.offsetX / 3) + '%';
    })
}