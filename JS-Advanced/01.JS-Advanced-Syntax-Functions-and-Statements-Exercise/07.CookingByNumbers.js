function solve(inputNumber, firstOperation, secondOperation,
   thirdOperation, fourthOperation, fifthOperation) {
   let operations = [firstOperation, secondOperation, thirdOperation, fourthOperation, fifthOperation];
   let number = Number(inputNumber);

   for (let i = 0; i < operations.length; i++) {
      let currentOperation = operations[i];
      if (currentOperation == 'chop') {
         number /= 2;
      } else if (currentOperation == 'dice') {
         number = Math.sqrt(number);
      } else if (currentOperation == 'spice') {
         number += 1;
      } else if (currentOperation == 'bake') {
         number *= 3;
      } else if (currentOperation == 'fillet') {
         number = number * 0.8;
      }
      console.log(number);
   }
}
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet')