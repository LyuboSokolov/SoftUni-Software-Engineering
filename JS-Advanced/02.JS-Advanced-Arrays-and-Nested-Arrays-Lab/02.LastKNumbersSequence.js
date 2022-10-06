function solve(input1, input2) {
    let n = Number(input1);
    let k = Number(input2);
    let result = [1];

    while (result.length < n) {
        let currentSum = 0;
        if (result.length - k < 0) {
            for (let i = 0; i < result.length; i++) {
                currentSum += result[i];
            }
        } else {
            let currentPreviosNmbers = result.slice(result.length - k);

            for (let i = 0; i < currentPreviosNmbers.length; i++) {
                currentSum += currentPreviosNmbers[i];
            }
        }
        result[result.length] = currentSum;
    }
    return result;
}
//solve(8,2)