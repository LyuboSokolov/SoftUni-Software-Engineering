function addItem() {
    let inputElement = document.getElementById('newItemText');
    let items = document.getElementById('items');

    let liElement = document.createElement('li');
    let aElement = document.createElement('a');
    liElement.textContent = inputElement.value;

    aElement.textContent = '[Delete]';
    aElement.href = '#';
    aElement.addEventListener('click', (e) => {
        e.currentTarget.parentNode.remove();
    });
    liElement.appendChild(aElement);

    items.appendChild(liElement);
}