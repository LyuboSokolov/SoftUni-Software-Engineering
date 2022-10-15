function addItem() {
    let inputElement = document.getElementById('newItemText');
    let items = document.getElementById('items');
    let liElement = document.createElement('li');
    liElement.textContent = inputElement.value;
    items.appendChild(liElement);
}