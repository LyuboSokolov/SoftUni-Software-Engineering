function solve(input) {
    let maxNumber = Number.MIN_SAFE_INTEGER;
    let result = [];
    for (let i = 0; i < input.length; i++) {
        if (maxNumber <= input[i]) {
            result.push(input[i]);
            maxNumber = input[i];
        }
    }
    return result;
}
solve([20, 3, 2, 15, 6, 1]);