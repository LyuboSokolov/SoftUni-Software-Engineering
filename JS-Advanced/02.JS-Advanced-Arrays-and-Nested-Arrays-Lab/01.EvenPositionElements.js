function solve(input) {
    let arr = [];
    let result;
    for (let i = 0; i < input.length; i++) {
        if (i % 2 == 0) {
            arr.push(input[i]);
        }
    }
    result = arr.join(' ');
    console.log(result);
}
//solve(['20','30','40','50','60'])