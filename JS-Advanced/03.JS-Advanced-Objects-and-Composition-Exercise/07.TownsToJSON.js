function solve(input) {
    let result = [];
    let splitted = input[0].split('|');
    let town = splitted[1].trim();
    let latitude = splitted[2].trim();
    let longitude = splitted[3].trim();

    for (let i = 1; i < input.length; i++) {
        let obj = {};
        let infos = input[i].split('|');
        obj[town] = infos[1].trim();
        obj[latitude] = Number(Number(infos[2].trim()).toFixed(2));
        obj[longitude] = Number(Number(infos[3].trim()).toFixed(2));
        result.push(obj);
    }
    return JSON.stringify(result);
}
solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);