function calc() {
    let num1 = document.getElementById('num1');
    let firstNumber = Number(num1.value);
    let num2 = document.getElementById('num2');
    let secondNumber = Number(num2.value);
    let sum = firstNumber + secondNumber;
    document.getElementById('sum').value = sum;
}
