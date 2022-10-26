function solve(input, start, end) {
    let result = 0;

    if (!Array.isArray(input)) {
        return NaN;
    }
    if (input.length == 0) {
        return result;
    }
    startIndex = Math.max(start, 0);
    endIndex = Math.min(end, input.length);

    result = input.slice(startIndex, endIndex + 1).reduce((sum,x) => {
      return sum += Number(x);
    });
    
    return result;

}
solve([10, 20, 30, 40, 50, 60], 3, 300);