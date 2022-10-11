function solve(input) {
    let results = {};
    for (let i = 0; i < input.length; i += 2) {
        results[input[i]] = Number(input[i + 1]);
    }
    console.log(results);
}
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);