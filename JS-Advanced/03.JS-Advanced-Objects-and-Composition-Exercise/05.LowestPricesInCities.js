function solve(input) {
    let allCityAndProduct = [];
    for (const info of input) {
        let [town, product, price] = info.split(' | ');
        price = Number(price);

        if (allCityAndProduct.some(x => x.product == product && x.price > price)) {
            let recordForRemove = allCityAndProduct.find(x => x.product == product);
            let indexForRemove = allCityAndProduct.indexOf(recordForRemove);
            allCityAndProduct.splice(indexForRemove, 1, { town, product, price });

        } else if (!allCityAndProduct.some(x => x.product == product)) {
            allCityAndProduct.push({ town, product, price });
        }
    }
    for (const info of allCityAndProduct) {
        console.log(`${info.product} -> ${info.price} (${info.town})`);
    }
}
solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 20',
    'Sample Town | Peach | 1',
    'New York | Burger | 0',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
]
);