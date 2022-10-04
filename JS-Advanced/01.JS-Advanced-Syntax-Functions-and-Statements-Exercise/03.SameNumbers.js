function solve(input) {
    let sum = 0;
    let isValidNumber = true;
    let num = input.toString();
    let previosDigit;

    for (let i = 0; i < num.length; i++) {
        sum += Number(num[i]);
        let digit = num[i];

        if (i != 0 && digit != previosDigit && isValidNumber) {
            isValidNumber = false;
        }
        previosDigit = num[i];
    }
    console.log(isValidNumber);
    console.log(sum);
}
solve(1234);