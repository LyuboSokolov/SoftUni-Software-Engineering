function solve(input) {
    let result = {};
    for (const infos of input) {
        let [product, price] = infos.split(' : ');
        price = Number(price);
        result[product] = price;
    }
    let sortedProductName = Object.keys(result).sort((a, b) => {
        return a.localeCompare(b)
    });
    let lastFirstLetter;

    for (const productName of sortedProductName) {
        let firstLetter = productName.slice(0, 1);

        if (firstLetter != lastFirstLetter) {
            console.log(firstLetter);
            console.log(`  ${productName}: ${result[productName]}`);
        } else {
            console.log(`  ${productName}: ${result[productName]}`);
        }
        lastFirstLetter = firstLetter;
    }
}
solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']


);