function solve(input) {

    let matrix = [];
    for (let i = 0; i < input.length; i++) {
        let array = input[i].split(' ');
        matrix.push(array);
    }
    let mainDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        mainDiagonalSum += Number(matrix[row][row]);
        secondDiagonalSum += Number(matrix[row][matrix[row].length - 1 - row]);
    }

    if (mainDiagonalSum === secondDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix[row].length; col++) {

                if (row === col) {
                    continue;
                } else if (col === matrix[row].length - 1 - row) {
                    continue;
                } else {
                    matrix[row][col] = mainDiagonalSum;
                }
            }
        }
    }

    for (let row = 0; row < matrix.length; row++) {
        console.log(matrix[row].join(' '));
    }


}
solve(['5 3 12 3 1',
       '11 4 23 2 5',
       '101 12 3 21 10',
       '1 4 5 2 2',
       '5 22 33 11 1'])