function solve(input) {
    let neighborPairs = 0;
    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[row].length; col++) {
            if ((row - 1 >= 0) && input[row][col] === input[row - 1][col]) {
                neighborPairs++;
            }
            if ((row + 1 < input.length) && input[row][col] === input[row + 1][col]) {
                neighborPairs++;
            }
            if ((col - 1 >= 0) && input[row][col] === input[row][col - 1]) {
                neighborPairs++;
            }
            if ((col + 1 < input[row].length) && input[row][col] === input[row][col + 1]) {
                neighborPairs++;
            }
        }
    }
    return neighborPairs / 2;
}
//solve([['test', 'yes', 'yo', 'ho'],['well', 'done', 'yo', '6'],['not', 'done', 'yet', '5']]);