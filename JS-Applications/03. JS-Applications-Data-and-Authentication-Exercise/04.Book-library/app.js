let buttonLoadAllBooks = document.getElementById('loadBooks');
let parentElement = document.querySelector('tbody');
let h3Element = document.querySelector('h3');
let formElement = document.querySelector('form');
let urlAllBooks = 'http://localhost:3030/jsonstore/collections/books';
let urlEdit = 'http://localhost:3030/jsonstore/collections/books/';

buttonLoadAllBooks.addEventListener('click', () => {
    parentElement.textContent = '';
    fetch(urlAllBooks)
        .then(res => res.json())
        .then(books => {
            Object.values(books).forEach(book => {

                let createTrElement = document.createElement('tr');

                let createTdElementTitle = document.createElement('td');
                createTdElementTitle.textContent = book.title;
                createTrElement.appendChild(createTdElementTitle);

                let createTdElementAuthor = document.createElement('td');
                createTdElementAuthor.textContent = book.author;
                createTrElement.appendChild(createTdElementAuthor);

                let createTdElementWithButtons = document.createElement('td');
                let createEditButton = document.createElement('button');
                createEditButton.textContent = 'Edit';
                let createDeleteButton = document.createElement('button');
                createDeleteButton.textContent = 'Delete';

                createEditButton.addEventListener('click', functionEdit);

                createDeleteButton.addEventListener('click', functionDelete);

                createTdElementWithButtons.appendChild(createEditButton);
                createTdElementWithButtons.appendChild(createDeleteButton);
                createTrElement.appendChild(createTdElementWithButtons);

                parentElement.appendChild(createTrElement);
            })
        })
})

function functionEdit(event) {
    let title = event.currentTarget.parentNode.parentNode.children[0].textContent;
    let author = event.currentTarget.parentNode.parentNode.children[1].textContent;

    h3Element.textContent = 'Edit FORM';
    formElement.querySelector('input[name = "title"]').value = title;
    formElement.querySelector('input[name = "author"]').value = author;
    let submitButton = formElement.querySelector('button');
    submitButton.textContent = 'Save';

    let idForEdit;
    fetch(urlAllBooks)
        .then(res => res.json())
        .then(books => {

            Object.keys(books).forEach(x => {
                if (books[x].author == author && books[x].title == title) {
                    idForEdit = x;
                }
            });
            console.log(idForEdit);


            submitButton.addEventListener('click', (e) => {
                e.preventDefault();
               
                console.log(title);
                fetch(`${urlEdit}${idForEdit}`, {
                    method: 'PUT',
                    headers: {
                        'content-type': 'application/json'
                    },
                    body: JSON.stringify({
                        "author": title,
                        "title": author

                    })
                })

                submitButton.textContent = 'FORM';
                title = '';
                author = '';
            })


        })
    buttonLoadAllBooks.click();

    // formElement.addEventListener('submit', (e) => {
    //     e.preventDefault();
    //     let formData = new FormData(e.currentTarget);
    //     formData.get('title').textContent = title;

    // })
    // console.log(title);

    // console.log(author);
}

function functionDelete() {

}
// <tr>
// <td>Harry Poter</td>
// <td>J. K. Rowling</td>
// <td>
//     <button>Edit</button>
//     <button>Delete</button>
// </td>
// </tr>
// <tr>