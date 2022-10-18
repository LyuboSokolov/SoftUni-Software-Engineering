function lockedProfile() {
    let allButtonsShow = document.querySelectorAll('button');

    for (const button of allButtonsShow) {
        button.addEventListener('click', (e) => {
            let currentUser = (e.currentTarget.parentNode.children)[2].name;
            let currentButtonShow = (e.currentTarget.parentNode.children)[10];
            let currentHiddenDiv = (e.currentTarget.parentNode.children)[9];
            let radioButtons = document.querySelectorAll(`input[name = "${currentUser}"]`);

            for (const radioButton of radioButtons) {
                
                if (radioButton.checked && radioButton.value == 'unlock') {
                    if (currentHiddenDiv.style.display != "inline") {
                        currentHiddenDiv.style.display = "inline";
                        currentButtonShow.textContent = 'Hide it';
                    } else {
                        currentHiddenDiv.style.display = 'none';
                        currentButtonShow.textContent = 'Show more';
                    }
                }
            }
        })
    }
}