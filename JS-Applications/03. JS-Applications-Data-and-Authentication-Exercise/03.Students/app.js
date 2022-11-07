let url = 'http://localhost:3030/jsonstore/collections/students';

let formInputElement = document.getElementById('form');
let submitButton = document.getElementById('submit');
let parrerntElement = document.getElementById('results').children[1];

submitButton.addEventListener('click', (event) => {

    event.preventDefault();

    let firstNameInput = formInputElement.querySelector('input[name = "firstName"');

    let lastName = formInputElement.querySelector('input[name = "lastName"');
    let facultyNumber = formInputElement.querySelector('input[name = "facultyNumber"');
    let grade = formInputElement.querySelector('input[name = "grade"');

    if (firstNameInput.value && lastName.value && facultyNumber.value &&
        Number.isInteger(Number(facultyNumber.value)) &&
        grade.value && !isNaN(grade.value)) {

        fetch(url, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                'firstName': firstNameInput.value,
                'lastName': lastName.value,
                'facultyNumber': facultyNumber.value,
                'grade': grade.value
            })
        })
        firstNameInput.value = '';
        lastName.value = '';
        facultyNumber.value = '';
        grade.value = '';

    }

    parrerntElement.textContent = '';
    fetch(url)
        .then(res => res.json())
        .then(data => {

            Object.values(data).forEach(x => {
                let trElement = document.createElement('tr');

                let thElementFirstName = document.createElement('th');
                thElementFirstName.textContent = x['firstName'];

                let thElementLastName = document.createElement('th');
                thElementLastName.textContent = x['lastName'];

                let thElementFacultyNumber = document.createElement('th');
                thElementFacultyNumber.textContent = x['facultyNumber'];

                let thElementGrade = document.createElement('th');
                thElementGrade.textContent = x['grade'];

                trElement.appendChild(thElementFirstName);
                trElement.appendChild(thElementLastName);
                trElement.appendChild(thElementFacultyNumber);
                trElement.appendChild(thElementGrade);

                parrerntElement.appendChild(trElement);
            })
        })

})