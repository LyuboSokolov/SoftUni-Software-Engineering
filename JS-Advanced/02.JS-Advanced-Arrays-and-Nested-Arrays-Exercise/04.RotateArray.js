function solve(input, numbersOfRotation) {
    for (let i = 0; i < numbersOfRotation; i++) {
        let lastElement = input.pop();
        input.unshift(lastElement);
    }
    console.log(input.join(' '));
}
solve(['Banana', 'Orange', 'Coconut', 'Apple'], 15);