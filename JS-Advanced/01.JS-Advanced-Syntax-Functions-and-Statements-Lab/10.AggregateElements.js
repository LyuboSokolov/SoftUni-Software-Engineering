function solve (input){
    let sum = 0;
    let inversSum = 0;
    let concatNumbers = '';

    for (let i = 0; i < input.length; i++){
        sum += input[i];
        inversSum += 1/input[i];
        concatNumbers +=input[i];
    }
    console.log(sum);
    console.log(inversSum);
    console.log(concatNumbers);
}
