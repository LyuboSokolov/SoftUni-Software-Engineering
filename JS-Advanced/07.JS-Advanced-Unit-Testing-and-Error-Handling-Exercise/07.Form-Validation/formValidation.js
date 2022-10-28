function validate() {
    let inputUsername = document.getElementById('username');
    let inputEmail = document.getElementById('email');
    let inputPassword = document.getElementById('password');
    let inputPasswordConfirm = document.getElementById('confirm-password');
    let hiddenDiv = document.getElementById('valid');
    let isCompaniCheckBox = document.getElementById('company');
    let regexUsername = new RegExp('[A-Za-z0-9]*');
    let regexPassword = new RegExp('\w*');
    let regexEmail = new RegExp('\w*@\w*\.+\w*');

    let buttonSubmit = document.getElementById('submit');
    buttonSubmit.addEventListener('click', (e) => {
        e.preventDefault();
        inputValidation();
    })
    let isValidUsername = false;
    let isValidEmail = false;
    let isValidPassword = false;
    let isvalidPasswordConfirm = false;

    function inputValidation() {
        if (regexUsername.test(inputUsername.value) && (inputUsername.value.length >= 3 && inputUsername.value.length <= 20)) {
            inputUsername.style.borderColor = "";
           
            isValidUsername = true;

        } else {
          
            inputUsername.style.borderColor = "red";
            isValidUsername = false;
         
        }
        if (regexEmail.test(inputEmail.value)) {
            inputEmail.style.borderColor = '';
            isValidEmail = true;
        } else {
            
            inputEmail.style.borderColor = 'red';
            isValidEmail = false;

        }
        if (regexPassword.test(inputPassword.value) &&
            (inputPassword.value.length >= 5 && inputPassword.value.length <= 15)) {
            inputPassword.style.borderColor = '';
            isValidPassword = true;
        } else {
     
            inputPassword.style.borderColor = 'red';
            isValidPassword = false;
        }
        if (isValidPassword && (inputPassword.value == inputPasswordConfirm.value)) {
            inputPasswordConfirm.style.borderColor = '';
            isvalidPasswordConfirm = true;
        } else {
          
            inputPasswordConfirm.style.borderColor = 'red';
            isvalidPasswordConfirm = false;
        }
        let allInputIsValid = false;
        if (isValidUsername && isValidEmail && isValidPassword && isvalidPasswordConfirm) {
            hiddenDiv.style.display = 'block';
            allInputIsValid = true;
        } else {
            hiddenDiv.style.display = 'none';
            allInputIsValid = false;
        }
        let companyNumberElement = document.getElementById('companyInfo');
        let inputCompanyNumber = document.getElementById('companyNumber');

        if (allInputIsValid) {
            if (isCompaniCheckBox.checked) {
                companyNumberElement.style.display = 'block';
                hiddenDiv.style.display = 'none';
                inputCompanyNumber.style.borderColor = 'red';

                if (inputCompanyNumber.value >= 1000 && inputCompanyNumber.value <= 9999) {
                    inputCompanyNumber.style.borderColor = '';
                    hiddenDiv.style.display = 'block';
                }
            } else {
                companyNumberElement.style.display = 'none';
            }
        } else {
            companyNumberElement.style.display = 'none';
        }
    }
}
