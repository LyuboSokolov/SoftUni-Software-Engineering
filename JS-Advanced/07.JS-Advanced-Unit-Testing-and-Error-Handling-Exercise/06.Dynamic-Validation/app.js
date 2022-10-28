function validate() {

    let regex = new RegExp('[a-z]+@[a-z]+[.][a-z]+');
    let inputText = document.getElementById('email');

    inputText.addEventListener('change', () => {
       
        if (regex.test(inputText.value)) {
            inputText.value = '';
            inputText.classList.remove('error');
        } else {
            inputText.classList.add('error');
            console.log(inputText.value);
        }
    })
}