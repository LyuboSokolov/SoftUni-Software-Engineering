function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/phonebook';
    let deleteUrl = 'http://localhost:3030/jsonstore/phonebook/';

    let loadButton = document.getElementById('btnLoad');
    let ulPhoneBook = document.getElementById('phonebook');
    let createButton = document.getElementById('btnCreate');
    let inputPerson = document.getElementById('person');
    let inputPhone = document.getElementById('phone');


    loadButton.addEventListener('click', () => {
        ulPhoneBook.textContent = '';
        fetch(url)
            .then(res => res.json())
            .then(data => {
                Object.values(data).forEach(x => {
                    let liElement = document.createElement('li');
                    liElement.textContent = `${x['person']}:${x['phone']}`;

                    let createDeleteButton = document.createElement('button');
                    createDeleteButton.textContent = 'Delete';
                    createDeleteButton.id = x['_id'];
                    liElement.appendChild(createDeleteButton);

                    ulPhoneBook.appendChild(liElement);

                    createDeleteButton.addEventListener('click', deleteFunction);

                })
            })
    })
    function deleteFunction(event) {

        fetch(`${deleteUrl}${event.currentTarget.id}`, {
            method: 'DELETE'
        })
            .finally(() => {
                loadButton.click();
            });

    }

    createButton.addEventListener('click', () => {

        if (inputPerson.value && inputPhone.value) {
            fetch(url, {
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    "person": inputPerson.value,
                    "phone": inputPhone.value
                })
            })
        }
        inputPerson.value = '';
        inputPhone.value = '';
        loadButton.click();
    })
}

attachEvents();