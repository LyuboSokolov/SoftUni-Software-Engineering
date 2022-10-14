function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let inputText = document.getElementById('searchField');
      let elementsInTable = document.querySelectorAll('table.container tbody tr');

      for (let i = 0; i < elementsInTable.length; i++) {

         if (elementsInTable[i].textContent.includes(inputText.value)) {
            elementsInTable[i].classList.add('select');
         } else {
            elementsInTable[i].classList.remove('select');
         }
      }
      if (inputText.value != null) {
         inputText.value = null;
      }
   }
}