function solve() {
   let buttonsAdd = document.querySelectorAll('button[class = "add-product"]');
   let result = document.querySelector('textarea')
   let buttonCheckout = document.querySelector('button[class = "checkout"]');

   let allProductInfos;
   let productDetails;
   let productName;
   let productPrice;
   let allProductWithPrice = {};

   for (const button of buttonsAdd) {
      button.addEventListener('click', (e) => {

         allProductInfos = (e.currentTarget.parentNode.parentNode).children;
         productDetails = allProductInfos[1];
         productName = ((productDetails.children)[0]).textContent;
         productPrice = Number((allProductInfos[3]).textContent);
         console.log(productName);
         console.log(productPrice);

         if (allProductWithPrice[productName] == null) {
            allProductWithPrice[productName] = productPrice;

         } else {
            allProductWithPrice[productName] += productPrice;
         }
         result.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
      });
   }
   let allSum = 0;
   let count = 0;
   let listOfProducts;
   buttonCheckout.addEventListener('click', () => {

      if (count == 0) {

         listOfProducts = (Object.keys(allProductWithPrice)).join(', ');
         (Object.values(allProductWithPrice)).forEach(x => {
            allSum += x;
         })
         count++;
         console.log(count);
         result.textContent += `You bought ${listOfProducts} for ${allSum.toFixed(2)}.`
      } else {

         for (const button of buttonsAdd) {
            button.disabled = true;
         }
      }
   })

}