function solve(input) {
    let result = [];
    for (let num of input) {
        if (num >= 0) {
            result.push(num);
        } else {
            result.unshift(num);
        }
    }
    result.forEach(x => console.log(x));
}
//solve([3, -2, 0, -1]);