function solve(input) {
    let firstNumber = Number(input.shift());
    let lastNumber = Number(input.pop());
    return firstNumber + lastNumber;
}
//solve(['20','30','40'])