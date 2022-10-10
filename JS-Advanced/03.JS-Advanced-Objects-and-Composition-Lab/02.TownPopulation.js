function solve(input) {
    let results = {};
    for (const kvp of input) {
        let [city, citizen] = kvp.split(' <-> ');
        let population = Number(citizen);

        if (!results[city]) {
            results[city] = 0;
        }
        results[city] += population;
    }
    for (const key in results) {
        console.log(`${key} : ${results[key]}`);
    }
}
solve(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']

);