function search() {
   let towns = document.querySelectorAll('ul#towns li');
   let searchText = document.getElementById('searchText').value;

    let count = 0;

   for (let i = 0; i < towns.length; i++) {
      if (towns[i].textContent.includes(searchText)) {
         towns[i].style.textDecoration = 'underline';
         towns[i].style.fontWeight = 'bold';
         console.log(towns[i].textContent);
         count++;
      }
   }
   document.getElementById('result').textContent = `${count} matches found`;
}