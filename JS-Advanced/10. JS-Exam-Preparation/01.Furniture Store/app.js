window.addEventListener('load', solve);

function solve() {
    let buttonAdd = document.getElementById('add');
    let inputModel = document.getElementById('model');
    let inputYear = document.getElementById('year');
    let inputDescription = document.getElementById('description');
    let inputPrice = document.getElementById('price');
    let parentElement = document.getElementById('furniture-list');
    let totalPriceElement = document.querySelector('.total-price');

    buttonAdd.addEventListener('click', addFurniture);

    function addFurniture(e) {
        e.preventDefault();

        if (!(inputModel.value && inputDescription.value)) {
            return;
        }

        if ((Number(inputPrice.value)) <= 0 || (Number(inputYear.value)) <= 0) {
            return;
        }

        let createTrElementClassInfo = document.createElement('tr');
        createTrElementClassInfo.classList.add('info');
        let createTdElementModel = document.createElement('td');
        createTdElementModel.textContent = inputModel.value;
        let createTdElementPrice = document.createElement('td');
        createTdElementPrice.textContent = (Number(inputPrice.value)).toFixed(2);

        createTrElementClassInfo.appendChild(createTdElementModel);
        createTrElementClassInfo.appendChild(createTdElementPrice);

        let createTdElementWithButtons = document.createElement('td');
        let createButtonMoreInfo = document.createElement('button');
        createButtonMoreInfo.textContent = 'More Info';
        createButtonMoreInfo.classList.add('moreBtn');

        createButtonMoreInfo.addEventListener('click', (event) => {
            if (event.currentTarget.textContent == 'More Info') {
                event.currentTarget.textContent = 'Less Info';
                (event.currentTarget.parentElement.parentElement).nextSibling.style.display = 'contents';

            } else {
                event.currentTarget.textContent = 'More Info';
                (event.currentTarget.parentElement.parentElement).nextSibling.style.display = 'none';
            }
        })

        createTdElementWithButtons.appendChild(createButtonMoreInfo);

        let createButtonBuyIt = document.createElement('button');
        createButtonBuyIt.textContent = 'Buy it';
        createButtonBuyIt.classList.add('buyBtn');

        createButtonBuyIt.addEventListener('click', (ev) => {
            let currentRow = (ev.currentTarget.parentNode.parentNode).children;

            let currentPrice = Number(currentRow[1].textContent);
            let totalSum = Number(totalPriceElement.textContent) + currentPrice;
            totalPriceElement.textContent = totalSum.toFixed(2);
            ev.currentTarget.parentNode.parentNode.nextElementSibling.remove();
            ev.currentTarget.parentNode.parentNode.remove();

        })

        createTdElementWithButtons.appendChild(createButtonBuyIt);

        createTrElementClassInfo.appendChild(createTdElementWithButtons);

        parentElement.appendChild(createTrElementClassInfo);

        let createTrElementClassHide = document.createElement('tr');
        createTrElementClassHide.classList.add('hide');

        let createTdElementYear = document.createElement('td');
        createTdElementYear.textContent = `Year: ${inputYear.value}`;
        createTrElementClassHide.appendChild(createTdElementYear);

        let createTdElementDescription = document.createElement('td');
        createTdElementDescription.colSpan = "3";
        createTdElementDescription.textContent = `Description: ${inputDescription.value}`;
        createTrElementClassHide.appendChild(createTdElementDescription);
        parentElement.appendChild(createTrElementClassHide);

        inputModel.value = '';
        inputPrice.value = '';
        inputDescription.value = '';
        inputYear.value = '';
    }
}