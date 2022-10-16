function focused() {
    let inputElements = document.querySelectorAll('input');
    let elementsArray = Array.from(inputElements);

    elementsArray.forEach(x => x.addEventListener('focus', (e) => {
        e.currentTarget.parentNode.classList.add('focused');
    }));

    elementsArray.forEach(x => x.addEventListener('blur', (e) => {
        e.currentTarget.parentNode.classList.remove('focused');
    }));
}