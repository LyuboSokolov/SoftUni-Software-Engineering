function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/messenger';

    let sentButton = document.getElementById('submit');
    let divControls = document.getElementById('controls');
    let inputNameElement = divControls.querySelector('input[name="author"]');
    let inputMessageElement = divControls.querySelector('input[name= "content"]');
    let refreshButton = document.getElementById('refresh');
    let messegesTextArea = document.getElementById('messages');

    sentButton.addEventListener('click', () => {

        if (inputNameElement.value && inputMessageElement.value) {

            fetch(url, {
                method: "POST",
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    author: inputNameElement.value,
                    content: inputMessageElement.value,
                })
            })
        }
        inputNameElement.value = '';
        inputMessageElement.value = '';
    })

    refreshButton.addEventListener('click', () => {

        fetch(url)
            .then(res => res.json())
            .then(data => {

                let result = [];

                Object.values(data).forEach(x => {
                    result.push(`${x['author']}: ${x['content']}`);
                });
                messegesTextArea.value = result.join('\n');
            })
    })
}
attachEvents();