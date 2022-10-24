function solve(array, sortFactor) {

    if (sortFactor == 'asc') {
        array.sort((a, b) => {
            return a - b;
        });
    } else {
        array.sort((a, b) => {
            return b - a;
        })
    }
    return array;
}
solve([14, 7, 17, 6, 8], 'asc');