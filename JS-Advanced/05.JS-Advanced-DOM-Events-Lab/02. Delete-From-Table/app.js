function deleteByEmail() {
    let emailsElements = document.querySelectorAll('td:nth-of-type(2n)');
    let inputText = document.querySelector('input[name=email]');
    let result = document.getElementById('result');

    let emails = Array.from(emailsElements);
    let findElement = emails.find(x => x.textContent == inputText.value);

    if (findElement) {
        findElement.parentNode.remove();
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }
}