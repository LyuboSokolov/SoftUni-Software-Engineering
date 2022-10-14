function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('div#inputs textarea').value);
      let result = [];

      for (let i = 0; i < input.length; i++) {

         let inputSplited = input[i].split(' - ');
         let restorantName = inputSplited[0];
         let workersAndSalaries = inputSplited[1].split(',');

         let currentRestorant = [];
         let isAlreadyRestorant = false;

         for (let k = 0; k < result.length; k++) {

            if (result[k][0] == restorantName) {
               currentRestorant = result[k];
               isAlreadyRestorant = true;
               break;
            }
         }
         if (!isAlreadyRestorant) {
            currentRestorant = [restorantName];
         }

         for (let j = 0; j < workersAndSalaries.length; j++) {

            let currentWorkerAndSalary = workersAndSalaries[j].split(' ').filter(x => x != '');
            let workerName = currentWorkerAndSalary[0];
            let workerSalary = currentWorkerAndSalary[1];
            currentRestorant.push(workerName, workerSalary);
         };
         if (!isAlreadyRestorant) {
            result.push(currentRestorant);
         }
      }

      let bestAverageSalary = 0;
      let indexBestRestorant = 0;

      for (let row = 0; row < result.length; row++) {

         let currentBestSalary = 0;
         let currentBestAverageSalary = 0;
         let count = 0;

         for (let col = 2; col < result[row].length; col += 2) {
            count++;
            currentBestSalary += Number(result[row][col]);
         }
         currentBestAverageSalary = currentBestSalary / count;

         if (bestAverageSalary < currentBestAverageSalary) {
            bestAverageSalary = currentBestAverageSalary;
            indexBestRestorant = row;
         }
      }

      let workers = {};
      bestRestorantAndWorkers = result[indexBestRestorant];

      for (let i = 1; i < bestRestorantAndWorkers.length; i += 2) {

         workers[bestRestorantAndWorkers[i]] = bestRestorantAndWorkers[i + 1];
      }

      let workersArray = Object.entries(workers);
      let sortedWorkers = workersArray.sort((a, b) => {
         return Number(b[1]) - Number(a[1])
      });

      let output = document.querySelector('div#bestRestaurant p');
      output.textContent = `Name: ${bestRestorantAndWorkers[0]} Average Salary: ${bestAverageSalary.toFixed(2)} Best Salary: ${(Number(sortedWorkers[0][1])).toFixed(2)}`;

      let ouputWorkersAsText = '';
      for (let i = 0; i < sortedWorkers.length; i++) {

         ouputWorkersAsText += `Name: ${sortedWorkers[i][0]} With Salary: ${sortedWorkers[i][1]} `
      }
      ouputWorkersAsText = ouputWorkersAsText.trim();

      let outputWorkers = document.querySelector('div#workers p');
      outputWorkers.textContent = ouputWorkersAsText;
   }
}