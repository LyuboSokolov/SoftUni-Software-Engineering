function solve(input) {
    let result = [];
    for (let i = 0; i < input.length; i++) {
        if (i % 2 != 0) {
            result.unshift(input[i] * 2);
        }
    }
    return result.join(' ');
}
//solve([3, 0, 10, 4, 7, 3]);