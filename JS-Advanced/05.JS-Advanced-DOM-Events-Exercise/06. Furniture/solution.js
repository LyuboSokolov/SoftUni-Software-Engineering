function solve() {
  let buttons = document.querySelectorAll('button');
  let generateButton = buttons[0];
  let buyButton = buttons[1];
  let tableBody = document.querySelector('tbody');

  generateButton.addEventListener('click', () => {

    let inputInfos = document.querySelector('textarea');
    let infos = JSON.parse(inputInfos.value);

    for (const productInfos of infos) {
      let img = productInfos.img;
      let name = productInfos.name;
      let price = productInfos.price;
      let decFactor = productInfos.decFactor;

      let createTrTag = document.createElement('tr');

      let tdTagWitgImage = document.createElement('td');
      let imageTag = document.createElement('img');
      imageTag.src = img;
      tdTagWitgImage.appendChild(imageTag);
      createTrTag.appendChild(tdTagWitgImage);

      let tdTagwithName = document.createElement('td');
      let pTagWithName = document.createElement('p');
      pTagWithName.textContent = name;
      tdTagwithName.appendChild(pTagWithName);
      createTrTag.appendChild(tdTagwithName);

      let tdTagWithPrice = document.createElement('td');
      let pTagWithPrice = document.createElement('p');
      pTagWithPrice.textContent = price;
      tdTagWithPrice.appendChild(pTagWithPrice);
      createTrTag.appendChild(tdTagWithPrice);

      let tdTagWithDecFactor = document.createElement('td');
      let pTagWithDecFactor = document.createElement('p');
      pTagWithDecFactor.textContent = decFactor;
      tdTagWithDecFactor.appendChild(pTagWithDecFactor);
      createTrTag.appendChild(tdTagWithDecFactor);

      let tdTagWithInput = document.createElement('td');
      let inputTag = document.createElement('input');
      inputTag.type = 'checkbox';

      tdTagWithInput.appendChild(inputTag);
      createTrTag.appendChild(tdTagWithInput);
      tableBody.appendChild(createTrTag);
    }
  })

  buyButton.addEventListener('click', () => {
    let buyProductName = [];
    let totalPrice = 0;
    let averageDecFactor = 0;
    let allInput = document.querySelectorAll('input');
    let count = 0;

    for (const input of allInput) {
      
      if (input.checked) {
        count++;
        let currentProductInfo = (input.parentNode.parentNode).children;
        let currentProductName = (currentProductInfo[1].children)[0].textContent;
        buyProductName.push(currentProductName);

        let currentProductPrice = Number((currentProductInfo[2].children)[0].textContent);
        totalPrice += currentProductPrice;

        let currentProductDecFactor = Number((currentProductInfo[3].children)[0].textContent);
        averageDecFactor += currentProductDecFactor;
      }
    }
    averageDecFactor /= count;
    let resultTextArea = (document.querySelectorAll('textarea'))[1];
    let result = '';
    result += `Bought furniture: ${buyProductName.join(", ")}\n`;
    result += `Total price: ${totalPrice.toFixed(2)}\n`;
    result += `Average decoration factor: ${averageDecFactor}`;
    resultTextArea.textContent = result;
  })
}