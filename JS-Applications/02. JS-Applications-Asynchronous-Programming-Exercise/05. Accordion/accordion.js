function solution() {
    let parentElement = document.getElementById('main');
    let urlTitles = 'http://localhost:3030/jsonstore/advanced/articles/list';
    let urlDesc = 'http://localhost:3030/jsonstore/advanced/articles/details/';

    fetch(urlTitles)
        .then(res => res.json())
        .then((data) => {
            Object.values(data).forEach(title => {

                let createDivWithClassAccordion = document.createElement('div');
                createDivWithClassAccordion.classList.add('accordion');

                let createDivWithClassHead = document.createElement('div');
                createDivWithClassHead.classList.add('head');

                let createSpanWithTitle = document.createElement('span');
                createSpanWithTitle.textContent = title['title'];
                createDivWithClassHead.appendChild(createSpanWithTitle);

                let button = document.createElement('button');
                button.id = title['_id'];
                button.textContent = 'More';
                button.classList.add('button');

                let createDivWithClassExtra = document.createElement('div');
                createDivWithClassExtra.classList.add('extra');

                let createPElement = document.createElement('p');

                fetch(`${urlDesc}${title['_id']}`)
                    .then(res => res.json())
                    .then((desc) => {
                        createPElement.textContent = desc['content'];
                    })

                createDivWithClassExtra.appendChild(createPElement);

                button.addEventListener('click', () => {
                    if (createDivWithClassExtra.classList.contains('extra')) {
                        button.textContent = 'Less'
                        createDivWithClassExtra.classList.remove('extra');
                    } else {
                        button.textContent = 'More'
                        createDivWithClassExtra.classList.add('extra');
                    }
                });

                createDivWithClassHead.appendChild(button);

                createDivWithClassAccordion.appendChild(createDivWithClassHead);
                createDivWithClassAccordion.appendChild(createDivWithClassExtra);

                parentElement.appendChild(createDivWithClassAccordion);
            })
        })
}
solution();