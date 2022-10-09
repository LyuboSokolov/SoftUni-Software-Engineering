function solve(input) {
    let result = [];
    input.sort((a, b) => a - b)

    while (input.length > 1) {
        let smallestNumber = input.shift();
        let biggestNumber = input.pop();
        result.push(smallestNumber, biggestNumber);
    }
    result.push(input[input.length - 1]);

    return result;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);