function solve(input = 5){
for(let i = 0; i< input; i++){
    let result = '';
    for(let j = 0; j< input; j++){
        if (j == 0){
            result += '*';
        } else {
        result +=' ' + '*';
        }
    }
    console.log(result);
}
}
