function solve(input) {
    input.sort((a, b) => a - b);
    let firstNumber = input.shift();
    let secondNumber = input.shift();
    console.log(`${firstNumber} ${secondNumber}`);
}
//solve([3, 0, 10, 3, 7, 3]);