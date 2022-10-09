function solve(input) {
    let isMagicMatrix = true;
    let sum;
    for (let row = 0; row < input.length; row++) {
        let currentSum = input[row].reduce((acc, num) => acc + num);
        if (row == 0) {
            sum = currentSum;
        }
        if (sum != currentSum) {
            isMagicMatrix = false;
            break;
        }
        let currentColSum = 0;
        for (let col = 0; col < input.length; col++) {
            currentColSum += input[row][col];
        }
        if (sum != currentColSum) {
            isMagicMatrix = false;
            break;
        }
    }
    console.log(isMagicMatrix);
}
solve([[1, 0, 0], [0, 0, 1], [0, 1, 0]]);