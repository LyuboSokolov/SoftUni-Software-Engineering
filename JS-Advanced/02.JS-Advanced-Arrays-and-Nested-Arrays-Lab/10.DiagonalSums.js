function solve(input) {
    let mainDiagonal = 0;
    let secondDiagonal = 0;
    for (let row = 0; row < input.length; row++) {
        mainDiagonal += input[row][row];
        secondDiagonal += input[row][input.length - 1 - row];
    }
    console.log(`${mainDiagonal} ${secondDiagonal}`);
}
//solve([[20, 40], [10, 60]]);