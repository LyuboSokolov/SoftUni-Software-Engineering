function validate() {
    let inputEmail = document.getElementById('email');

    let regex = new RegExp('[a-z]+@[a-z]+[.][a-z]+');

    inputEmail.addEventListener("change", (e) => {
        if (regex.test(inputEmail.value)) {
            e.currentTarget.classList.remove('error');
        } else {
            e.currentTarget.classList.add('error');
        }
    });
}