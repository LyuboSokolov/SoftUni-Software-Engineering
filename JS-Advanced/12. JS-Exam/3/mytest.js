function sellFlowers(gardenArr, space) {
    let shop = [];
    let i = 0;
    if (!Array.isArray(gardenArr) || !Number.isInteger(space) || space < 0 || space >= gardenArr.length) {
        throw new Error('Invalid input!');
    } else {
        while (gardenArr.length > i) {
            if (i != space) {
                shop.push(gardenArr[i]);
            }
            i++
        }
    }
    return shop.join(' / ');
}

console.log(sellFlowers(["Rose", "Lily", "Orchid"],1));