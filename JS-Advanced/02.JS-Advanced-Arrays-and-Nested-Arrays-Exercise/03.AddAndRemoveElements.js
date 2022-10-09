function solve(input) {
    let result = [];
    for (let i = 0; i < input.length; i++) {
        let currentCommand = input[i];
        if (currentCommand == 'add') {
            result.push(i + 1);
        } else if (currentCommand == 'remove' && result.length != 0) {
            result.pop();
        }
    }
    if (result.length == 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n'));
    }
}
solve(['add', 'add', 'remove', 'add', 'add']);