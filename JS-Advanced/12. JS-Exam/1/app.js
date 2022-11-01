function solve() {
    let hireWorkerButton = document.getElementById('add-worker');
    let firstNameInput = document.getElementById('fname');
    let lastNameInput = document.getElementById('lname');
    let emailInput = document.getElementById('email');
    let birthInput = document.getElementById('birth');
    let positionInput = document.getElementById('position');
    let salaryInput = document.getElementById('salary');
    let parentElement = document.getElementById('tbody');
    let messageElement = document.getElementById('message');
    let sumElement = document.getElementById('sum');

    hireWorkerButton.addEventListener('click', (e) => {
        e.preventDefault();
        if (!(firstNameInput.value && lastNameInput.value && emailInput.value &&
            birthInput.value && positionInput.value && salaryInput.value)) {
            return;
        }

        let firstName = firstNameInput.value;
        let lastName = lastNameInput.value;
        let email = emailInput.value;
        let birthDay = birthInput.value;
        let position = positionInput.value;
        let salary = Number(salaryInput.value);

        let createTrElement = document.createElement('tr');

        let createTdElementWithFirstName = document.createElement('td');
        createTdElementWithFirstName.textContent = firstNameInput.value;
        createTrElement.appendChild(createTdElementWithFirstName);

        let createTdElementWithLastName = document.createElement('td');
        createTdElementWithLastName.textContent = lastNameInput.value;
        createTrElement.appendChild(createTdElementWithLastName);

        let createTdElementWithEmail = document.createElement('td');
        createTdElementWithEmail.textContent = emailInput.value;
        createTrElement.appendChild(createTdElementWithEmail);

        let createTdElementWithBirth = document.createElement('td');
        createTdElementWithBirth.textContent = birthInput.value;
        createTrElement.appendChild(createTdElementWithBirth);

        let createTdElementWithPosition = document.createElement('td');
        createTdElementWithPosition.textContent = positionInput.value;
        createTrElement.appendChild(createTdElementWithPosition);

        let createTdElementWithSalary = document.createElement('td');
        createTdElementWithSalary.textContent = (Number(salaryInput.value)).toFixed(2);
        createTrElement.appendChild(createTdElementWithSalary);

        let createTdElementWithButtons = document.createElement('td');
        let createFiretButton = document.createElement('button');
        createFiretButton.classList.add('fired');
        createFiretButton.textContent = 'Fired';

        createFiretButton.addEventListener('click',(event) => {

            sumElement.textContent = (Number(sumElement.textContent) - salary).toFixed(2);
            event.currentTarget.parentElement.parentElement.remove();
           
        })

        createTdElementWithButtons.appendChild(createFiretButton);

        let createEditButton = document.createElement('button');
        createEditButton.classList.add('edit');
        createEditButton.textContent = 'Edit';

        createEditButton.addEventListener('click', (e) => {

            firstNameInput.value = firstName;
            lastNameInput.value = lastName;
            emailInput.value = email;
            birthInput.value = birthDay;
            positionInput.value = position;
            salaryInput.value = salary;
            sumElement.textContent = (Number(sumElement.textContent) - salary).toFixed(2);

            e.currentTarget.parentElement.parentElement.remove();
        })

        createTdElementWithButtons.appendChild(createEditButton);
        createTrElement.appendChild(createTdElementWithButtons);

        parentElement.appendChild(createTrElement);

        let currentSum = Number(sumElement.textContent) + Number(salaryInput.value);
        sumElement.textContent = currentSum.toFixed(2);

        firstNameInput.value = '';
        lastNameInput.value = '';
        emailInput.value = '';
        birthInput.value = '';
        positionInput.value = '';
        salaryInput.value = '';

    })
}
solve()