function subtract() {
    let firstNumber = Number(document.getElementById('firstNumber').value);
    let secondNumber = Number(document.getElementById('secondNumber').value);
    let subtraction = firstNumber - secondNumber;
    document.getElementById('result').textContent = subtraction;
    console.log(subtraction);
}