function lockedProfile() {
    let divProfile = document.querySelector('.profile');
    let mainElement = document.getElementById('main');
    let url = 'http://localhost:3030/jsonstore/advanced/profiles';
    let count = 1;

    fetch(url)
        .then(res => res.json())
        .then((data) => {
            Object.values(data).forEach(person => {
                if (count == 1) {
                    let usernameInputBox = document.querySelector('input[name="user1Username"]');
                    usernameInputBox.value = person['username'];
                    let emailInputBox = document.querySelector('input[name="user1Email"]');
                    emailInputBox.value = person['email'];
                    let ageInputBox = document.querySelector('input[name="user1Age"]');
                    ageInputBox.value = person['age'];

                    let button = (usernameInputBox.parentNode).querySelector('button');

                    button.addEventListener('click', (e) => {

                        let unlockRadioInput = e.currentTarget.parentNode.querySelector('input[value="unlock"]');
                        let divWithHiddenClass = emailInputBox.parentNode;

                        if (unlockRadioInput.checked && button.textContent == 'Show more') {

                            divWithHiddenClass.classList.remove('hiddenInfo');
                            button.textContent = 'Hide it';
                        } else if (unlockRadioInput.checked && button.textContent == 'Hide it') {
                            divWithHiddenClass.classList.add('hiddenInfo');
                            button.textContent = 'Show more';
                        }
                    })
                } else {
                    let clone = divProfile.cloneNode(true);
                    mainElement.appendChild(clone);

                    let usernameInputBox = mainElement.lastChild.querySelector('input[name="user1Username"]');
                    usernameInputBox.value = person['username'];
                    let emailInputBox = mainElement.lastChild.querySelector('input[name="user1Email"]');
                    emailInputBox.value = person['email'];
                    let ageInputBox = mainElement.lastChild.querySelector('input[name="user1Age"]');
                    ageInputBox.value = person['age'];

                    let button = (usernameInputBox.parentNode).querySelector('button');

                    button.addEventListener('click', (e) => {

                        let unlockRadioInput = e.currentTarget.parentNode.querySelector('input[value="unlock"]');
                        let divWithHiddenClass = emailInputBox.parentNode;

                        if (unlockRadioInput.checked && button.textContent == 'Show more') {

                            divWithHiddenClass.classList.remove('hiddenInfo');
                            button.textContent = 'Hide it';
                        } else if (unlockRadioInput.checked && button.textContent == 'Hide it') {
                            divWithHiddenClass.classList.add('hiddenInfo');
                            button.textContent = 'Show more';
                        }
                    })
                }
                count++;
            });
        })
}